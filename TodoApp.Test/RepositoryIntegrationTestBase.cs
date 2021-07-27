using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework;
using System.Threading.Tasks;
using TodoApp.Dal.Entities;
using TodoApp.Dal.Repositories.Interfaces;

namespace TodoApp.Test
{
    public abstract class RepositoryIntegrationTestBase<T> : TestBase
        where T : EntityBase
    {
        protected IRepository<T> repository;

        [SetUp]
        public async Task Setup()
        {
            repository = serviceProvider.GetService<IRepository<T>>();

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
