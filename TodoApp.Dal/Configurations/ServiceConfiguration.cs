using TodoApp.Dal.Entities;
using TodoApp.Dal.Repositories;
using TodoApp.Dal.Repositories.Interfaces;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class ServiceConfiguration
    {
        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<IRepository<Todo>, TodoRepository>();

            return services;
        }
    }
}
