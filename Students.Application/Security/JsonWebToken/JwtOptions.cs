using System;
using System.Collections.Generic;
using System.Text;

namespace Students.Application.Security.JsonWebToken
{
    public class JwtOptions
    {
        public string Issuer { get; set; }
        public string Audience { get; set; }
        public string SecretKey { get; set; }
    }
}
