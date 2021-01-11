using Students.Domain.Entity;

namespace Students.Domain.Interface
{
    public interface IStudentRepository : IRepository<Student, int>
    {
    }
}
