namespace Izeem.DAL.IRepositories;

public interface IRepository<TEntity>
{
    Task<int> InsertAsync(TEntity entity);
    Task<int> UpdateAsync(TEntity entity);
    Task<bool> DeleteAsync(TEntity entity);
    Task<TEntity> SelectAsync(long id);
    IQueryable<TEntity> SelectAll();
    Task<long> CountAsync();
}