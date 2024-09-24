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
        private readonly IStudentService _studentService;
        private readonly IHelpHoursService _helpHoursService;


        public HelpHoursController(IStudentService studentService, IHelpHoursService helpHoursService)
        {
            _studentService = studentService;
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
            return  await _helpHoursService.GetByIdAsync(helpHoursId);
        }

        [HttpDelete("Delete/{helpHoursId}")]
        public async Task<bool> Delete(string helpHoursId)
        {
            return await _studentService.DeleteAsync(helpHoursId);
        }

        [HttpPost("Add")]
        public async Task<ActionResult<HelpHoursEntities>> Add(HelpHoursEntities helpHours)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var addedEntity = await _studentService.AddAsync(helpHours);
            return CreatedAtAction(nameof(GetById), new { helpHoursId = addedEntity.Id }, addedEntity);
        }

        [HttpPut("Update")]
        public async Task<HelpHoursEntities> Update(HelpHoursEntities helpHours)
        {
            return await _helpHoursService.UpdateAsync(helpHours);
        }
    }
}
