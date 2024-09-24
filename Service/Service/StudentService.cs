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

            public async Task<StudentEntities> GetByIdAsync(string id)
            {
                var entity = await _repository.GetByIdAsync(id);
                return _mapper.Map<StudentEntities>(entity);
            }

        //public async Task<StudentEntities> AddAsync(StudentEntities dto)
        //{
        //var dtoType = dto.GetType();

        //// השתמש במיפוי עם הסוג הנכון
        //var entity = _mapper.Map(dto, dtoType); // מיפוי לסוג של dto

        //var addedEntity = await _repository.AddAsync(entity);

        ////var entity = _mapper.Map<dto.GetType()>(dto);
        ////    var addedEntity = await _repository.AddAsync(entity);
        //    return _mapper.Map<StudentEntities>(addedEntity);
        //}

        public async Task<StudentEntities> AddAsync(StudentEntities dto)
        {
            // זהה את הסוג של האובייקט
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
                entity = _mapper.Map<Student>(dto); // ברירת מחדל למחלקת האב
            }

            var addedEntity = await _repository.AddAsync(entity);
            return _mapper.Map<StudentEntities>(addedEntity);
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
