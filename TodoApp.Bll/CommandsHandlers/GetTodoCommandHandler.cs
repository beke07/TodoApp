using MediatR;
using System.Threading;
using System.Threading.Tasks;
using TodoApp.Bll.Commands;
using TodoApp.Bll.ViewModels;
using TodoApp.Dal.Entities;
using TodoApp.Dal.Repositories.Interfaces;

namespace TodoApp.Bll.CommandsHandlers
{
    public class GetTodoCommandHandler : IRequestHandler<GetTodoCommand, TodoItemViewModel>
    {
        private readonly IRepository<Todo> repository;

        public GetTodoCommandHandler(IRepository<Todo> repository)
        {
            this.repository = repository;
        }

        public async Task<TodoItemViewModel> Handle(GetTodoCommand request, CancellationToken cancellationToken)
        {
            var todo = await repository.GetAsync(request.Id);

            return new TodoItemViewModel()
            {
                Id = todo.Id,
                IsDone = todo.IsDone,
                Text = todo.Text
            };
        }
    }
}
