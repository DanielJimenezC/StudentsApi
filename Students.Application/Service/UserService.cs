using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Students.Application.Communication;
using Students.Application.Communication.Request;
using Students.Application.Communication.Response;
using Students.Application.Interface;
using Students.Application.Security.Encript;
using Students.Application.Security.JsonWebToken;
using Students.Application.Validators;
using Students.Domain.Entity;
using Students.Domain.Interface;
using System;
using System.Threading.Tasks;

namespace Students.Application.Service
{
    public class UserService : IUserServices
    {
        private readonly IJWTFactory _jWTFactory;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UserService(IJWTFactory jWTFactory, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _jWTFactory = jWTFactory;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<JsonResult<LoginResponse>> SignIn(LoginRequest loginRequest)
        {
            User user = new User();
            user = await _unitOfWork.UserRepository
                .Find(x => x.Username.Equals(loginRequest.Username))
                .FirstOrDefaultAsync();
            if (user is null || user.IsActive == false)
                return new JsonResult<LoginResponse>(false, null, "The user doesn't exist", 1);
            if (user.Password.Trim() != Encript.EncriptText(loginRequest.Password.Trim()))
                return new JsonResult<LoginResponse>(false, null, "Wrong Password", 2);
            var token = await _jWTFactory.GetJWT(loginRequest.Username);
            var loginResponse = _mapper.Map<User, LoginResponse>(user);
            loginResponse.Token = token;
            return new JsonResult<LoginResponse>(true, loginResponse, "Success", 0);
        }

        public async Task<JsonResult<LoginResponse>> SignUp(SignUpRequest signUpRequest)
        {
            var userExist = await _unitOfWork.UserRepository
                .Find(x => x.Username.Equals(signUpRequest.Username))
                .ToListAsync();
            if (userExist.Count > 0)
                return new JsonResult<LoginResponse>(false, null, "The user already exist", 3);
            var actualTime = DateTime.Now;
            var user = _mapper.Map<SignUpRequest, User>(signUpRequest);
            user.IsActive = true;
            user.CreateAt = actualTime;
            user.ModifiedAt = actualTime;
            var result = await _unitOfWork.UserRepository.AddAsync(user, new UserValidator());
            string error = "";
            foreach(var er in result.Errors)
            {
                error += er.ErrorMessage + '\n';
            }
            if (!result.IsValid)
                return new JsonResult<LoginResponse>(false, null, error, 4);
            await _unitOfWork.SaveChangesAsync();
            var responseUser = await _unitOfWork.UserRepository.Find(x => x.Username.Equals(signUpRequest.Username)).FirstOrDefaultAsync();
            var loginResponse = _mapper.Map<User, LoginResponse>(responseUser);
            return new JsonResult<LoginResponse>(true, loginResponse, "Success", 0);
        }
    }
}
