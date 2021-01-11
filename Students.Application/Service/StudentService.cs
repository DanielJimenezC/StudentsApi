using AutoMapper;
using Students.Application.Communication;
using Students.Application.Communication.Request;
using Students.Application.Communication.Response;
using Students.Application.Interface;
using Students.Application.Validators;
using Students.Domain.Entity;
using Students.Domain.Interface;
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using LinqKit;

namespace Students.Application.Service
{
    public class StudentService : IStudentService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public StudentService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<JsonResult<StudentResponse>> CreateStudent(StudentRequest studentRequest)
        {
            var student = _mapper.Map<StudentRequest, Student>(studentRequest);
            var time = DateTime.Now;
            student.CreateAt = time;
            student.ModifiedAt = time;
            student.IsActive = true;
            var result = await _unitOfWork.StudentRepository.AddAsync(student, new StudentValidator());
            if (!result.IsValid)
                return new JsonResult<StudentResponse>(false, null, "Create Error", 1);
            await _unitOfWork.SaveChangesAsync();
            var response = _mapper.Map<Student, StudentResponse>(student);
            return new JsonResult<StudentResponse>(true, response, "Success", 0);
        }

        public async Task<JsonResult<string>> DeleteStudent(int id)
        {
            var student = await _unitOfWork.StudentRepository
                .Find(x => x.Id == id)
                .FirstOrDefaultAsync();

            if(student is null || student.IsActive == false)
                return new JsonResult<string>(false, null, "The student doesn't exist", 2);

            student.ModifiedAt = DateTime.Now;
            student.IsActive = false;
            var result = await _unitOfWork.StudentRepository.UpdateAsync(student, new StudentValidator());
            if (!result.IsValid)
                return new JsonResult<string>(false, null, "Delete Error", 3);
            await _unitOfWork.SaveChangesAsync();
            return new JsonResult<string>(true, "Success", "Success", 0);
        }

        public async Task<JsonResult<List<StudentResponse>>> GetAllStudents()
        {
            var students = await _unitOfWork.StudentRepository
                .Find(x => x.IsActive == true)
                .ToListAsync();
            var response = _mapper.Map<List<Student>, List<StudentResponse>>(students);
            return new JsonResult<List<StudentResponse>>(true, response, "Success", 0);
        }

        public async Task<JsonResult<List<StudentResponse>>> GetSearchStudent(string search)
        {
            var predicate = PredicateBuilder.New<Student>(true);
            predicate.And(x => x.IsActive == true);
            if (!string.IsNullOrEmpty(search)) 
                predicate.And(x => x.Name.ToLower().Contains(search.ToLower()));
            var students = await _unitOfWork.StudentRepository
                .Find(predicate)
                .OrderBy(x => x.Name)
                .ToListAsync();
            var response = _mapper.Map<List<Student>, List<StudentResponse>>(students);
            return new JsonResult<List<StudentResponse>>(true, response, "Success", 0);
        }

        public async Task<JsonResult<StudentResponse>> GetStudentById(int id)
        {
            var student = await _unitOfWork.StudentRepository
                .Find(x => x.Id == id)
                .FirstOrDefaultAsync();

            if (student is null || student.IsActive == false)
                return new JsonResult<StudentResponse>(false, null, "The student doesn't exist", 2);

            var response = _mapper.Map<Student, StudentResponse>(student);
            return new JsonResult<StudentResponse>(true, response, "Success", 0);
        }

        public async Task<JsonResult<StudentResponse>> UpdateStudent(int id, StudentRequest studentRequest)
        {
            var student = await _unitOfWork.StudentRepository
                .Find(x => x.Id == id)
                .FirstOrDefaultAsync();

            if (student is null || student.IsActive == false)
                return new JsonResult<StudentResponse>(false, null, "The student doesn't exist", 2);

            var studentUpdate = _mapper.Map(studentRequest, student);
            studentUpdate.ModifiedAt = DateTime.Now;
            var result = await _unitOfWork.StudentRepository.UpdateAsync(studentUpdate, new StudentValidator());
            if (!result.IsValid)
                return new JsonResult<StudentResponse>(false, null, "Update Error", 4);
            await _unitOfWork.SaveChangesAsync();
            var response = _mapper.Map<Student, StudentResponse>(studentUpdate);
            return new JsonResult<StudentResponse>(true, response, "Success", 0);
        }
    }
}
