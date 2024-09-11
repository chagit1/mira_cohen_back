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
    public class TeacherReportService : ITeacherReportService
    {
        private readonly IDataRepository<TeacherReport> _repository;
        private readonly IMapper _mapper;

        public TeacherReportService(IDataRepository<TeacherReport> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<List<TeacherReportEntities>> GetAllAsync()
        {
            var teacherReports = await _repository.GetAllAsync();
            return _mapper.Map<List<TeacherReportEntities>>(teacherReports);
        }

        public async Task<TeacherReportEntities> GetByIdAsync(string id)
        {
            var teacherReport = await _repository.GetByIdAsync(id);
            return _mapper.Map<TeacherReportEntities>(teacherReport);
        }

        public async Task<TeacherReportEntities> AddAsync(TeacherReportEntities teacherReport)
        {
            var teacherReportRep = _mapper.Map<TeacherReport>(teacherReport);
            var addedTeacherReport = await _repository.AddAsync(teacherReportRep);
            return _mapper.Map<TeacherReportEntities>(addedTeacherReport);
        }

        public async Task<TeacherReportEntities> UpdateAsync(TeacherReportEntities teacherReport)
        {
            var teacherReportRep = _mapper.Map<TeacherReport>(teacherReport);
            var updatedTeacherReport = await _repository.UpdateAsync(teacherReportRep);
            return _mapper.Map<TeacherReportEntities>(updatedTeacherReport);
        }

        public async Task<bool> DeleteAsync(string id)
        {
            return await _repository.DeleteAsync(id);
        }
    }
}
