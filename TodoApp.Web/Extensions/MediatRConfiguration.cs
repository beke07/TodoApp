using MediatR;
using System.Reflection;
using TodoApp.Bll.Commands;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class MediatRConfiguration
    {
        public static IServiceCollection AddMediatR(this IServiceCollection services)
        {
            services.AddMediatR(
                Assembly.GetExecutingAssembly(),
                typeof(CreateTodoCommand).Assembly);

            return services;
        }
    }
}
