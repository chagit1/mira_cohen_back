using AutoMapper;
using Entities;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BCrypt.Net;
using MongoDB.Driver;
using Microsoft.VisualBasic;

namespace Service
{
    public class UserService : IUserService
    {
        private readonly IDataRepository<User> _repository;
        private readonly IMapper _mapper;
        private readonly IMongoCollection<User> _users;

        public UserService(IDataRepository<User> repository, IMapper mapper, IContext context)
        {
            _repository = repository;
            _mapper = mapper;
            _users = context.Users;
        }

        public async Task<List<UserEntities>> GetAllAsync()
        {
            var users = await _repository.GetAllAsync();
            return _mapper.Map<List<UserEntities>>(users);
        }

        public async Task<UserEntities> GetByIdAsync(string id)
        {
            var user = await _repository.GetByIdAsync(id);
            return _mapper.Map<UserEntities>(user);
        }

        public async Task<UserEntities> AddAsync(UserEntities user)
        {

            var userRep = _mapper.Map<User>(user);
            var addedUser = await _repository.AddAsync(userRep);

            return _mapper.Map<UserEntities>(addedUser); 
        }          

        public async Task<UserEntities> UpdateAsync(UserEntities user)
        {
            var userRep = _mapper.Map<User>(user);
            var updatedUser = await _repository.UpdateAsync(userRep);
            return _mapper.Map<UserEntities>(updatedUser);
        }

        public async Task<bool> DeleteAsync(string id)
        {
            return await _repository.DeleteAsync(id);
        }
        public async Task<User> GetByEmailAsync(string email)
        {
            if (string.IsNullOrEmpty(email))
                throw new ArgumentException("Email cannot be null or empty", nameof(email));

            var filter = Builders<User>.Filter.Eq(u => u.Email, email);

            return await _users.Find(filter).FirstOrDefaultAsync();
        }

        public async Task<User> AuthenticateAsync(string email, string password)
        {
            var user = await GetByEmailAsync(email);

            if (user == null || !BCrypt.Net.BCrypt.Verify(password, user.Password))
                return null; 

            return user; 
        }

    }

}
