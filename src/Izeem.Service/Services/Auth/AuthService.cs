using AutoMapper;
using Izeem.DAL.IRepositories;
using Izeem.Domain.Entities.Users;
using Izeem.Service.Commons.Security;
using Izeem.Service.DTOs.Login;
using Izeem.Service.DTOs.Users;
using Izeem.Service.Exceptions;
using Izeem.Service.Interfaces.Auth;

namespace Izeem.Service.Services.Auth;

public class AuthService : IAuthService
{
    private ITokenService _tokenService;
    private IMapper _mapper;
    private IRepository<User> _userRepository;

    public AuthService(IMapper mapper,
        IRepository<User> userRepository,
        ITokenService service)
    {
        _tokenService = service;
        _mapper = mapper;
        _userRepository = userRepository;
    }
    public async Task<LoginResultDto> LoginAsync(LoginDto dto)
    {
        var existUser = await _userRepository.SelectAsync(user => user.Email.Equals(dto.Email))
            ?? throw new IzeemException(404, "This user is not found");

        var hasherResult = PasswordHasher.Verify(dto.Password, existUser.PasswordHash, existUser.Salt);
        if (!hasherResult)
            throw new IzeemException(403, "This password not ");

        var token = await _tokenService.GenerateTokenAsync(existUser);

        LoginResultDto authResult = new LoginResultDto()
        {
            Token = token
        };

        return authResult;
    }
}
