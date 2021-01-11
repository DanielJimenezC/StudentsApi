using Microsoft.Extensions.DependencyInjection;
using Students.Application.Interface;
using Students.Application.Security.JsonWebToken;
using Students.Application.Service;
using Students.Domain.Entity;
using Students.Domain.Interface;
using Students.Infraestructure.Repository;

namespace Students.Infraestructure.Extensions
{
    public class DependencyInjection
    {
        public static void RegisterServices(IServiceCollection services)
        {
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IJWTFactory, JWTFactory>();

            services.AddScoped<IRepository<Student, int>, GenericRepository<Student, int>>();
            services.AddScoped<IRepository<User, int>, GenericRepository<User, int>>();
            services.AddScoped<IStudentRepository, StudentRepository>();
            services.AddScoped<IUserRepository, UserRepository>();

            services.AddScoped<IStudentService, StudentService>();
            services.AddScoped<IUserServices, UserService>();
        }
    }
}
