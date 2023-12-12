using AutoMapper;
using Izeem.DAL.IRepositories;
using Izeem.Domain.Configurations;
using Izeem.Domain.Entities.Assets;
using Izeem.Domain.Entities.Orders;
using Izeem.Domain.Entities.Products;
using Izeem.Service.DTOs.Assets;
using Izeem.Service.DTOs.Products;
using Izeem.Service.Exceptions;
using Izeem.Service.Extensions;
using Izeem.Service.Interfaces.Assets;
using Izeem.Service.Interfaces.Products;
using Microsoft.EntityFrameworkCore;


namespace Izeem.Service.Services.Products;


public class ProductService : IProductService
{
    private readonly IMapper _mapper;
    private readonly IAssetService _assetService;
    private readonly IRepository<Product> _productRepository;
    private readonly IRepository<OrderItem> _orderItemRepository;
    private readonly IRepository<ProductCategory> _productCategoryRepository;
    public ProductService(
        IMapper mapper,
        IAssetService assetService,
        IRepository<Product> productRepository,
        IRepository<ProductCategory> productCategoryRepository,
        IRepository<OrderItem> orderItemRepository)
    {
        _mapper = mapper;
        _productRepository = productRepository;
        _assetService = assetService;
        _productCategoryRepository = productCategoryRepository;
        _orderItemRepository = orderItemRepository;
    }

    public async Task<ProductResultDto> AddAsync(ProductCreationDto dto)
    {
        var product = await _productRepository.SelectAsync(p => p.Name.Equals(dto.Name), includes: new[] { "Asset" });
        if (product is not null)
            throw new IzeemException(403, $"This {product.Name.ToLower()} is alread exists");

        var category = await _productCategoryRepository.SelectAsync(p => p.Id.Equals(dto.CategoryId))
            ?? throw new IzeemException(404, "This category is not found");

        var image = new Asset();
        if (dto.Asset is not null)
        {
            image = await _assetService.UploadAsync(new AssetCreationDto
            {
                FormFile = dto.Asset
            });
        }
        var mappedProduct = new Product();
        mappedProduct.Name = dto.Name;
        mappedProduct.CategoryId= dto.CategoryId;
        mappedProduct.Category = category;
        mappedProduct.Price = dto.Price;
        mappedProduct.Description = dto.Description;
        mappedProduct.CategoryId = category.Id;
        mappedProduct.AssetId = image.Id; 
        mappedProduct.Asset = image;

        await _productRepository.AddAsync(mappedProduct);
        await _productRepository.SaveAsync();
        mappedProduct.Category = category;

        return _mapper.Map<ProductResultDto>(mappedProduct);
    }


    public async Task<ProductResultDto> ModifyAsync(ProductUpdateDto dto)
    {
        var product = await _productRepository.SelectAsync(p => p.Id.Equals(dto.Id), includes: new[] { "Asset" })
            ?? throw new IzeemException(404, "This product is not found");

        var category = await _productCategoryRepository.SelectAsync(p => p.Id.Equals(dto.CategoryId))
            ?? throw new IzeemException(404, "This category is not found");

        var image = new Asset();
        if (dto.Asset is not null)
        {
            image = await _assetService.UploadAsync(new AssetCreationDto
            {
                FormFile = dto.Asset
            });
        }

        var mappedProduct = new Product();
        mappedProduct.Name = dto.Name;
        mappedProduct.CategoryId = dto.CategoryId;
        mappedProduct.Category = category;
        mappedProduct.Price = dto.Price;
        mappedProduct.Description = dto.Description;
        mappedProduct.CategoryId = category.Id;
        mappedProduct.AssetId = image.Id;
        mappedProduct.Asset = image;
        mappedProduct.Id = product.Id;

        _productRepository.Update(mappedProduct);
        await _productRepository.SaveAsync();

        return _mapper.Map<ProductResultDto>(product);
    }

    public async Task<bool> RemoveAsync(long id)
    {
        var product = await _productRepository.SelectAsync(p => p.Id.Equals(id))
            ?? throw new IzeemException(404, "This product is not found");

        _productRepository.Delete(product);
        await _productRepository.SaveAsync();
        return true;
    }

    public async Task<IEnumerable<ProductResultDto>> RetrieveAllAsync(PaginationParams pagination, string search = null)
    {
        var products = _productRepository.SelectAll(
            includes: new[] { "Category", "Asset" })
            .ToPagedList(pagination);

        return _mapper.Map<IEnumerable<ProductResultDto>>(products);
    }


    public async Task<IEnumerable<ProductResultDto>> RetrieveByCategoryIdAsync(long categoryId)
    {
        var products = await _productRepository.SelectAll(expression: p => p.CategoryId == categoryId,
            includes: new[] { "Category", "Asset" }).ToListAsync();

        return _mapper.Map<IEnumerable<ProductResultDto>>(products);
    }

    public async Task<ProductResultDto> RetrieveByIdAsync(long id)
    {
        var product = await _productRepository.SelectAsync(p => p.Id.Equals(id),
            includes: new[] { "Category", "Asset" })
            ?? throw new IzeemException(404, "This product is not found");

        return _mapper.Map<ProductResultDto>(product);
    }
}
