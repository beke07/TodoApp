using System.Linq;
using System.Threading.Tasks;
using TodoApp.Dal.Entities.Interfaces;

namespace TodoApp.Dal.Repositories.Interfaces
{
    public interface IRepository<T> where T : class, IEntity
    {
        Task<IQueryable<T>> GetAllAsync();

        Task<T> GetAsync(int id);

        Task<T> AddAsync(T entity);

        Task<T> UpdateAsync(T entity);

        Task<int> DeleteAsync(int id);
    }
}
