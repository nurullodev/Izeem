using Izeem.Domain.Commons;
using Izeem.Domain.Enums;

namespace Izeem.Domain.Entities.Users;

public class User : Auditable
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string PasswordHash { get; set; }
    public string Salt { get; set; }
    public UserRole Role { get; set; }
}