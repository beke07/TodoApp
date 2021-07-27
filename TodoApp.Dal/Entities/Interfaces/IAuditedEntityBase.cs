using System;

namespace TodoApp.Dal.Entities.Interfaces
{
    public interface IAuditedEntityBase : IEntity
    {
        public DateTime CreatedAt { get; set; }

        public DateTime? ModifiedAt { get; set; }
    }
}
