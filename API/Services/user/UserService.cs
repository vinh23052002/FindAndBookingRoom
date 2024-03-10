using API.Dtos.User;
using API.Exceptions;
using API.Models;
using API.Repositoriest.role;
using API.Repositoriest.user;
using API.Repositoriest.ward;
using API.Response;
using AutoMapper;
using FluentValidation;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Net;
using System.Security.Claims;
using System.Text;

namespace API.Services.user
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        private readonly IRoleRepository _roleRepository;
        private readonly IConfiguration _config;
        private readonly IWardRepository _wardRepository;
        private readonly IValidator<UserRequest> _validatorRequsest;
        private readonly IValidator<UserUpdateProfileRequest> _validatorUpdateProfile;

        public UserService(IUserRepository userRepository, IMapper mapper, IRoleRepository roleRepository, IConfiguration config, IWardRepository wardRepository, IValidator<UserRequest> validatorRequsest, IValidator<UserUpdateProfileRequest> validatorUpdateProfile)
        {
            _userRepository = userRepository;
            _mapper = mapper;
            _roleRepository = roleRepository;
            _config = config;
            _wardRepository = wardRepository;
            _validatorRequsest = validatorRequsest;
            _validatorUpdateProfile = validatorUpdateProfile;
        }

        private string GenerateJSONWebToken(User userInfo)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            // add user info to token
            var claims = new[]
            {
                new Claim(ClaimTypes.Role,userInfo.roleID.ToString()),
                new Claim("userID",userInfo.userID)
            };
            var token = new JwtSecurityToken(_config["Jwt:Issuer"],
                        _config["Jwt:Audience"],
                        claims,
                        expires: DateTime.Now.AddMinutes(120),
                        signingCredentials: credentials);
            return new JwtSecurityTokenHandler().WriteToken(token);



        }
        public async Task<SuccessResponse> Login(UserLoginRequest request)
        {

            var user = await _userRepository.Login(request.userID, request.password);
            if (user == null || user.deleteAt < DateTime.Now)
            {
                throw new MyException((int)HttpStatusCode.NotFound, "User not found");
            }

            var tokenString = GenerateJSONWebToken(user);
            return new SuccessResponse
            {
                Message = "Login success",
                Data = new
                {
                    token = tokenString,
                }
            };
        }

        public async Task<SuccessResponse> Register(UserRequest request)
        {
            // validate model
            var validationResult = await _validatorRequsest.ValidateAsync(request);
            if (!validationResult.IsValid)
            {
                var errors = validationResult.Errors
                    .GroupBy(e => e.PropertyName)
                    .Select(g => g.First())
                    .ToDictionary(failure => failure.PropertyName, failure => failure.ErrorMessage);
                return new SuccessResponse
                {
                    Message = "Create user failed",
                    Errors = new ErrorResponse
                    {
                        StatusCode = (int)HttpStatusCode.BadRequest,
                        Data = errors
                    }
                };
            }

            // check modelstate is valid
            if (request == null)
            {
                throw new MyException((int)HttpStatusCode.NotFound, "User not found");
            }
            if (await _userRepository.GetUserById(request.userID) != null)
            {
                throw new MyException((int)HttpStatusCode.NotFound, "User already exists");
            }
            if (await _userRepository.GetUserByEmail(request.email) != null)
            {
                throw new MyException((int)HttpStatusCode.NotFound, "Email already exists");
            }
            if (await _userRepository.GetUserByPhone(request.phone) != null)
            {
                throw new MyException((int)HttpStatusCode.NotFound, "Phone already exists");
            }
            if (await _wardRepository.GetWard(request.wardID) == null)
            {
                throw new MyException((int)HttpStatusCode.NotFound, "Ward not found");
            }
            var user = _mapper.Map<User>(request);
            var role = await _roleRepository.GetById(request.roleID);
            if (role == null)
            {
                throw new MyException((int)HttpStatusCode.NotFound, "Role not found");
            }
            user.Role = role;
            await _userRepository.Add(user);
            return new SuccessResponse
            {
                Data = _mapper.Map<UserResponse>(user)
            };
        }

        public async Task<SuccessResponse> GetUserById(string id)
        {
            var user = await _userRepository.GetUserById(id);
            if (user == null)
            {
                throw new MyException((int)HttpStatusCode.NotFound, "User not found");
            }
            return new SuccessResponse
            {
                Data = _mapper.Map<UserResponse>(user)
            };
        }

        public async Task<SuccessResponse> UpdateUser(UserRequest request)
        {
            // validate model
            var validationResult = await _validatorRequsest.ValidateAsync(request);
            if (!validationResult.IsValid)
            {
                var errors = validationResult.Errors
                    .GroupBy(e => e.PropertyName)
                    .Select(g => g.First())
                    .ToDictionary(failure => failure.PropertyName, failure => failure.ErrorMessage);
                return new SuccessResponse
                {
                    Message = "Create user failed",
                    Errors = new ErrorResponse
                    {
                        StatusCode = (int)HttpStatusCode.BadRequest,
                        Data = errors
                    }
                };
            }
            //
            var user = await _userRepository.GetUserById(request.userID);
            if (user == null)
            {
                throw new MyException((int)HttpStatusCode.NotFound, "User not found");
            }
            var userByEmail = await _userRepository.GetUserByEmail(request.email);
            if (userByEmail != null && !userByEmail.email.Equals(request.email))
            {
                throw new MyException((int)HttpStatusCode.NotFound, "Email already exists");
            }

            var userByPhone = await _userRepository.GetUserByPhone(request.phone);
            if (userByPhone != null && !userByPhone.phone.Equals(request.phone))
            {
                throw new MyException((int)HttpStatusCode.NotFound, "Phone already exists");
            }
            if (await _roleRepository.GetById(request.roleID) == null)
            {
                throw new MyException((int)HttpStatusCode.NotFound, "Role not found");
            }
            if (await _wardRepository.GetWard(request.wardID) == null)
            {
                throw new MyException((int)HttpStatusCode.NotFound, "Ward not found");
            }
            _mapper.Map(request, user);
            await _userRepository.Update(user);
            return new SuccessResponse
            {
                Data = _mapper.Map<UserResponse>(user)
            };
        }

        public async Task<SuccessResponse> UpdateProfile(UserUpdateProfileRequest request)
        {
            // validate model
            var validationResult = await _validatorUpdateProfile.ValidateAsync(request);
            if (!validationResult.IsValid)
            {
                var errors = validationResult.Errors
                    .GroupBy(e => e.PropertyName)
                    .Select(g => g.First())
                    .ToDictionary(failure => failure.PropertyName, failure => failure.ErrorMessage);
                return new SuccessResponse
                {
                    Message = "Update user failed",
                    Errors = new ErrorResponse
                    {
                        StatusCode = (int)HttpStatusCode.BadRequest,
                        Data = errors
                    }
                };
            }
            var user = await _userRepository.GetUserById(request.userID);
            if (user == null)
            {
                throw new MyException((int)HttpStatusCode.NotFound, "User not found");
            }
            var userByEmail = await _userRepository.GetUserByEmail(request.email);
            if (userByEmail != null && !userByEmail.email.Equals(request.email))
            {
                throw new MyException((int)HttpStatusCode.NotFound, "Email already exists");
            }

            var userByPhone = await _userRepository.GetUserByPhone(request.phone);
            if (userByPhone != null && !userByPhone.phone.Equals(request.phone))
            {
                throw new MyException((int)HttpStatusCode.NotFound, "Phone already exists");
            }
            if (await _wardRepository.GetWard(request.wardID) == null)
            {
                throw new MyException((int)HttpStatusCode.NotFound, "Ward not found");
            }

            _mapper.Map(request, user);
            await _userRepository.Update(user);
            return new SuccessResponse
            {
                Data = _mapper.Map<UserResponse>(user)
            };
        }

        public async Task<SuccessResponse> ChangeStatus(string id)
        {
            var user = await _userRepository.GetUserById(id);
            if (user == null)
            {
                throw new MyException((int)HttpStatusCode.NotFound, "User not found");
            }
            await _userRepository.ChangeStatus(id);
            return new SuccessResponse
            {
                Data = _mapper.Map<UserResponse>(user)
            };
        }

        public async Task<SuccessResponse> GetUsers()
        {
            var users = await _userRepository.GetAll();
            return new SuccessResponse
            {
                Data = _mapper.Map<List<UserResponse>>(users)
            };
        }

    }
}
