using Students.Domain.Entity;
using Students.Domain.Interface;
using Students.Infraestructure.Context;

namespace Students.Infraestructure.Repository
{
    public class UserRepository : GenericRepository<User, int>, IUserRepository
    {  
        public UserRepository(AppDbContext context) : base(context) { }
    }
}
