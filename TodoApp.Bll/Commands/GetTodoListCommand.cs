using MediatR;
using TodoApp.Bll.ViewModels;

namespace TodoApp.Bll.Commands
{
    public class GetTodoListCommand : IRequest<ListViewModel>
    {
        public GetTodoListCommand(FilterDto filter)
        {
            Filter = filter;
        }

        public FilterDto Filter { get; set; }
    }
}
