using MediatR;
using TodoApp.Bll.ViewModels;

namespace TodoApp.Bll.Commands
{
    public class GetTodoCommand : IRequest<TodoItemViewModel>
    {
        public GetTodoCommand(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
    }
}
