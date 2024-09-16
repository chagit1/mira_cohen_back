using Entities;
using Repository;
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
        Task<UserEntities> AddAsync(UserEntities user);
        Task<UserEntities> UpdateAsync(UserEntities user);
        Task<bool> DeleteAsync(string id);
        Task<User> AuthenticateAsync(string email, string password);
    }
}
