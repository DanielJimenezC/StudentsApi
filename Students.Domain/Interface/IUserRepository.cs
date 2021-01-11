using Students.Domain.Entity;

namespace Students.Domain.Interface
{
    public interface IUserRepository : IRepository<User, int>
    {
    }
}
