using Npgsql;

namespace Izeem.DAL.DbContexts;

public class IzeemDbContext
{
    protected readonly NpgsqlConnection _connection;
    public IzeemDbContext()
    {
        _connection = new NpgsqlConnection("");
    }
}