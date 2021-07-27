using MediatR;
using NUnit.Framework;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;

namespace TodoApp.Test
{
    public abstract class MediatorIntegrationTestBase : TestBase
    {
        protected IMediator mediator;

        [SetUp]
        public async Task Setup()
        {
            mediator = serviceProvider.GetService<IMediator>();

            await ClearTodosAsync();
        }

        public abstract Task Test();

        [TearDown]
        public async Task TearDown()
        {
            await ClearTodosAsync();
        }

        
    }
}
