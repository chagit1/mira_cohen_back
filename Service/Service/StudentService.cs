using AutoMapper;
using Entities;
using Entities;
using Repository;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
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

        public async Task<List<StudentEntities>> AddMultiAsync(IEnumerable<StudentEntities> dtoList)
        {
            List<Student> entities = new List<Student>();

            foreach (var dto in dtoList)
            {
                Student entity;

                if (dto is HelpHoursEntities)
                {
                    entity = _mapper.Map<HelpHours>(dto);
                }
                else if (dto is EligibilityAndCharacterizationEntities)
                {
                    entity = _mapper.Map<EligibilityAndCharacterization>(dto);
                }
                else
                {
                    throw new InvalidOperationException("Unsupported DTO type.");
                }

                entities.Add(entity);
            }

            List<Student> addedEntities = await _repository.AddMultiAsync(entities);

            List<StudentEntities> resultList = new List<StudentEntities>();
            foreach (var addedEntity in addedEntities)
            {
                StudentEntities entity;
                if (addedEntity is HelpHours)
                {
                  entity = _mapper.Map<HelpHoursEntities>(addedEntity); 
                }
                else if (addedEntity is EligibilityAndCharacterization)
                {
                    entity = _mapper.Map<EligibilityAndCharacterizationEntities>(addedEntity); 
                }
                else
                {
                    throw new InvalidOperationException("Unsupported entity type.");
                }
                resultList.Add(entity);

            }
        
            return resultList;
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
