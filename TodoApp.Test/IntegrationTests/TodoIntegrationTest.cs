using MediatR;
using NUnit.Framework;
using Microsoft.Extensions.DependencyInjection;
using TodoApp.Bll.Commands;
using System.Threading.Tasks;
using System;
using TodoApp.Dal.Constants;

namespace TodoApp.Test
{
    public class TodoIntegrationTest : TestBase
    {
        private IMediator mediator;

        [SetUp]
        public async Task Setup()
        {
            mediator = serviceProvider.GetService<IMediator>();

            await ClearTodosAsync();
        }

        [Test]
        public async Task CreateTest()
        {
            const string text = "text";

            var id = await mediator.Send(new CreateTodoCommand(){ Text = text });

            var todo = await mediator.Send(new GetTodoCommand(id));

            Assert.AreEqual(todo.Text, text);
            Assert.AreEqual(todo.IsDone, false);

            await ClearTodosAsync();
        }

        [Test]
        public async Task UpdateTest()
        {
            const string text = "text";
            const string updatedText = "updated-text";

            var id = await mediator.Send(new CreateTodoCommand() { Text = text });

            await mediator.Send(new UpdateTodoCommand() { Id = id, Text = updatedText, IsDone = true});

            var todo = await mediator.Send(new GetTodoCommand(id));

            Assert.AreEqual(todo.Text, updatedText);
            Assert.AreEqual(todo.IsDone, true);

            await ClearTodosAsync();
        }

        [Test]
        public async Task GetTest()
        {
            Assert.ThrowsAsync<Exception>(async () => await mediator.Send(new GetTodoCommand(-1)), ErrorMessages.Id_Must_Greater_Than_0);

            await ClearTodosAsync();
        }

        [Test]
        public async Task DeleteTest()
        {
            var id = await mediator.Send(new CreateTodoCommand() { Text = "text" });

            await mediator.Send(new DeleteTodoCommand(id));

            Assert.ThrowsAsync<Exception>(async () => await mediator.Send(new GetTodoCommand(id)), ErrorMessages.Entity_Not_Found);

            await ClearTodosAsync();
        }

        [TearDown]
        public async Task TearDown()
        {
            await ClearTodosAsync();
        }
    }
}