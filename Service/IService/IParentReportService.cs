using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public interface IParentReportService
    {
        Task<List<ParentReportEntities>> GetAllAsync();
        Task<ParentReportEntities> GetByIdAsync(string id);
        Task<ParentReportEntities> AddAsync(ParentReportEntities dto);
        Task<ParentReportEntities> UpdateAsync(ParentReportEntities dto);
        Task<bool> DeleteAsync(string id);
    }
}
