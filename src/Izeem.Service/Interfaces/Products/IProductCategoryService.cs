using Izeem.Service.DTOs.ProductCategories;

namespace Izeem.Service.Interfaces.Products;

public interface IProductCategoryService
{
    Task<ProductCategoryResultDto> AddAsync(ProductCategoryCreationDto dto);
    Task<ProductCategoryResultDto> ModifyAsync(ProductCategoryUpdateDto dto);
    Task<bool> RemoveAsync(long id);
    Task<ProductCategoryResultDto> RetrieveByIdAsync(long id);
    Task<IEnumerable<ProductCategoryResultDto>> RetrieveAllAsync();
}