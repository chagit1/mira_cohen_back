using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public interface IHelpHoursService : IStudentService
    {
        Task<List<HelpHoursEntities>> GetAllAsync();
        Task<HelpHoursEntities> GetByIdAsync(string id);
        Task<HelpHoursEntities> UpdateAsync(HelpHoursEntities helpHours);
    }
}
