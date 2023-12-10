using Izeem.Domain.Commons;

namespace Izeem.Domain.Entities.Addresses;

public class Address : Auditable
{
    public string Street { get; set; }
    public string Floor { get; set; }
    public string Home { get; set; }
    public string DoorCode { get; set; }
    public string Country { get; set; }
    public string Region { get; set; }
    public string District { get; set; }
}