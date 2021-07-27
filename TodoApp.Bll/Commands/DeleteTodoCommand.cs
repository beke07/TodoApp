using MediatR;

namespace TodoApp.Bll.Commands
{
    public class DeleteTodoCommand : IRequest
    {
        public DeleteTodoCommand(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
    }
}
