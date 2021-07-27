using MediatR;

namespace TodoApp.Bll.Commands
{
    public class CreateTodoCommand : IRequest<int>
    {
        public string Text { get; set; }
    }
}
