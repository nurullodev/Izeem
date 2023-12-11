using Izeem.Service.DTOs.ProductCategories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Izeem.Service.Interfaces.Products;

public interface IProductCategoryService
{
    Task<ProductCategoryResultDto> AddAsync(ProductCategoryCreationDto dto);
    Task<ProductCategoryResultDto> ModifyAsync(ProductCategoryUpdateDto dto);
    Task<bool> RemoveAsync(long id);
    Task<ProductCategoryResultDto> RetrieveByIdAsync(long id);
    Task<IEnumerable<ProductCategoryResultDto>> RetrieveAllAsync();
}