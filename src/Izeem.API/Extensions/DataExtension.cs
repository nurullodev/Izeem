using Izeem.DAL.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Izeem.API.Extensions
{
    public static class DataExtension
    {
        public static void ApplyMigrations(this WebApplication app)
        {
            using (var scope = app.Services.CreateScope())
            {
                var db = scope.ServiceProvider.GetRequiredService<IzeemDbContext>();
                db.Database.Migrate();
            }
        }
    }
}