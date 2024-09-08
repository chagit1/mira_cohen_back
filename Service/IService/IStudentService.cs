using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public interface IStudentService<TDTO>
    { 
    Task<List<TDTO>> GetAllAsync();
        Task<TDTO> GetByIdAsync(string id);
        Task<TDTO> AddAsync(TDTO dto);
        Task<TDTO> UpdateAsync(TDTO dto);
        Task<bool> DeleteAsync(string id);
    }
}
