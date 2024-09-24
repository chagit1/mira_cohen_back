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
    public class StudentService : IStudentService
    {
        protected readonly IDataRepository<Student> _repository;
        protected readonly IMapper _mapper;

        public StudentService(IDataRepository<Student> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<List<StudentEntities>> GetAllAsync()
        {
            var entities = await _repository.GetAllAsync();

            return _mapper.Map<List<StudentEntities>>(entities);            
        }
        //public async Task<List<StudentEntities>> GetAllAsync()
        //{

        //    var entities = await _repository.GetAllAsync();
        //    var dtoList = entities.Select(entity =>
        //    {
        //        if (entity is HelpHours helpHours)
        //        {
        //            return _mapper.Map<HelpHoursEntities>(helpHours);
        //        }
        //        else if (entity is EligibilityAndCharacterization eligibility)
        //        {
        //            return _mapper.Map<EligibilityAndCharacterizationEntities>(eligibility);
        //        }
        //        else
        //        {
        //            return _mapper.Map<StudentEntities>(entity);
        //        }
        //    }).ToList();
        //    return dtoList;
        //}

        public async Task<StudentEntities> GetByIdAsync(string id)
        {
            var entity = await _repository.GetByIdAsync(id);
            return _mapper.Map<StudentEntities>(entity);
        }

      
        public async Task<StudentEntities> AddAsync(StudentEntities dto)
        {
            Student entity;
            Student addedEntity;
            if (dto is HelpHoursEntities)
            {
                entity = _mapper.Map<HelpHours>(dto);
                addedEntity = await _repository.AddAsync(entity);
                return _mapper.Map<HelpHoursEntities>(addedEntity);
            }
          
            entity = _mapper.Map<EligibilityAndCharacterization>(dto);
            addedEntity = await _repository.AddAsync(entity);
            return _mapper.Map<EligibilityAndCharacterizationEntities>(addedEntity);         
        }


        public async Task<StudentEntities> UpdateAsync(StudentEntities dto)
        {
            var entity = _mapper.Map<Student>(dto);
            var updatedEntity = await _repository.UpdateAsync(entity);
            return _mapper.Map<StudentEntities>(updatedEntity);
        }

        public async Task<bool> DeleteAsync(string id)
        {
            return await _repository.DeleteAsync(id);
        }
    }
}
