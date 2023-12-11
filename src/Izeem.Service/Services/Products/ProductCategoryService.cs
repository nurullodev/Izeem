using AutoMapper;
using Izeem.DAL.IRepositories;
using Izeem.Domain.Entities.Products;
using Izeem.Service.DTOs.ProductCategories;
using Izeem.Service.Exceptions;
using Izeem.Service.Interfaces.Products;
using Microsoft.EntityFrameworkCore;

namespace Izeem.Service.Services.Products;

public class ProductCategoryService : IProductCategoryService
{
    private readonly IMapper _mapper;
    private readonly IRepository<ProductCategory> _repository;
    public ProductCategoryService(IRepository<ProductCategory> repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<ProductCategoryResultDto> AddAsync(ProductCategoryCreationDto dto)
    {
        var category = await _repository.SelectAsync(c => c.Name.Equals(dto.Name));
        if (category is not null)
            throw new IzeemException(403, "This category is already exists");

        var mappedCategory = _mapper.Map<ProductCategory>(dto);
        await _repository.AddAsync(mappedCategory);
        await _repository.SaveAsync();

        return _mapper.Map<ProductCategoryResultDto>(mappedCategory);
    }

    public async Task<ProductCategoryResultDto> ModifyAsync(ProductCategoryUpdateDto dto)
    {
        var category = await _repository.SelectAsync(c => c.Id.Equals(dto.Id), includes: new[] { "Products" })
            ?? throw new IzeemException(404, "This category is not found");

        var mappedCategory = _mapper.Map(dto, category);
        _repository.Update(mappedCategory);
        await _repository.SaveAsync();

        return _mapper.Map<ProductCategoryResultDto>(mappedCategory);
    }

    public async Task<bool> RemoveAsync(long id)
    {
        var category = await _repository.SelectAsync(c => c.Id.Equals(id))
            ?? throw new IzeemException(404, "This category is not found");

        _repository.Delete(category);
        await _repository.SaveAsync();
        return true;
    }

    public async Task<ProductCategoryResultDto> RetrieveByIdAsync(long id)
    {
        var category = await _repository.SelectAsync(c => c.Id.Equals(id), includes: new[] { "Products" })
            ?? throw new IzeemException(404, "This category is not found");

        return _mapper.Map<ProductCategoryResultDto>(category);
    }

    public async Task<IEnumerable<ProductCategoryResultDto>> RetrieveAllAsync()
    {
        var categories = await _repository.SelectAll(includes: new[] { "Products" }).ToListAsync();
        return _mapper.Map<IEnumerable<ProductCategoryResultDto>>(categories);
    }
}