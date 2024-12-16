using Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Service;

namespace MiraCohen.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IStudentService _studentService;
        public StudentController(IStudentService studentService, IHelpHoursService helpHoursService)
        {
            _studentService = studentService;
        }

        [HttpGet("GetAllStudent")]
        public async Task<List<Object>> GetAllStudent()
        {
            List<StudentEntities> a = await _studentService.GetAllAsync();
            var results = new List<Object>();
            foreach (var student in a)
            {
                results.Add(student);
            }
            return results;
        }

        [HttpDelete("DeleteStudent/{studentId}")]
        public async Task<bool> DeleteStudent(string studentId)
        {
            return await _studentService.DeleteAsync(studentId);
        }


    }
}
