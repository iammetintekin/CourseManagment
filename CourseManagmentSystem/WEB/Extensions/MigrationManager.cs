using App.Infrastructure.DatabaseContext;
using Microsoft.EntityFrameworkCore;

namespace WEB.Extensions
{
    public static class MigrationManager
    {
        public static IHost MigrateDB(this IHost host)
        {
            using (var scope = host.Services.CreateScope())
            {
                using (var projectContext = scope.ServiceProvider.GetRequiredService<PostreSqlDatabaseContext>())
                {
                    try
                    {
                        projectContext.Database.Migrate();
                    }
                    catch (System.Exception)
                    {
                        throw;
                    }
                }
            }
            return host;
        }
    }
}
