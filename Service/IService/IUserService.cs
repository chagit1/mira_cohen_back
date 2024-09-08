using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public interface IUserService
    {
        Task<List<UserEntities>> GetAllAsync();
        Task<UserEntities> GetByIdAsync(string id);
        Task<UserEntities> AddAsync(UserEntities dto);
        Task<UserEntities> UpdateAsync(UserEntities dto);
        Task<bool> DeleteAsync(string id); 
    }
}
