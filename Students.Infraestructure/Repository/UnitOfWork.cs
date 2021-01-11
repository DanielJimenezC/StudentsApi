using Students.Domain.Interface;
using Students.Infraestructure.Context;
using System.Threading.Tasks;

namespace Students.Infraestructure.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context;
        private readonly IStudentRepository _studentRepository;
        private readonly IUserRepository _userRepository;

        public UnitOfWork(AppDbContext context)
        {
            _context = context;
        }

        public IStudentRepository StudentRepository => _studentRepository ?? new StudentRepository(_context);
        public IUserRepository UserRepository => _userRepository ?? new UserRepository(_context);

        public async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            if (_context != null)
            {
                _context.Dispose();
            }
        }
    }
}
