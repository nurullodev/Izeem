using AutoMapper;
using Izeem.DAL.IRepositories;
using Izeem.Domain.Configurations;
using Izeem.Domain.Entities.Users;
using Izeem.Domain.Enums;
using Izeem.Service.Commons.Helpers;
using Izeem.Service.Commons.Security;
using Izeem.Service.DTOs.Users;
using Izeem.Service.Exceptions;
using Izeem.Service.Extensions;
using Izeem.Service.Interfaces.Users;
using System.Data;

namespace Izeem.Service.Services.Users;

public class UserService : IUserService
{
    private readonly IMapper _mapper;
    private readonly IRepository<User> _userRepository;
    public UserService(IMapper mapper, IRepository<User> userRepository)
    {
        _mapper = mapper;
        _userRepository = userRepository;
    }

    public async Task<UserResultDto> CreateAsync(UserCreationDto dto)
    {
        var existUser = await _userRepository.SelectAsync(user => user.Email.Equals(dto.Email));
        if (existUser is not null)
            throw new IzeemException(403, $"This user already exists with = {dto.Email}");

        var password = PasswordGenerate.Password();
        var result = PasswordHasher.Hash(password);
        var mappedUser = _mapper.Map<User>(dto);
        mappedUser.Role = UserRole.Customer;
        mappedUser.Salt = result.Salt;
        mappedUser.PasswordHash = result.Hash;
        mappedUser.CreatedAt = TimeHelper.GetDateTime();

        await _userRepository.AddAsync(mappedUser);
        await _userRepository.SaveAsync();

        return _mapper.Map<UserResultDto>(mappedUser);
    }

    public async Task<UserResultDto> UpdateAsync(long id, UserUpdateDto dto)
    {
        var existUser = await _userRepository.SelectAsync(user => user.Id.Equals(id))
            ?? throw new IzeemException(404, "This user is not found");

        var checkUser = await _userRepository.SelectAsync(user => user.Email.Equals(dto.Email) &&
        !user.Email.Equals(existUser.Email));

        if (checkUser is not null)
            throw new IzeemException(403, $"This user already exists with = {dto.Email}");

        var mappedUser = _mapper.Map(dto, existUser);
        mappedUser.Id = id;
        mappedUser.Role = existUser.Role;
        mappedUser.UpdatedAt = TimeHelper.GetDateTime();

        _userRepository.Update(mappedUser);
        await _userRepository.SaveAsync();

        return _mapper.Map<UserResultDto>(mappedUser);

    }

    public async Task<UserResultDto> UpdateSecurityAsync(long id, UserSecurityUpdateDto security)
    {
        var existUser = await _userRepository.SelectAsync(user => user.Id.Equals(id))
            ?? throw new IzeemException(404, "This user is not found");

        if (security.NewPassword != security.ConfirmPassword)
            throw new IzeemException(400, "New password is not equals to confirm assword");

        var passwords = PasswordHasher.Hash(security.NewPassword);
        existUser.PasswordHash = passwords.Hash;
        existUser.Salt = passwords.Salt;
        existUser.UpdatedAt = TimeHelper.GetDateTime();

        _userRepository.Update(existUser);
        await _userRepository.SaveAsync();

        return _mapper.Map<UserResultDto>(existUser);
    }

    public async Task<UserResultDto> UpgradeRoleAsync(long id, UserRole role)
    {
        var existUser = await _userRepository.SelectAsync(u => u.Id.Equals(id))
             ?? throw new IzeemException(404, "This user is not found");

        existUser.Id = id;
        existUser.Role = role;
        existUser.UpdatedAt = TimeHelper.GetDateTime();

        _userRepository.Update(existUser);
        await _userRepository.SaveAsync();

        return _mapper.Map<UserResultDto>(existUser);
    }

    public async Task<bool> DeleteAsync(long id)
    {
        var existUser = await _userRepository.SelectAsync(user => user.Id.Equals(id))
           ?? throw new IzeemException(404, "This user is not found");

        _userRepository.Delete(existUser);
        await _userRepository.SaveAsync();

        return true;
    }

    public async Task<UserResultDto> GetByIdAsync(long id)
    {
        var existUser = await _userRepository.SelectAsync(user => user.Id.Equals(id))
           ?? throw new IzeemException(404, "This user is not found");

        return _mapper.Map<UserResultDto>(existUser);
    }

    public async Task<IEnumerable<UserResultDto>> GetAllAsync(PaginationParams pagination, string search = null)
    {
        var users = _userRepository.SelectAll();
        if (!string.IsNullOrEmpty(search))
        {
            users = users.Where(user =>
                user.FirstName.ToLower().Contains(search.ToLower()) ||
                user.LastName.ToLower().Contains(search.ToLower())
            );
        }

        var result = users.ToPagedList(pagination);
        return _mapper.Map<IEnumerable<UserResultDto>>(result);
    }
}
