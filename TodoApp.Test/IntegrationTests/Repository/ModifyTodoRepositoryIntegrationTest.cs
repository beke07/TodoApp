using NUnit.Framework;
using System;
using System.Threading.Tasks;
using TodoApp.Dal.Entities;

namespace TodoApp.Test.IntegrationTests.Repository
{
    public class ModifyTodoRepositoryIntegrationTest : RepositoryIntegrationTestBase<Todo>
    {
        [Test]
        public override async Task Test()
        {
            const string text = "text";
            const string updatedText = "updated-text";

            var todo = new Todo(text);

            todo = await repository.AddAsync(todo);

            todo.Update(updatedText, true);

            todo = await repository.UpdateAsync(todo);

            var getTodo = await repository.GetAsync(todo.Id);

            Assert.AreEqual(getTodo.IsDone, true);
            Assert.AreEqual(getTodo.ModifiedAt?.Date, DateTime.Now.Date);
        }
    }
}
