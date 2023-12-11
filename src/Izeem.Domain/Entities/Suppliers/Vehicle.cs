using Izeem.Domain.Commons;
using Izeem.Domain.Entities.Assets;

namespace Izeem.Domain.Entities.Suppliers;

public class Vehicle : Auditable
{
    public string Model { get; set; }
    public string Brand { get; set; }
    public string CarNumber { get; set; }
    public string Color { get; set; }

    public long? AssetId { get; set; }
    public Asset Asset { get; set; }
}
