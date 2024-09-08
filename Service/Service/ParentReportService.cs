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
    public class ParentReportService : IParentReportService
    {
        private readonly IDataRepository<ParentReport> _repository;
        private readonly IMapper _mapper;

        public ParentReportService(ParentReportRep repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<List<ParentReportEntities>> GetAllAsync()
        {
            var parentReports = await _repository.GetAllAsync();
            return _mapper.Map<List<ParentReportEntities>>(parentReports);
        }

        public async Task<ParentReportEntities> GetByIdAsync(string id)
        {
            var parentReport = await _repository.GetByIdAsync(id);
            return _mapper.Map<ParentReportEntities>(parentReport);
        }

        public async Task<ParentReportEntities> AddAsync(ParentReportEntities parentReport)
        {
            var parentReportRep = _mapper.Map<ParentReport>(parentReport);
            var addedParentReport = await _repository.AddAsync(parentReportRep);
            return _mapper.Map<ParentReportEntities>(addedParentReport);
        }

        public async Task<ParentReportEntities> UpdateAsync(ParentReportEntities parentReport)
        {
            var parentReportRep = _mapper.Map<ParentReport>(parentReport);
            var updatedParentReport = await _repository.UpdateAsync(parentReportRep);
            return _mapper.Map<ParentReportEntities>(updatedParentReport);
        }

        public async Task<bool> DeleteAsync(string id)
        {
            return await _repository.DeleteAsync(id);
        }
    }
}
