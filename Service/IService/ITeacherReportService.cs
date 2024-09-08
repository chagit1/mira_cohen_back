using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public interface ITeacherReportService
    {
        Task<List<TeacherReportEntities>> GetAllAsync();
        Task<TeacherReportEntities> GetByIdAsync(string id);
        Task<TeacherReportEntities> AddAsync(TeacherReportEntities dto);
        Task<TeacherReportEntities> UpdateAsync(TeacherReportEntities dto);
        Task<bool> DeleteAsync(string id);
    }
}
