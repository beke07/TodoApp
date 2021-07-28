using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Linq;
using TodoApp.Dal.Entities;
using TodoApp.Data;

namespace Microsoft.Extensions.Hosting
{
    public static class HostExtensions
    {
        public static IHost MigrateDatabase(this IHost host)
        {
            using (var scope = host.Services.CreateScope())
            {
                using var appContext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();

                appContext.Database.Migrate();
            }

            return host;
        }

        public static IHost SeedDatabase(this IHost host)
        {
            using (var scope = host.Services.CreateScope())
            {
                using var appContext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();

                if(appContext.Todos.FirstOrDefault() is null)
                {
                    for (int i = 0; i < 60; i++)
                    {
                        var todo = new Todo($"task: {i}");

                        appContext.Todos.Add(todo);
                    }
                }

                appContext.SaveChanges();
            }

            return host;
        }
    }
}
