using Izeem.Domain.Configurations;
using Izeem.Domain.Enums;
using Izeem.Service.DTOs.Users;

namespace Izeem.Service.Interfaces.Users;

public interface IUserService
{
    Task<UserResultDto> CreateAsync(UserCreationDto dto);
    Task<UserResultDto> UpdateAsync(long id, UserUpdateDto dto);
    Task<bool> DeleteAsync(long id);
    Task<UserResultDto> GetByIdAsync(long id);
    Task<UserResultDto> UpgradeRoleAsync(long id, UserRole role);
    Task<UserResultDto> UpdateSecurityAsync(long id, UserSecurityUpdateDto security);
    Task<IEnumerable<UserResultDto>> GetAllAsync(PaginationParams pagination, string search = null);
}