using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class InstitutionRep : IDataRepository<Institution>
    {
        private readonly IMongoCollection<Institution> _institutions;

        public InstitutionRep(IContext context)
        {
            _institutions = context.Institutions;
        }

        public async Task<List<Institution>> GetAllAsync()
        {
            return await _institutions.Find(institution => true).ToListAsync();
        }

        public async Task<Institution> GetByIdAsync(string id)
        {
            return await _institutions.Find<Institution>(institution => institution.Id == id).FirstOrDefaultAsync();
        }

        public async Task<Institution> AddAsync(Institution institution)
        {
            await _institutions.InsertOneAsync(institution);
            return institution;
        }

        public async Task<Institution> UpdateAsync(Institution institution)
        {
            await _institutions.ReplaceOneAsync(u => u.Id == institution.Id, institution);
            return institution;
        }

        public async Task<bool> DeleteAsync(string id)
        {
            var result = await _institutions.DeleteOneAsync(i => i.Id == id);
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
    //}
}
