using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Threading.Tasks;
using TodoApp.Data;

namespace TodoApp.Test
{
    public class TestBase
    {
        private readonly IConfiguration configuration;
        protected readonly ServiceProvider serviceProvider;
        protected readonly ApplicationDbContext dbContext;

        public TestBase()
        {
            configuration = new ConfigurationBuilder()
                .AddJsonFile("appsettings.Test.json")
                .Build();

            serviceProvider = new ServiceCollection()
                .AddContext(configuration)
                .AddLogging()
                .AddRepositories()
                .AddMediatR()
                .BuildServiceProvider();

            dbContext = MigrateTestDb();
        }

        protected async Task ClearTodosAsync()
        {
            dbContext.Todos.RemoveRange(dbContext.Todos);

            await dbContext.SaveChangesAsync();
        }

        private ApplicationDbContext MigrateTestDb()
        {
            var context = serviceProvider.GetRequiredService<ApplicationDbContext>();

            context.Database.Migrate();

            return context;
        }
    }
}
