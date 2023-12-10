using Izeem.Service.DTOs.Vehicles;

namespace Izeem.Service.DTOs.Suppliers;

public class SupplierResultDto
{
    public long Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Phone { get; set; }
    public DateTime DateOfBirth { get; set; }
    public VehicleResultDto Vehicle { get; set; }
}
