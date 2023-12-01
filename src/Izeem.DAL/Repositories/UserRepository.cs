using Izeem.DAL.IRepositories.Users;
using Izeem.Domain.Entities.Users;
using System.Linq.Expressions;

namespace Izeem.DAL.Repositories;

public class UserRepository : IUserRepository
{
    public Task<long> CountAsync()
    {
        throw new NotImplementedException();
    }

    public Task<bool> DeleteAsync(User entity)
    {
        throw new NotImplementedException();
    }

    public Task<User> GetByPhoneAsync(string phone)
    {
        throw new NotImplementedException();
    }

    public Task<int> InsertAsync(User entity)
    {
        throw new NotImplementedException();
    }

    public IQueryable<User> SelectAll()
    {
        throw new NotImplementedException();
    }

    public Task<User> SelectAsync(long id)
    {
        throw new NotImplementedException();
    }

    public Task<int> UpdateAsync(User entity)
    {
        throw new NotImplementedException();
    }
}