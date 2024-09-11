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
    public class ParentReportRep : IDataRepository<ParentReport>   
    {
        private readonly IContext _context;

        public ParentReportRep(IContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _context.CreateCollectionsIfNotExists().Wait();

        }
        public async Task<List<ParentReport>> GetAllAsync()
        {
            return await _context.ParentReports.Find(ParentReport => true).ToListAsync();
        }

        public async Task<ParentReport> GetByIdAsync(string parentReportId)
        {
            return await _context.ParentReports.Find<ParentReport>(parentReport => parentReport.ParentReportId == parentReportId).FirstOrDefaultAsync();
        }

        public async Task<ParentReport> AddAsync(ParentReport parentReport)
        {
            parentReport.ParentReportId = ObjectId.GenerateNewId().ToString();
            if (parentReport == null) throw new ArgumentNullException(nameof(parentReport));
            await _context.ParentReports.InsertOneAsync(parentReport);
            return parentReport;
        }

        public async Task<ParentReport> UpdateAsync(ParentReport parentReport)
        {
            if (parentReport == null) throw new ArgumentNullException(nameof(parentReport));
            await _context.ParentReports.ReplaceOneAsync(u => u.ParentReportId == parentReport.ParentReportId, parentReport);
            return parentReport;
        }

        public async Task<bool> DeleteAsync(string parentReportId)
        {
            var result = await _context.ParentReports.DeleteOneAsync(p => p.ParentReportId == parentReportId);
            return result.DeletedCount > 0;
        }
    }
}
