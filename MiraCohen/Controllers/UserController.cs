using Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Service;

namespace MiraCohen.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly JwtTokenService _jwtTokenService;

        public UserController(IUserService userService, JwtTokenService jwtTokenService)
        {
            _userService = userService;
            _jwtTokenService = jwtTokenService;
        }

        [HttpGet]
        public async Task<List<UserEntities>> GetAll()
        {
            return await _userService.GetAllAsync();
        }
        [HttpGet("GetById/{userId}")]
        public async Task<UserEntities> GetById(string userId)
        {
            return await _userService.GetByIdAsync(userId);
        }
        [HttpDelete("Delete/{userId}")]
        public async Task<bool> Delete(string userId)
        {
            return await _userService.DeleteAsync(userId);
        }

        [HttpPost("Add")]
        public async Task<IActionResult> Add(UserEntities user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var id = await _userService.AddAsync(user);
            return Ok(id);
        }

        [HttpPut("Update")]
        public async Task<UserEntities> Update(UserEntities user)
        {
            return await _userService.UpdateAsync(user);
        }
        [HttpGet("login/{email}/{password}")]
        public async Task<IActionResult> Login(string email, string password)
        {
            var user = await _userService.AuthenticateAsync(email, password);

            if (user == null)
                return Unauthorized();

            var token = _jwtTokenService.GenerateToken(user);

            var cookieOptions = new CookieOptions
            {
                HttpOnly = true,
                Secure = true,
                Expires = DateTime.UtcNow.AddMinutes(60),
                SameSite = SameSiteMode.None

            };

            Response.Cookies.Append("jwtToken", token, cookieOptions);

            return Ok(new
            {
                Token = token,
                User = new
                {
                    user.Id,
                    user.Name,
                    user.Email,
                    user.Password,
                    user.Role,
                }
            });
        }


    }
}
