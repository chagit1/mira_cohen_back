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
        //private readonly IMongoCollection<ParentReport> _context.ParentReports;

        //public ParentReportRep(IOptions<MiraCohenDatabaseSettings> miraCohenDatabaseSettings)
        //{
        //    var mongoClient = new MongoClient(miraCohenDatabaseSettings.Value.ConnectionString);
        //    var mongoDatabase = mongoClient.GetDatabase(miraCohenDatabaseSettings.Value.DatabaseName);
        //    _context.ParentReports = mongoDatabase.GetCollection<ParentReport>(miraCohenDatabaseSettings.Value.ParentReportsCollectionName);
        //}
        //   public ParentReportRep(IContext context)
        //    {
        //    _context.ParentReports = context.ParentReports;
        //}
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

        public async Task<ParentReport> GetByIdAsync(string id)
        {
            return await _context.ParentReports.Find<ParentReport>(parentReport => parentReport.Id == id).FirstOrDefaultAsync();
        }

        public async Task<ParentReport> AddAsync(ParentReport parentReport)
        {
            parentReport.Id = ObjectId.GenerateNewId().ToString();
            if (parentReport == null) throw new ArgumentNullException(nameof(parentReport));
            await _context.ParentReports.InsertOneAsync(parentReport);
            return parentReport;
        }

        public async Task<ParentReport> UpdateAsync(ParentReport parentReport)
        {
            await _context.ParentReports.ReplaceOneAsync(u => u.Id == parentReport.Id, parentReport);
            return parentReport;
        }

        public async Task<bool> DeleteAsync(string id)
        {
            var result = await _context.ParentReports.DeleteOneAsync(p => p.Id == id);
            return result.DeletedCount > 0;
        }
    }
}
