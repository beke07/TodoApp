using Microsoft.Extensions.Logging;
using TodoApp.Dal.Entities;
using TodoApp.Data;

namespace TodoApp.Dal.Repositories
{
    public class TodoRepository : Repository<Todo>
    {
        public TodoRepository(ApplicationDbContext dbContext, ILogger<TodoRepository> logger) : base(dbContext, logger)
        { }
    }
}
