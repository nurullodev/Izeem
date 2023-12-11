using Izeem.Domain.Configurations;
using Izeem.Service.DTOs.Attachments;
using Izeem.Service.DTOs.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Izeem.Service.Interfaces.Products;

public interface IProductService
{
    Task<ProductResultDto> AddAsync(ProductCreationDto dto);
    Task<ProductResultDto> ModifyAsync(ProductUpdateDto dto);
    Task<bool> RemoveAsync(long id);
    Task<ProductResultDto> RetrieveByIdAsync(long id);
    Task<IEnumerable<ProductResultDto>> RetrieveAllAsync(PaginationParams pagination, string search = null);
    Task<IEnumerable<ProductResultDto>> RetrieveByCategoryIdAsync(long categoryId);
    Task<ProductResultDto> ImageUploadAsync(long productId, AttachmentCreationDto dto);
    Task<ProductResultDto> ModifyImageAsync(long productId, AttachmentCreationDto dto);
}