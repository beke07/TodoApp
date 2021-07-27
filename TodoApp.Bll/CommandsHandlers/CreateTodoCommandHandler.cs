using MediatR;
using System.Threading;
using System.Threading.Tasks;
using TodoApp.Bll.Commands;
using TodoApp.Dal.Entities;
using TodoApp.Dal.Repositories.Interfaces;

namespace TodoApp.Bll.CommandsHandlers
{
    public class CreateTodoCommandHandler : IRequestHandler<CreateTodoCommand, int>
    {
        private readonly IRepository<Todo> repository;

        public CreateTodoCommandHandler(IRepository<Todo> repository)
        {
            this.repository = repository;
        }

        public async Task<int> Handle(CreateTodoCommand request, CancellationToken cancellationToken)
        {
            var todo = new Todo(request.Text);

            await repository.AddAsync(todo);

            return todo.Id;
        }
    }
}
