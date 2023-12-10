using Izeem.Domain.Configurations;
using Izeem.Domain.Enums;
using Izeem.Service.DTOs.Users;

namespace Izeem.Service.Interfaces.Users;

public interface IUserService
{
    Task<UserResultDto> AddAsync(UserCreationDto dto);
    Task<UserResultDto> ModifyAsync(long id, UserUpdateDto dto);
    Task<bool> RemoveAsync(long id);
    Task<UserResultDto> RetrieveByIdAsync(long id);
    Task<UserResultDto> UpgradeRoleAsync(long id, UserRole role);
    Task<UserResultDto> UpdateSecurityAsync(long id, UserSecurityUpdateDto security);
    Task<IEnumerable<UserResultDto>> RetrieveAllAsync(PaginationParams pagination, string search = null);
}