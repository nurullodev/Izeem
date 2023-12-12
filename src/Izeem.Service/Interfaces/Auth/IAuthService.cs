using Izeem.Service.DTOs.Login;
using Izeem.Service.DTOs.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Izeem.Service.Interfaces.Auth;

public interface IAuthService
{
    Task<LoginResultDto> LoginAsync(LoginDto dto);
}
