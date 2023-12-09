using Izeem.DAL.Contexts;
using Izeem.Domain.Commons;
using System.Linq.Expressions;
using Izeem.DAL.IRepositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace Izeem.DAL.Repositories;

public class Repository<TEntity> : IRepository<TEntity> where TEntity : BaseEntity
{
    private readonly DbSet<TEntity> _dbSet;
    private readonly IzeemDbContext _dbContext;
    public Repository(IzeemDbContext dbContext)
    {
        _dbContext = dbContext;
        _dbSet = _dbContext.Set<TEntity>();
    }

    public async ValueTask<TEntity> AddAsync(TEntity entity)
    {
        EntityEntry<TEntity> entry = await _dbSet.AddAsync(entity);

        return entry.Entity;
    }

    public TEntity Update(TEntity entity)
    {
        EntityEntry<TEntity> entry = _dbContext.Update(entity);

        return entry.Entity;
    }

    public void Delete(TEntity entity)
    {
        entity.IsDeleted = true;
    }

    public void Destroy(TEntity entity)
    {
        _dbContext.Remove(entity);
    }


    public async ValueTask<TEntity> SelectAsync(Expression<Func<TEntity, bool>> expression, string[] includes = null)
    {
        IQueryable<TEntity> entities = expression == null ? _dbSet.AsQueryable() : _dbSet.Where(expression).AsQueryable();

        if (includes is not null)
            foreach (var include in includes)
                entities = entities.Include(include);

        return await entities.FirstOrDefaultAsync();
    }

    public IQueryable<TEntity> SelectAll(Expression<Func<TEntity, bool>> expression = null, 
        bool isNoTracked = true, string[] includes = null)
    {
        IQueryable<TEntity> entities = expression == null ? _dbSet.AsQueryable()
            : _dbSet.Where(expression).AsQueryable();

        entities = isNoTracked ? entities.AsNoTracking() : entities;

        if (includes is not null)
            foreach (var include in includes)
                entities = entities.Include(include);

        return entities;
    }
   
    public async ValueTask<bool> SaveAsync()
        => await _dbContext.SaveChangesAsync() >= 0;
}