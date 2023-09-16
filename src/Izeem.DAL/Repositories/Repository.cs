using Izeem.DAL.IRepositories;
using Izeem.Domain.Commons;
using System.Linq.Expressions;

namespace Izeem.DAL.Repositories;

public class Repository<TEntity> : IRepository<TEntity> where TEntity : Auditable
{
    public ValueTask<TEntity> AddAsync(TEntity entity)
    {
        throw new NotImplementedException();
    }

    public void Delete(TEntity entity)
    {
        throw new NotImplementedException();
    }

    public ValueTask<bool> DestroyAsync(TEntity entity)
    {
        throw new NotImplementedException();
    }

    public ValueTask SaveAsync()
    {
        throw new NotImplementedException();
    }

    public IQueryable<TEntity> SelectAll(Expression<Func<TEntity, bool>> expression = null, bool isNoTracked = true, string[] includes = null)
    {
        throw new NotImplementedException();
    }

    public ValueTask<TEntity> SelectAsync(Expression<Func<TEntity, bool>> expression, string[] includes = null)
    {
        throw new NotImplementedException();
    }

    public TEntity Update(TEntity entity)
    {
        throw new NotImplementedException();
    }
}