using NUnit.Framework;
using System;
using System.Threading.Tasks;
using TodoApp.Bll.Commands;
using TodoApp.Dal.Constants;

namespace TodoApp.Test.IntegrationTests
{
    public class GetTodoIntegrationTest : MediatorIntegrationTestBase
    {
        [Test]
        public override async Task Test()
        {
            Assert.ThrowsAsync<Exception>(async () => await mediator.Send(new GetTodoCommand(-1)), ErrorMessages.Id_Must_Greater_Than_0);
        }
    }
}
