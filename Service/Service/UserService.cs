using AutoMapper;
using Entities;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class UserService : IUserService
    {
        private readonly IDataRepository<User> _repository;
        private readonly IMapper _mapper;

        public UserService(IDataRepository<User> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
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
    }

}
