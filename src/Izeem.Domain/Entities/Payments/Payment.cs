using Izeem.Domain.Commons;
using Izeem.Domain.Enums;

namespace Izeem.Domain.Entities.Payments;

public class Payment : Auditable
{
    public PaymentType Type { get; set; }
    public decimal Amount { get; set; }
}
