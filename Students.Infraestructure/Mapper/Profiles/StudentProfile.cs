using AutoMapper;
using Students.Application.Communication.Request;
using Students.Application.Communication.Response;
using Students.Domain.Entity;

namespace Students.Infraestructure.Mapper.Profiles
{
    public class StudentProfile : Profile
    {
        public StudentProfile()
        {
            CreateMap<Student, StudentResponse>()
                .ForMember(s => s.Id, sr => sr.MapFrom(s => s.Id))
                .ForMember(s => s.Name, sr => sr.MapFrom(s => s.Name))
                .ForMember(s => s.Phone, sr => sr.MapFrom(s => s.Phone))
                .ForMember(s => s.Email, sr => sr.MapFrom(s => s.Email))
                .ForMember(s => s.Create, sr => sr.MapFrom(s => s.CreateAt.ToString("dddd, dd MMMM yyyy")));

            CreateMap<StudentRequest, Student>()
                .ForMember(s => s.Name, s => s.MapFrom(sr => sr.Name))
                .ForMember(s => s.Phone, s => s.MapFrom(sr => sr.Phone))
                .ForMember(s => s.Email, s => s.MapFrom(sr => sr.Email));
        }
    }
}
