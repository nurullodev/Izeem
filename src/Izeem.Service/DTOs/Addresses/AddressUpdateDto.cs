namespace Izeem.Service.DTOs.Addresses;

public class AddressUpdateDto
{
    public long Id { get; set; }
    public string Street { get; set; }
    public string Floor { get; set; }
    public string Home { get; set; }
    public string DoorCode { get; set; }
    public long Country { get; set; }
    public long Region { get; set; }
    public long District { get; set; }
}
