using Students.Domain.Entity;
using Students.Domain.Interface;
using Students.Infraestructure.Context;
using System;
using System.Collections.Generic;
using System.Text;

namespace Students.Infraestructure.Repository
{
    public class StudentRepository : GenericRepository<Student, int>, IStudentRepository
    {
        public StudentRepository(AppDbContext context) : base(context) { }
    }
}
