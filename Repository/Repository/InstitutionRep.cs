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
    public class InstitutionRep : IDataRepository<Institution>
    {
        private readonly IContext _context;

        public InstitutionRep(IContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _context.CreateCollectionsIfNotExists().Wait();

        }
        //private readonly IMongoCollection<Institution> _context.Institutions;

        //public InstitutionRep(IContext context)
        //{
        //    _context.Institutions = context.Institutions;
        //}
        //public InstitutionRep(IOptions<MiraCohenDatabaseSettings> miraCohenDatabaseSettings)
        //{
        //    var mongoClient = new MongoClient(miraCohenDatabaseSettings.Value.ConnectionString);
        //    var mongoDatabase = mongoClient.GetDatabase(miraCohenDatabaseSettings.Value.DatabaseName);
        //    _context.Institutions = mongoDatabase.GetCollection<Institution>(miraCohenDatabaseSettings.Value.InstitutionsCollectionName);
        //}

        public async Task<List<Institution>> GetAllAsync()
        {
            return await _context.Institutions.Find(institution => true).ToListAsync();
        }

        public async Task<Institution> GetByIdAsync(string id)
        {
            return await _context.Institutions.Find<Institution>(institution => institution.Id == id).FirstOrDefaultAsync();
        }

        public async Task<Institution> AddAsync(Institution institution)
        {
            institution.Id = ObjectId.GenerateNewId().ToString();
            if (institution == null) throw new ArgumentNullException(nameof(institution));
            await _context.Institutions.InsertOneAsync(institution);
            return institution;
        }

        public async Task<Institution> UpdateAsync(Institution institution)
        {
            await _context.Institutions.ReplaceOneAsync(u => u.Id == institution.Id, institution);
            return institution;
        }

        public async Task<bool> DeleteAsync(string id)
        {
            var result = await _context.Institutions.DeleteOneAsync(i => i.Id == id);
            return result.DeletedCount > 0;
        }
    }
}

    //public class InstitutionRep : StudentRep<Institution>
    //{
    //    public InstitutionRep(IContext context)
    //: base(context.Institutions)
    //    {
    //    }

    //    public override async Task<List<Institution>> GetAllAsync()
    //    {
    //        return await _student.Find(e => true).ToListAsync();
    //    }

    //    public override async Task<Institution> GetByIdAsync(string id)
    //    {
    //        return await _student.Find(e => e.Id == id).FirstOrDefaultAsync();
    //    }

    //    public override async Task<Institution> AddAsync(Institution entity)
    //    {
    //        await _student.InsertOneAsync(entity);
    //        return entity;
    //    }

    //    public override async Task<Institution> UpdateAsync(Institution entity)
    //    {
    //        await _student.ReplaceOneAsync(e => e.Id == entity.Id, entity);
    //        return entity;
    //    }

    //    public override async Task DeleteAsync(string id)
    //    {
    //        await _student.DeleteOneAsync(e => e.Id == id);
    //    }
    //}}
