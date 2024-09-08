using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository

{
    public class TeacherReportRep : IDataRepository<TeacherReport>
    {
        private readonly IMongoCollection<TeacherReport> _teacherReport;

    public TeacherReportRep(IContext context)
    {
        _teacherReport = context.TeacherReports;
    }

    public async Task<List<TeacherReport>> GetAllAsync()
    {
        return await _teacherReport.Find(teacherReport => true).ToListAsync();
    }

    public async Task<TeacherReport> GetByIdAsync(string id)
    {
        return await _teacherReport.Find<TeacherReport>(teacherReport => teacherReport.Id == id).FirstOrDefaultAsync();
    }

    public async Task<TeacherReport> AddAsync(TeacherReport teacherReport)
    {
        await _teacherReport.InsertOneAsync(teacherReport);
        return teacherReport;
    }

    public async Task<TeacherReport> UpdateAsync(TeacherReport teacherReport)
    {
        await _teacherReport.ReplaceOneAsync(u => u.Id == teacherReport.Id, teacherReport);
        return teacherReport;
    }

        public async Task<bool> DeleteAsync(string id)
        {
            var result = await _teacherReport.DeleteOneAsync(t => t.Id == id);
            return result.DeletedCount > 0;
        }
    }
}
