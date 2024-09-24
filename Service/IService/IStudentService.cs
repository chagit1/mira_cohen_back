using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public interface IStudentService
    { 
    Task<List<StudentEntities>> GetAllAsync();
        Task<StudentEntities> GetByIdAsync(string id);
        Task<StudentEntities> AddAsync(StudentEntities dto);
        Task<StudentEntities> UpdateAsync(StudentEntities dto);
        Task<bool> DeleteAsync(string id);
    }
}
