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
    public class EligibilityAndCharacterizationService : StudentService, IEligibilityAndCharacterizationService
    {
        public EligibilityAndCharacterizationService(IDataRepository<Student> repository, IMapper mapper)
            : base(repository, mapper)
        {
        }

        public async Task<List<EligibilityAndCharacterizationEntities>> GetAllAsync()
        {
            var entities = await _repository.GetAllAsync();
            var eligibilityAndCharacterizationStudents = entities.OfType<EligibilityAndCharacterization>().ToList();
            return _mapper.Map<List<EligibilityAndCharacterizationEntities>>(eligibilityAndCharacterizationStudents);
        }

        public async Task<EligibilityAndCharacterizationEntities> GetByIdAsync(string id)
        {
            var entity = await _repository.GetByIdAsync(id);
            return _mapper.Map<EligibilityAndCharacterizationEntities>(entity);
        }

        public async Task<EligibilityAndCharacterizationEntities> UpdateAsync(EligibilityAndCharacterizationEntities eligibilityAndCharacterization)
        {
            var entity = _mapper.Map<EligibilityAndCharacterization>(eligibilityAndCharacterization);
            var updatedEntity = await _repository.UpdateAsync(entity);
            return _mapper.Map<EligibilityAndCharacterizationEntities>(updatedEntity);
        }
    }
}
