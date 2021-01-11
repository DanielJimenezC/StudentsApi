using Students.Domain.Common;

namespace Students.Domain.Entity
{
    public class Student : AuditableEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public int Phone { get; set; }
    }
}
