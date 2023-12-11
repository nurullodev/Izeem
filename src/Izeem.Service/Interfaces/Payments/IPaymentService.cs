using Izeem.Domain.Configurations;
using Izeem.Service.DTOs.Payments;

namespace Izeem.Service.Interfaces.Payments;

public interface IPaymentService
{
    Task<PaymentResultDto> AddAsync(PaymentCreationDto dto);
    Task<PaymentResultDto> ModifyAsync(PaymentUpdateDto dto);
    Task<bool> RemoveAsync(long id);
    Task<PaymentResultDto> RetrieveByIdAsync(long id);
    Task<IEnumerable<PaymentResultDto>> RetrieveAllAsync(PaginationParams pagination, string search = null);
}