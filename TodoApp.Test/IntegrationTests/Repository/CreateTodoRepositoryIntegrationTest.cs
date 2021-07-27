using NUnit.Framework;
using System;
using System.Threading.Tasks;
using TodoApp.Dal.Entities;

namespace TodoApp.Test.IntegrationTests.Repository
{
    public class CreateTodoRepositoryIntegrationTest : RepositoryIntegrationTestBase<Todo>
    {
        [Test]
        public override async Task Test()
        {
            const string text = "text";

            var todo = new Todo(text);

            todo = await repository.AddAsync(todo);

            var getTodo = await repository.GetAsync(todo.Id);

            Assert.AreEqual(getTodo.Text, text);
            Assert.AreEqual(getTodo.IsDeleted, false);
            Assert.AreEqual(getTodo.CreatedAt.Date, DateTime.Now.Date);
        }
    }
}
