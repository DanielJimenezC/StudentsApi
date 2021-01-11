using Students.Application.Communication;
using Students.Application.Communication.Request;
using Students.Application.Communication.Response;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Students.Application.Interface
{
    public interface IUserServices
    {
        Task<JsonResult<LoginResponse>> SignIn(LoginRequest loginRequest);
        Task<JsonResult<LoginResponse>> SignUp(SignUpRequest signUpRequest);
    }
}
