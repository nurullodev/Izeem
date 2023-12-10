using Izeem.Domain.Enums;

namespace Izeem.Service.DTOs.Payments;

public class PaymentResultDto
{
    public long Id { get; set; }
    public PaymentType Type { get; set; }
    public decimal Amount { get; set; }
}
