using Izeem.Domain.Commons;
using System.Linq.Expressions;

namespace Izeem.DAL.IRepositories;

public interface IRepository<TEntity> where TEntity : BaseEntity
{
    ValueTask<TEntity> AddAsync(TEntity entity);
    TEntity Update(TEntity entity);
    void Delete(TEntity entity);
    void Destroy(TEntity entity);
    ValueTask<TEntity> SelectAsync(Expression<Func<TEntity, bool>> expression, string[] includes = null);
    IQueryable<TEntity> SelectAll(Expression<Func<TEntity, bool>> expression = null,
        bool isNoTracked = true, string[] includes = null);
    ValueTask<bool> SaveAsync();
}