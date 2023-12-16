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
    public Task<(bool Result, int CachedMinutes)> RegisterAsync(UserRegisterDto dto);
    public Task<(bool Result, int CachedVerificationMinutes)> SendCodeForRegisterAsync(string email);

    public Task<(bool Result, string Token)> VerifyRegisterAsync(string email, int code);
    Task<LoginResultDto> LoginAsync(LoginDto dto);
}
