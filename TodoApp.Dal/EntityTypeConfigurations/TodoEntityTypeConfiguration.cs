using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TodoApp.Dal.Entities;

namespace TodoApp.Dal.EntityTypeConfigurations
{
    public class TodoEntityTypeConfiguration : IEntityTypeConfiguration<Todo>
    {
        public void Configure(EntityTypeBuilder<Todo> builder)
        {
            builder.HasQueryFilter(p => !p.IsDeleted);
        }
    }
}

