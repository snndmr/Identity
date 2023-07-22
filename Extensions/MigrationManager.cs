using Identity.Models;
using Microsoft.EntityFrameworkCore;

namespace Identity.Extensions
{
    public static class MigrationManager
    {
        public static IHost MigrateDatabase(this IHost host)
        {
            using (var scope = host.Services.CreateScope())
            {
                using var context = scope.ServiceProvider.GetRequiredService<ApplicationContext>();

                context.Database.Migrate();
            }

            return host;
        }
    }
}
