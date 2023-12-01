using Izeem.Domain.Entities.Users;

namespace Izeem.DAL.IRepositories.Users;

public interface IUserRepository : IRepository<User>
{
    Task<User?> GetByPhoneAsync(string phone);
}