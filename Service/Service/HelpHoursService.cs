using AutoMapper;
using Entities;
using MongoDB.Bson.Serialization;
using MongoDB.Bson;
using MongoDB.Driver;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class HelpHoursService : StudentService, IHelpHoursService
    {
        public HelpHoursService(IDataRepository<Student> repository, IMapper mapper)
            : base(repository, mapper)
        {
        }
        
        public async Task<List<HelpHoursEntities>> GetAllAsync()
        {
            var entities = await _repository.GetAllAsync();
            var helpHoursStudents = entities.OfType<HelpHours>().ToList(); 
            return _mapper.Map<List<HelpHoursEntities>>(helpHoursStudents);
        }

        public async Task<HelpHoursEntities> GetByIdAsync(string id)
        {
            var entity = await _repository.GetByIdAsync(id);
            return _mapper.Map<HelpHoursEntities>(entity);
        }

        public async Task<HelpHoursEntities> UpdateAsync(HelpHoursEntities helpHours)
        {
            var entity = _mapper.Map<HelpHours>(helpHours);
            var updatedEntity = await _repository.UpdateAsync(entity);
            return _mapper.Map<HelpHoursEntities>(updatedEntity);
        }
    }
}
