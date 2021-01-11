using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Students.Application.Security.JsonWebToken
{
    public interface IJWTFactory
    {
        Task<string> GetJWT(string loginRequest);
    }
}
