using Izeem.Domain.Commons;
using System.Net.Mail;

namespace Izeem.Domain.Entities.Suppliers;

public class Vehicle : Auditable
{
    public string Model { get; set; }
    public string Brand { get; set; }
    public string CarNumber { get; set; }
    public string Color { get; set; }

    public long? AttachmentId { get; set; }
    public Attachment Attachment { get; set; }
}
