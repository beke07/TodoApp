using NUnit.Framework;
using System.Threading.Tasks;
using TodoApp.Bll.Commands;

namespace TodoApp.Test.IntegrationTests
{
    public class UpdateTodoIntegrationTest : MediatorIntegrationTestBase
    {
        [Test]
        public override async Task Test()
        {
            const string text = "text";
            const string updatedText = "updated-text";

            var id = await mediator.Send(new CreateTodoCommand() { Text = text });

            await mediator.Send(new UpdateTodoCommand() { Id = id, Text = updatedText, IsDone = true });

            var todo = await mediator.Send(new GetTodoCommand(id));

            Assert.AreEqual(todo.Text, updatedText);
            Assert.AreEqual(todo.IsDone, true);
        }
    }
}
