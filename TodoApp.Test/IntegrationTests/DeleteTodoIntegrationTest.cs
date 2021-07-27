using NUnit.Framework;
using System;
using System.Threading.Tasks;
using TodoApp.Bll.Commands;
using TodoApp.Dal.Constants;

namespace TodoApp.Test.IntegrationTests
{
    public class DeleteTodoIntegrationTest : MediatorIntegrationTestBase
    {
        [Test]
        public override async Task Test()
        {
            var id = await mediator.Send(new CreateTodoCommand() { Text = "text" });

            await mediator.Send(new DeleteTodoCommand(id));

            Assert.ThrowsAsync<Exception>(async () => await mediator.Send(new GetTodoCommand(id)), ErrorMessages.Entity_Not_Found);
        }
    }
}
