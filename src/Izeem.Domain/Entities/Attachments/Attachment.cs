using Izeem.Domain.Commons;

namespace Izeem.Domain.Entities.Attachments;

public class Attachment : Auditable
{
    public string FilePath { get; set; }
    public string FileName { get; set; }
}
