using Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Service;

namespace MiraCohen.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HelpHoursController : ControllerBase
    {
        private readonly IHelpHoursService _helpHoursService;

        public HelpHoursController(IHelpHoursService helpHoursService)
        {
            _helpHoursService = helpHoursService;
        }

        [HttpGet]
        public async Task<List<HelpHoursEntities>> GetAll()
        {
            return await _helpHoursService.GetAllAsync();
        }
        [HttpGet("GetById/{helpHoursId}")]
        public async Task<HelpHoursEntities> GetById(string helpHoursId)
        {
            return await _helpHoursService.GetByIdAsync(helpHoursId);
        }
        [HttpDelete("Delete/{helpHoursId}")]
        public async Task<bool> Delete(string helpHoursId)
        {
            return await _helpHoursService.DeleteAsync(helpHoursId);
        }

        [HttpPost("Add")]
        public IActionResult Add(HelpHoursEntities helpHours)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var id = _helpHoursService.AddAsync(helpHours);
            return Ok(id);
        }

        [HttpPut("Update")]
        public async Task<HelpHoursEntities> Update(HelpHoursEntities helpHours)
        {
            return await _helpHoursService.UpdateAsync(helpHours);
        }
    }
}
