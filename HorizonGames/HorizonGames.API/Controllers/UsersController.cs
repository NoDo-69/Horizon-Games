using Microsoft.AspNetCore.Mvc;
using System.Net;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using HorizonGames.API.Data;
using HorizonGames.API.Models;
using HorizonGames.API.Models.DTOS;

namespace HorizonGames.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly GameDbContext _context;
        private readonly IMapper _mapper;
        private APIResponse _response;

        public UsersController(GameDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
            _response = new();
        }

        private bool VerifyPassword(string enteredPassword, string storedPassword)
        {
            enteredPassword = storedPassword;
            return string.Equals(enteredPassword, storedPassword);
        }

        private async Task<bool> IsEmailAlreadyRegistered(string email)
        {
            return await _context.Users.AnyAsync(u => u.Email == email);
        }

        private async Task<bool> IsCorrectEmailFormat(string email)
        {
            if (email == null)
            {
                return false;
            }
            return email.StartsWith("") && email.Contains("@") && email.EndsWith("gmail.com");
        }
        [HttpGet]
        public async Task<ActionResult<APIResponse>> GetUsers()
        {
            try
            {
                List<User> users = await _context.Users.ToListAsync();
                if (users.Count == 0)
                {
                    _response.StatusCode = HttpStatusCode.NoContent;
                    _response.IsSuccess = false;
                    _response.Message = "No Users";
                    _response.Result = null;

                    return _response;
                }

                List<UsersDTO> result = _mapper.Map<List<UsersDTO>>(users);
                if (result == null)
                {
                    _response.StatusCode = HttpStatusCode.BadRequest;
                    _response.IsSuccess = false;
                    _response.Message = "Bad Request";
                    _response.Result = null;

                    return _response;
                }

                _response.StatusCode = HttpStatusCode.OK;
                _response.IsSuccess = true;
                _response.Result = result;
            }
            catch (Exception ex)
            {
                _response.StatusCode = HttpStatusCode.BadRequest;
                _response.IsSuccess = false;
                _response.Message = ex.Message;
            }
            return _response;
        }
        [HttpPost("userRegister")]
        public async Task<ActionResult<APIResponse>> RegisterUser([FromForm] CreateUserDTO registerUser)
        {
            try
            {
                if (registerUser is null)
                {
                    _response.StatusCode = HttpStatusCode.BadRequest;
                    _response.IsSuccess = false;
                    _response.Message = "Incorrect Data Passed";
                    _response.Result = null;
                    return _response;
                }
                if (await IsEmailAlreadyRegistered(registerUser.Email))
                {
                    _response.StatusCode = HttpStatusCode.Conflict;
                    _response.IsSuccess = false;
                    _response.Message = "Email is already registered";
                    _response.Result = null;
                    return _response;
                }
                if (await IsEmailAlreadyRegistered(registerUser.UserName))
                {
                    _response.StatusCode = HttpStatusCode.Conflict;
                    _response.IsSuccess = false;
                    _response.Message = "Username is already In Use";
                    _response.Result = null;
                    return _response;
                }
                if (!await IsCorrectEmailFormat(registerUser.Email))
                {
                    _response.StatusCode = HttpStatusCode.BadRequest;
                    _response.IsSuccess = false;
                    _response.Message = "Incorrect email format";
                    _response.Result = null;
                    return _response;
                }

                User newUser = _mapper.Map<User>(registerUser);
                newUser.Role = UserRole.Customer;


                await _context.Users.AddAsync(newUser);
                await _context.SaveChangesAsync();

                _response.StatusCode = HttpStatusCode.Created;
                _response.IsSuccess = true;
                _response.Result = newUser;
            }
            catch (Exception ex)
            {
                _response.StatusCode = HttpStatusCode.InternalServerError;
                _response.IsSuccess = false;
                _response.Message = ex.Message;
                _response.Result = null;
            }
            return _response;
        }
        [HttpPost("userLogin")]
        public async Task<ActionResult<APIResponse>> UserLogin(LoginUserDTO loginUser)
        {
            try
            {
                if (loginUser == null || string.IsNullOrEmpty(loginUser.UserName) || string.IsNullOrEmpty(loginUser.Password))
                {
                    _response.StatusCode = HttpStatusCode.BadRequest;
                    _response.IsSuccess = false;
                    _response.Result = null;
                    _response.Message = "Bad Request";
                }
                User user = await _context.Users.FirstOrDefaultAsync(u => u.UserName == loginUser.UserName);
                if (user == null)
                {
                    _response.StatusCode = HttpStatusCode.NotFound;
                    _response.IsSuccess = false;
                    _response.Message = "User not found";
                    _response.Result = null;
                    return _response;
                }
                if (!VerifyPassword(loginUser.Password, user.Password))
                {
                    _response.StatusCode = HttpStatusCode.Unauthorized;
                    _response.IsSuccess = false;
                    _response.Message = "Invalid password";
                    _response.Result = null;
                    return _response;
                }

                _response.StatusCode = HttpStatusCode.OK;
                _response.IsSuccess = true;
                _response.Message = "Login successful";
                _response.Result = user;
            }
            catch (Exception ex)
            {
                _response.StatusCode = HttpStatusCode.InternalServerError;
                _response.IsSuccess = false;
                _response.Message = ex.Message;
                _response.Result = null;
            }
            return _response;
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<APIResponse>> DeleteUser(int id)
        {
            try
            {
                if (id <= 0)
                {
                    _response.StatusCode = HttpStatusCode.BadRequest;
                    _response.IsSuccess = false;
                    _response.Message = "Incorrect Data Passed";
                    _response.Result = null;
                    return _response;
                }
                User result = await _context.Users.FirstOrDefaultAsync(x => x.Id == id);

                if (result == null)
                {
                    _response.StatusCode = HttpStatusCode.BadRequest;
                    _response.IsSuccess = false;
                    _response.Result = null;
                    return _response;
                }
                _context.Users.Remove(result);
                await _context.SaveChangesAsync();

                _response.StatusCode = HttpStatusCode.OK;
                _response.IsSuccess = true;
                _response.Result = result;


            }
            catch (Exception ex)
            {
                _response.StatusCode = HttpStatusCode.InternalServerError;
                _response.IsSuccess = false;
                _response.Message = ex.Message;
            }
            return _response;
        }
    }
}
