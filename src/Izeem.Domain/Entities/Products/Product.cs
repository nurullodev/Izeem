using Izeem.Domain.Commons;
using System.Net.Mail;

namespace Izeem.Domain.Entities.Products;

public class Product : Auditable
{
    public string Name { get; set; }
    public string Description { get; set; }
    public bool IsTop { get; set; }
    public int Discount { get; set; }
    public bool IsAvailable { get; set; }

    public long CategoryId { get; set; }
    public ProductCategory Category { get; set; }

    public long? AttachmentId { get; set; }
    public Attachment Attachment { get; set; }
}