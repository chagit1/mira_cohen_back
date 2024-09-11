using Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Service;

namespace MiraCohen.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EligibilityAndCharacterizationController : ControllerBase
    {
        private readonly IEligibilityAndCharacterizationService _eligibilityAndCharacterizationService;

        public EligibilityAndCharacterizationController(IEligibilityAndCharacterizationService eligibilityAndCharacterizationService)
        {
            _eligibilityAndCharacterizationService = eligibilityAndCharacterizationService;
        }

        [HttpGet]
        public async Task<List<EligibilityAndCharacterizationEntities>> GetAll()
        {
            return await _eligibilityAndCharacterizationService.GetAllAsync();
        }

        [HttpGet("GetById/{eligibilityAndCharacterizationId}")]
        public async Task<EligibilityAndCharacterizationEntities> GetById(string eligibilityAndCharacterizationId)
        {
            return await _eligibilityAndCharacterizationService.GetByIdAsync(eligibilityAndCharacterizationId);
        }

        [HttpDelete("Delete/{eligibilityAndCharacterizationId}")]
        public async Task<bool> Delete(string eligibilityAndCharacterizationId)
        {
            return await _eligibilityAndCharacterizationService.DeleteAsync(eligibilityAndCharacterizationId);
        }

        [HttpPost("Add")]
        public async Task<IActionResult> Add(EligibilityAndCharacterizationEntities eligibilityAndCharacterization)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var id = await _eligibilityAndCharacterizationService.AddAsync(eligibilityAndCharacterization);
            return Ok(id);
        }

        [HttpPut("Update")]
        public async Task<EligibilityAndCharacterizationEntities> Update(EligibilityAndCharacterizationEntities eligibilityAndCharacterization)
        {
            return await _eligibilityAndCharacterizationService.UpdateAsync(eligibilityAndCharacterization);
        }
    }
}
