using NUnit.Framework;
using System.Threading.Tasks;
using TodoApp.Bll.Commands;

namespace TodoApp.Test.IntegrationTests
{
    public class CreateTodoIntegrationTest : MediatorIntegrationTestBase
    {
        [Test]
        public override async Task Test()
        {
            const string text = "text";

            var id = await mediator.Send(new CreateTodoCommand() { Text = text });

            var todo = await mediator.Send(new GetTodoCommand(id));

            Assert.AreEqual(todo.Text, text);
            Assert.AreEqual(todo.IsDone, false);
        }
    }
}
