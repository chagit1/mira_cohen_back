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

        public UserController(IUserService userService)
        {
            _userService = userService;
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

    }
}
