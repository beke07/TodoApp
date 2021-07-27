using MediatR;

namespace TodoApp.Bll.Commands
{
    public class UpdateTodoCommand : IRequest
    {
        public int Id { get; set; }

        public string Text { get; set; }

        public bool? IsDone { get; set; }
    }
}
