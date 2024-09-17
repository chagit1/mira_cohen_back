using Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Repository;
using Service;

namespace MiraCohen.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InstitutionController : ControllerBase
    {
        private readonly IInstitutionService _institutionService;

        public InstitutionController(IInstitutionService institutionService)
        {
            _institutionService = institutionService;
        }

        [HttpGet]
        public async Task<List<InstitutionEntities>> GetAll()
        {
            return await _institutionService.GetAllAsync();
        }
        [HttpGet("GetById/{institutionId}")]
        public async Task<InstitutionEntities> GetById(string institutionId)
        {
            return await _institutionService.GetByIdAsync(institutionId);
        }
        [HttpDelete("Delete/{institutionId}")]
        public async Task<bool> Delete(string institutionId)
        {
            return await _institutionService.DeleteAsync(institutionId);
        }

        [HttpPost("Add")]
        public async Task<IActionResult> Add(InstitutionEntities institution)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var id = await _institutionService.AddAsync(institution);
            return Ok(id);
        }

        [HttpPut("Update")]
        public async Task<InstitutionEntities> Update(InstitutionEntities institution)
        {
            return await _institutionService.UpdateAsync(institution);
        }
        [HttpPost("AddInstitution")]
        public async Task<Institution> AddInstitutionAsync([FromBody] InstitutionEntities institutionDto)
        {
            //// המרת DTO לאובייקט Institution
            //var institution = new InstitutionEntities
            //{
            //    UserId = institutionDto.UserId, // הנחה שהוספת מאפיין כזה אם נדרש
            //    InstitutionName = institutionDto.InstitutionName,
            //    Symbol = institutionDto.Symbol,
            //    ManagerName = institutionDto.ManagerName,
            //    ContactPerson = institutionDto.ContactPerson,
            //    ContactPhone = institutionDto.ContactPhone,
            //    ContactEmail = institutionDto.ContactEmail,
            //    InspectorName = institutionDto.InspectorName
            //};

            return await _institutionService.AddInstitutionAsync(institutionDto);
        }

    }
}
