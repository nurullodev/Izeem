using Izeem.Domain.Enums;

namespace Izeem.Service.DTOs.Users;

public class UserCreationDto
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public UserRole Role { get; set; }
}