using Students.Application.Communication;
using Students.Application.Communication.Request;
using Students.Application.Communication.Response;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Students.Application.Interface
{
    public interface IStudentService
    {
        public Task<JsonResult<StudentResponse>> UpdateStudent(int id, StudentRequest studentRequest);
        public Task<JsonResult<StudentResponse>> CreateStudent(StudentRequest studentRequest);
        public Task<JsonResult<List<StudentResponse>>> GetAllStudents();
        public Task<JsonResult<StudentResponse>> GetStudentById(int id);
        public Task<JsonResult<string>> DeleteStudent(int id);
        public Task<JsonResult<List<StudentResponse>>> GetSearchStudent(string search);
    }
}
