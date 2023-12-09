using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Izeem.Service.DTOs.Users;

public class UserResetPasswordDto
{
    public string Email { get; set; }
    public string NewPassword { get; set; }
}
