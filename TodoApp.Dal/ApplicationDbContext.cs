using Microsoft.EntityFrameworkCore;
using TodoApp.Dal.Entities;
using TodoApp.Dal.EntityTypeConfigurations;

namespace TodoApp.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(TodoEntityTypeConfiguration).Assembly);
        }

        public DbSet<Todo> Todos { get; set; }
    }
}
