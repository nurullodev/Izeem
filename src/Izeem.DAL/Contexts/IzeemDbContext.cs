using Microsoft.EntityFrameworkCore;

namespace Izeem.DAL.Contexts;

public class IzeemDbContext : DbContext
{
    public IzeemDbContext(DbContextOptions<IzeemDbContext> options) : base(options)
    { }
}