using AutoMapper;
using Students.Application.Communication.Request;
using Students.Application.Communication.Response;
using Students.Application.Security.Encript;
using Students.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Students.Infraestructure.Mapper.Profiles
{
    public class UserProfile : Profile
    {  
        public UserProfile()
        {
            CreateMap<User, LoginResponse>()
                .ForMember(l => l.Username, l => l.MapFrom(u => u.Username));

            CreateMap<SignUpRequest, User>()
                .ForMember(u => u.Username, s => s.MapFrom(s => s.Username))
                .ForMember(u => u.Password, s => s.MapFrom(s => Encript.EncriptText(s.Password)));
        }
    }
}
