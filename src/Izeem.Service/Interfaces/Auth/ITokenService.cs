using Izeem.Domain.Entities.Users;

namespace Izeem.Service.Interfaces.Auth;

public interface ITokenService
{
    Task<string> GenerateTokenAsync(User user);
}