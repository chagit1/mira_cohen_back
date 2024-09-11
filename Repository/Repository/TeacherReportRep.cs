using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using MongoDB.Bson;
using MongoDB.Driver;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository

{
    public class TeacherReportRep : IDataRepository<TeacherReport>
    {
        private readonly IContext _context;
        public TeacherReportRep(IContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _context.CreateCollectionsIfNotExists().Wait();

        }
        public async Task<List<TeacherReport>> GetAllAsync()
    {
        return await _context.TeacherReports.Find(teacherReport => true).ToListAsync();
    }

    public async Task<TeacherReport> GetByIdAsync(string id)
    {
        return await _context.TeacherReports.Find<TeacherReport>(teacherReport => teacherReport.Id == id).FirstOrDefaultAsync();
    }

    public async Task<TeacherReport> AddAsync(TeacherReport teacherReport)
    {
            if (teacherReport == null) throw new ArgumentNullException(nameof(teacherReport)); 
            teacherReport.Id = ObjectId.GenerateNewId().ToString();
            if (teacherReport == null) throw new ArgumentNullException(nameof(teacherReport));
            await _context.TeacherReports.InsertOneAsync(teacherReport);
        return teacherReport;
    }

    public async Task<TeacherReport> UpdateAsync(TeacherReport teacherReport)
    {
            if (teacherReport == null) throw new ArgumentNullException(nameof(teacherReport)); 
            await _context.TeacherReports.ReplaceOneAsync(u => u.Id == teacherReport.Id, teacherReport);
        return teacherReport;
    }

        public async Task<bool> DeleteAsync(string id)
        {
            var result = await _context.TeacherReports.DeleteOneAsync(t => t.Id == id);
            return result.DeletedCount > 0;
        }
    }
}
