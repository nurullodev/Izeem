using Izeem.Domain.Configurations;
using Izeem.Service.DTOs.Assets;
using Izeem.Service.DTOs.Products;

namespace Izeem.Service.Interfaces.Products;

public interface IProductService
{
    Task<ProductResultDto> AddAsync(ProductCreationDto dto);
    Task<ProductResultDto> ModifyAsync(ProductUpdateDto dto);
    Task<bool> RemoveAsync(long id);
    Task<ProductResultDto> RetrieveByIdAsync(long id);
    Task<IEnumerable<ProductResultDto>> RetrieveByCategoryIdAsync(long categoryId);
    Task<IEnumerable<ProductResultDto>> RetrieveAllAsync(PaginationParams pagination, string search = null);
}