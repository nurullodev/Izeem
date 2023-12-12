using AutoMapper;
using Izeem.DAL.Commons;
using Izeem.DAL.IRepositories;
using Izeem.Domain.Entities.Users;
using Izeem.Domain.Enums;
using Izeem.Service.Commons.Helpers;
using Izeem.Service.Commons.Security;
using Izeem.Service.DTOs;
using Izeem.Service.DTOs.Login;
using Izeem.Service.DTOs.Users;
using Izeem.Service.Exceptions;
using Izeem.Service.Interfaces.Auth;
using Izeem.Service.Interfaces.Notifications;
using Izeem.Service.Interfaces.Users;
using Microsoft.Extensions.Caching.Memory;

namespace Izeem.Service.Services.Auth;

public class AuthService : IAuthService
{

    private const int CACHED_FOR_MINUTS_REGISTER = 60;
    private const int CACHED_FOR_MINUTS_VEFICATION = 5;
    private const int VERIFICATION_MAXIMUM_ATTEMPTS = 3;

    private const string REGISTER_CACHE_KEY = "register_";
    private const string VERIFY_REGISTER_CACHE_KEY = "verify_register_";
    private const string Reset_CACHE_KEY = "reset_";
    private IEmailsender _emailSender;
    private IMapper _mapper;
    private ITokenService _tokenService;
    private IMemoryCache _memoryCache;
    //private IIdentityService _identityservice;
    private IRepository<User> _userRepository;


    public AuthService(
        IMapper mapper,
        IEmailsender sender,
        IUserService userService,
        IMemoryCache memoryCache,
        ITokenService tokenService,
        IRepository<User> userRepository
        )
    {
        _userRepository = userRepository;
        _emailSender = sender;
        _mapper = mapper;
        _tokenService = tokenService;
        _memoryCache = memoryCache;
        _userRepository = userRepository;
        //_identityservice = identityService;
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
            Result = true,
            Token = token
        };

        return authResult;
    }

    public async Task<(bool Result, int CachedMinutes)> RegisterAsync(UserRegisterDto dto)
    {
        var existUser = await _userRepository.SelectAsync(user => user.Email.Equals(dto.Email));
        
        if (existUser != null)
            throw new IzeemException(404, "This user is not found");

        if (_memoryCache.TryGetValue(REGISTER_CACHE_KEY + dto.Email, out UserRegisterDto registerDto))
        {
            registerDto.Email = registerDto.Email;
            _memoryCache.Remove(dto.Email);
        }
        else
        {
            _memoryCache.Set(REGISTER_CACHE_KEY + dto.Email, dto, TimeSpan.FromMinutes
                (CACHED_FOR_MINUTS_REGISTER));
        }

        return (Result: true, CachedMinutes: CACHED_FOR_MINUTS_REGISTER);
    }

    public async Task<(bool Result, int CachedVerificationMinutes)> SendCodeForRegisterAsync(string email)
    {
        if (_memoryCache.TryGetValue(REGISTER_CACHE_KEY + email, out UserRegisterDto registerDto))
        {
            VerificationDto verificationDto = new VerificationDto();
            verificationDto.Attempt = 0;
            verificationDto.CreatedAt = TimeHelper.GetDateTime();
            verificationDto.Code = CodeGenerator.RandomCodeGenerator();
            _memoryCache.Set(email, verificationDto, TimeSpan.FromMinutes(CACHED_FOR_MINUTS_VEFICATION));

            if (_memoryCache.TryGetValue(VERIFY_REGISTER_CACHE_KEY + email,
                out VerificationDto OldverificationDto))
            {
                _memoryCache.Remove(email);
            }

            _memoryCache.Set(VERIFY_REGISTER_CACHE_KEY + email, verificationDto,
                TimeSpan.FromMinutes(VERIFICATION_MAXIMUM_ATTEMPTS));

            EmailSenderDto smsSenderDto = new EmailSenderDto();
            smsSenderDto.Title = "Izeem\n";
            smsSenderDto.Content = "Your verification code : " + verificationDto.Code;
            smsSenderDto.Recipent = email;
            var result = await _emailSender.SenderAsync(smsSenderDto);

            if (result is true)
                return (Result: true, CachedVerificationMinutes: CACHED_FOR_MINUTS_VEFICATION);
            else
                return (Result: false, CACHED_FOR_MINUTS_VEFICATION: 0);
        }
        else
        {
            throw new Exception();
        }
    }

    public async Task<(bool Result, string Token)> VerifyRegisterAsync(string email, int code)
    {
        if (_memoryCache.TryGetValue(REGISTER_CACHE_KEY + email, out UserRegisterDto userRegisterDto))
        {
            if (_memoryCache.TryGetValue(VERIFY_REGISTER_CACHE_KEY + email, out VerificationDto verificationDto))
            {
                if (verificationDto.Attempt >= VERIFICATION_MAXIMUM_ATTEMPTS)
                    throw new Exception();

                else if (verificationDto.Code == code)
                {
                    var password = userRegisterDto.Password;
                    var result = PasswordHasher.Hash(password);
                    var mappedUser = _mapper.Map<User>(userRegisterDto);
                    mappedUser.Salt = result.Salt;
                    mappedUser.PasswordHash = result.Hash;
                    mappedUser.CreatedAt = TimeHelper.GetDateTime();

                    var user = await _userRepository.AddAsync(mappedUser);
                    await _userRepository.SaveAsync();

                    var token = await _tokenService.GenerateTokenAsync(user);

                    return (Result: true, Token: token);
                }
                else
                {
                    _memoryCache.Remove(VERIFY_REGISTER_CACHE_KEY + email);
                    verificationDto.Attempt++;
                    _memoryCache.Set(VERIFY_REGISTER_CACHE_KEY + email, verificationDto,
                        TimeSpan.FromMinutes(CACHED_FOR_MINUTS_VEFICATION));

                    return (Result: false, Token: "");
                }
            }
            else throw new Exception();
        }
        else throw new Exception();
    }
}
