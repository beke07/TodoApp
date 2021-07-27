using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using TodoApp.Bll.Commands;
using TodoApp.Bll.ViewModels;
using TodoApp.Dal.Entities;
using TodoApp.Dal.Repositories.Interfaces;

namespace TodoApp.Bll.CommandsHandlers
{
    public class GetTodoListCommandHandler : IRequestHandler<GetTodoListCommand, ListViewModel>
    {
        private readonly IRepository<Todo> repository;

        public GetTodoListCommandHandler(IRepository<Todo> repository)
        {
            this.repository = repository;
        }

        public async Task<ListViewModel> Handle(GetTodoListCommand request, CancellationToken cancellationToken)
        {
            var query = await repository.GetAllAsync();

            query = FilterQuery(request, query);

            request.Filter.TotalCount = await query.CountAsync();

            query = PageQuery(request, query);

            var list = await MapQueryAsync(query);

            return new ListViewModel()
            {
                List = list,
                Filter = request.Filter
            };
        }

        private async Task<IEnumerable<TodoItemViewModel>> MapQueryAsync(IQueryable<Todo> query)
            => await query.Select(e => new TodoItemViewModel()
            {
                Id = e.Id,
                IsDone = e.IsDone,
                Text = e.Text
            }).ToListAsync();

        private static IQueryable<Todo> PageQuery(GetTodoListCommand request, IQueryable<Todo> query)
                => query
                .Skip(request.Filter.PageIndex * request.Filter.PageSize)
                .Take(request.Filter.PageSize);

        private static IQueryable<Todo> FilterQuery(GetTodoListCommand request, IQueryable<Todo> query)
        {
            if (request.Filter is not null)
            {
                if (request.Filter.IsDone is not null)
                {
                    query = query.Where(e => e.IsDone == request.Filter.IsDone);
                }

                if (!string.IsNullOrEmpty(request.Filter.Text))
                {
                    query = query.Where(e => e.Text.ToLower().Contains(request.Filter.Text.ToLower()));
                }
            }

            return query;
        }
    }
}
