using NUnit.Framework;
using System;
using System.Threading.Tasks;
using TodoApp.Dal.Constants;
using TodoApp.Dal.Entities;

namespace TodoApp.Test.IntegrationTests.Repository
{
    public class DeleteTodoRepositoryIntegrationTest : RepositoryIntegrationTestBase<Todo>
    {
        [Test]
        public override async Task Test()
        {
            const string text = "text";

            var todo = new Todo(text);

            todo = await repository.AddAsync(todo);

            await repository.DeleteAsync(todo.Id);

            Assert.ThrowsAsync<Exception>(async () => await repository.GetAsync(todo.Id), ErrorMessages.Entity_Not_Found);
        }
    }
}
