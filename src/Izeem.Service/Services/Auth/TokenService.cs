
using Izeem.DAL.Commons;
using Izeem.DAL.IRepositories;
using Izeem.Domain.Entities.Users;
using Izeem.Service.Commons.Helpers;
using Izeem.Service.Exceptions;
using Izeem.Service.Interfaces.Auth;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using TimeHelper = Izeem.Service.Commons.Helpers.TimeHelper;

namespace Izeem.Service.Services.Auth;

public class TokenService : ITokenService
{
    private IConfiguration _configuration;
    private readonly IRepository<User> _userRepository;
    public TokenService(IConfiguration configuration, IRepository<User> userRepository)
    {
        _configuration = configuration.GetSection("Jwt");
        _userRepository = userRepository;
    }

    public async Task<string> GenerateTokenAsync(User user)
    {
        var existUser = await _userRepository.SelectAsync(user => user.Id.Equals(user.Id))
            ?? throw new IzeemException(404, "This user is not found");

        var identityClaims = new Claim[]
        {
            new Claim ("Id", user.Id.ToString()),
            new Claim ("FirstName", user.FirstName),
            new Claim ("LastName", user.LastName),
            new Claim ("Email", user.Email),
            new Claim (ClaimTypes.Role, user.Role.ToString())
        };

        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["SecurityKey"]));
        var keyCredentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
        int expiresHours = 24;

        var token = new JwtSecurityToken(
            issuer: _configuration["Issuer"],
            audience: _configuration["Audience"],
            claims: identityClaims,
            expires: TimeHelper.GetDateTime().AddHours(expiresHours),
            signingCredentials: keyCredentials);

        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}