using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Linq;
using System.Threading.Tasks;
using TodoApp.Dal.Constants;
using TodoApp.Dal.Entities;
using TodoApp.Dal.Repositories.Interfaces;
using TodoApp.Data;

namespace TodoApp.Dal.Repositories
{
    public abstract class Repository<T> : IRepository<T> where T : EntityBase
    {
        private readonly ApplicationDbContext dbContext;
        private readonly ILogger<Repository<T>> logger;

        public Repository(ApplicationDbContext dbContext, ILogger<Repository<T>> logger)
        {
            this.dbContext = dbContext;
            this.logger = logger;
        }

        public Task<IQueryable<T>> GetAllAsync()
        {
            return Task.FromResult(dbContext.Set<T>().Where(e => true));
        }

        public async Task<T> AddAsync(T entity)
        {
            await dbContext.AddAsync(entity);

            entity.CreatedAt = DateTime.Now;

            await dbContext.SaveChangesAsync();

            logger.LogInformation($"{typeof(T).Name} created");

            return entity;
        }

        public async Task<int> DeleteAsync(int id)
        {
            var entity = await GetAsync(id);

            entity.Delete();

            await dbContext.SaveChangesAsync();

            return entity.Id;
        }

        public async Task<T> GetAsync(int id)
        {
            if (id is int.MinValue) throw new Exception(ErrorMessages.Id_Must_Greater_Than_0);

            var entity = await dbContext.Set<T>().SingleOrDefaultAsync(e => e.Id == id);

            if (entity is null || entity.IsDeleted) throw new Exception(ErrorMessages.Entity_Not_Found);

            return entity;
        }

        public async Task<T> UpdateAsync(T entity)
        {
            dbContext.Update(entity);

            entity.ModifiedAt = DateTime.Now;

            await dbContext.SaveChangesAsync();

            return entity;
        }
    }
}
