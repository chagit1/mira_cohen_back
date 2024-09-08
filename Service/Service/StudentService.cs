using AutoMapper;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class StudentService<T, TDTO> : IStudentService<TDTO>
    {        
            protected readonly IDataRepository<T> _repository;
            protected readonly IMapper _mapper;

            public StudentService(IDataRepository<T> repository, IMapper mapper)
            {
                _repository = repository;
                _mapper = mapper;
            }

            public async Task<List<TDTO>> GetAllAsync()
            {
                var entities = await _repository.GetAllAsync();
                return _mapper.Map<List<TDTO>>(entities);
            }

            public async Task<TDTO> GetByIdAsync(string id)
            {
                var entity = await _repository.GetByIdAsync(id);
                return _mapper.Map<TDTO>(entity);
            }

            public async Task<TDTO> AddAsync(TDTO dto)
            {
                var entity = _mapper.Map<T>(dto);
                var addedEntity = await _repository.AddAsync(entity);
                return _mapper.Map<TDTO>(addedEntity);
            }

            public async Task<TDTO> UpdateAsync(TDTO dto)
            {
                var entity = _mapper.Map<T>(dto);
                var updatedEntity = await _repository.UpdateAsync(entity);
                return _mapper.Map<TDTO>(updatedEntity);
            }

            public async Task<bool> DeleteAsync(string id)
            {
               return await _repository.DeleteAsync(id);
            }
        }
}
