using Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Service;

namespace MiraCohen.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeacherReportController : ControllerBase
    {
        private readonly ITeacherReportService _teacherReportService;

        public TeacherReportController(ITeacherReportService teacherReportService)
        {
            _teacherReportService = teacherReportService;
        }

        [HttpGet]
        public async Task<List<TeacherReportEntities>> GetAll()
        {
            return await _teacherReportService.GetAllAsync();
        }
        [HttpGet("GetById/{teacherReportId}")]
        public async Task<TeacherReportEntities> GetById(string teacherReportId)
        {
            return await _teacherReportService.GetByIdAsync(teacherReportId);
        }
        [HttpDelete("Delete/{teacherReportId}")]
        public async Task<bool> Delete(string teacherReportId)
        {
            return await _teacherReportService.DeleteAsync(teacherReportId);
        }

        [HttpPost("Add")]
        public async Task<IActionResult> Add(TeacherReportEntities teacherReport)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var id = await _teacherReportService.AddAsync(teacherReport);
            return Ok(id);
        }

        [HttpPut("Update")]
        public async Task<TeacherReportEntities> Update(TeacherReportEntities teacherReport)
        {
            if (teacherReport == null) 
                throw new ArgumentNullException(nameof(teacherReport));

            return await _teacherReportService.UpdateAsync(teacherReport);
        }

    }
}
