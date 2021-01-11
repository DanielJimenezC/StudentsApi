using Students.Domain.Common;

namespace Students.Domain.Entity
{
    public class User : AuditableEntity
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
