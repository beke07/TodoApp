using MediatR;
using System.Threading;
using System.Threading.Tasks;
using TodoApp.Bll.Commands;
using TodoApp.Dal.Entities;
using TodoApp.Dal.Repositories.Interfaces;

namespace TodoApp.Bll.CommandsHandlers
{
    public class DeleteTodoCommandHandler : IRequestHandler<DeleteTodoCommand>
    {
        private readonly IRepository<Todo> repository;

        public DeleteTodoCommandHandler(IRepository<Todo> repository)
        {
            this.repository = repository;
        }

        public async Task<Unit> Handle(DeleteTodoCommand request, CancellationToken cancellationToken)
        {
            await repository.DeleteAsync(request.Id);
             
            return Unit.Value;
        }
    }
}
