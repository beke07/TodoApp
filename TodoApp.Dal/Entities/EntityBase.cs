using System;
using TodoApp.Dal.Entities.Interfaces;

namespace TodoApp.Dal.Entities
{
    public abstract class EntityBase : IAuditedEntityBase
    {
        public int Id { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime? ModifiedAt { get; set; }

        public bool IsDeleted { get; set; }

        internal void Delete() => IsDeleted = true;

        internal void Restore() => IsDeleted = false;
    }
}
