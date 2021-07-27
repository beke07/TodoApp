using MediatR;
using System.Threading;
using System.Threading.Tasks;
using TodoApp.Bll.Commands;
using TodoApp.Dal.Entities;
using TodoApp.Dal.Repositories.Interfaces;

namespace TodoApp.Bll.CommandsHandlers
{
    public class UpdateTodoCommandHandler : IRequestHandler<UpdateTodoCommand>
    {
        private readonly IRepository<Todo> repository;

        public UpdateTodoCommandHandler(IRepository<Todo> repository)
        {
            this.repository = repository;
        }

        public async Task<Unit> Handle(UpdateTodoCommand request, CancellationToken cancellationToken)
        {
            var todo = await repository.GetAsync(request.Id);

            todo.Update(request.Text, request.IsDone);

            await repository.UpdateAsync(todo);

            return Unit.Value;
        }
    }
}
