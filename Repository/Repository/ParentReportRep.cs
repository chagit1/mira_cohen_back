using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class ParentReportRep : IDataRepository<ParentReport>   
    {
        private readonly IMongoCollection<ParentReport> _parentReport;

        public ParentReportRep(IContext context)
        {
            _parentReport = context.ParentReports;
        }

        public async Task<List<ParentReport>> GetAllAsync()
        {
            return await _parentReport.Find(ParentReport => true).ToListAsync();
        }

        public async Task<ParentReport> GetByIdAsync(string id)
        {
            return await _parentReport.Find<ParentReport>(parentReport => parentReport.Id == id).FirstOrDefaultAsync();
        }

        public async Task<ParentReport> AddAsync(ParentReport parentReport)
        {
            await _parentReport.InsertOneAsync(parentReport);
            return parentReport;
        }

        public async Task<ParentReport> UpdateAsync(ParentReport parentReport)
        {
            await _parentReport.ReplaceOneAsync(u => u.Id == parentReport.Id, parentReport);
            return parentReport;
        }

        public async Task<bool> DeleteAsync(string id)
        {
            var result = await _parentReport.DeleteOneAsync(p => p.Id == id);
            return result.DeletedCount > 0;
        }
    }
}
