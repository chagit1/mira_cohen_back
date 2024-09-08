using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class UserRep : IDataRepository<User>
    {
        private readonly IMongoCollection<User> _users;

        public UserRep(IContext context)
        {
            _users = context.Users;
        }

        public async Task<List<User>> GetAllAsync()
        {
            return await _users.Find(user => true).ToListAsync();
        }

        public async Task<User> GetByIdAsync(string id)
        {
            return await _users.Find<User>(user => user.Id == id).FirstOrDefaultAsync();
        }

        public async Task<User> AddAsync(User user)
        {
            await _users.InsertOneAsync(user);
            return user;
        }

        public async Task<User> UpdateAsync(User user)
        {
            await _users.ReplaceOneAsync(u => u.Id == user.Id, user);
            return user;
        }

        public async Task<bool> DeleteAsync(string id)
        {
            var result = await _users.DeleteOneAsync(user => user.Id == id);
            return result.DeletedCount > 0;
        }
    }
}

