using Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Service;

namespace MiraCohen.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ParentReportController : ControllerBase
    {
        private readonly IParentReportService _parentReportService;

        public ParentReportController(IParentReportService parentReportService)
        {
            _parentReportService = parentReportService;
        }

        [HttpGet]
        public async Task<List<ParentReportEntities>> GetAll()
        {
            return await _parentReportService.GetAllAsync();
        }
        [HttpGet("GetById/{parentReportId}")]
        public async Task<ParentReportEntities> GetById(string parentReportId)
        {
            return await _parentReportService.GetByIdAsync(parentReportId);
        }
        [HttpDelete("Delete/{parentReportId}")]
        public async Task<bool> Delete(string parentReportId)
        {
            return await _parentReportService.DeleteAsync(parentReportId);
        }

        [HttpPost("Add")]
        public async Task<IActionResult> Add(ParentReportEntities parentReport)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var id = await _parentReportService.AddAsync(parentReport);
            return Ok(id);
        }

        [HttpPut("Update")]
        public async Task<ParentReportEntities> Update(ParentReportEntities parentReport)
        {
            return await _parentReportService.UpdateAsync(parentReport);
        }
    }
}
