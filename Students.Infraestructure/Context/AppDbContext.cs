using Microsoft.EntityFrameworkCore;
using Students.Domain.Entity;

namespace Students.Infraestructure.Context
{
    public partial class AppDbContext : DbContext
    {
        public DbSet<Student> Students { get; set; }
        public DbSet<User> Users { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
    }
}
