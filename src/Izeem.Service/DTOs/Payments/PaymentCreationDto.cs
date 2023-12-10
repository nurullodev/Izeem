using Izeem.Domain.Enums;

namespace Izeem.Service.DTOs.Payments;

public class PaymentCreationDto
{
    public PaymentType Type { get; set; }
    public decimal Amount { get; set; }
}
