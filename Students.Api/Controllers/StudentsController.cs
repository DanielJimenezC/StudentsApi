using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Students.Application.Communication;
using Students.Application.Communication.Request;
using Students.Application.Communication.Response;
using Students.Application.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Students.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private readonly IStudentService _studentService;

        public StudentsController(IStudentService studentService)
        {
            _studentService = studentService;
        }

        [Authorize]
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateStudent(int id, [FromBody] StudentRequest studentRequest)
        {
            var result = await _studentService.UpdateStudent(id, studentRequest);
            return new OkObjectResult(result);
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> CreateStudent([FromBody] StudentRequest studentRequest)
        {
            var result = await _studentService.CreateStudent(studentRequest);
            return new OkObjectResult(result);
        }

        [AllowAnonymous]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetStudentById(int id)
        {
            var result = await _studentService.GetStudentById(id);
            return new OkObjectResult(result);
        }

        [Authorize]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStudent(int id)
        {
            var result = await _studentService.DeleteStudent(id);
            return new OkObjectResult(result);
        }

        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> GetSearchStudent([FromQuery] string name)
        {
            JsonResult<List<StudentResponse>> result;
            if (name is null || name == "")
                result = await _studentService.GetAllStudents();
            else
                result = await _studentService.GetSearchStudent(name);
            return new OkObjectResult(result);
        }
    }
}
