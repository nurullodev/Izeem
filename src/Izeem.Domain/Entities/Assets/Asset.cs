using Izeem.Domain.Commons;

namespace Izeem.Domain.Entities.Assets;

public class Asset : Auditable
{
    public string FilePath { get; set; }
    public string FileName { get; set; }
}
