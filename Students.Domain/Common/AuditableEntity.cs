using System;

namespace Students.Domain.Common
{
    public abstract class AuditableEntity
    {
        public bool IsActive { get; set; }
        public DateTime CreateAt { get; set; }
        public DateTime ModifiedAt { get; set; }
    }
}
