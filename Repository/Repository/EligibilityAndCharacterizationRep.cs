using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class EligibilityAndCharacterizationRep : StudentRep<EligibilityAndCharacterization>
    {
        public EligibilityAndCharacterizationRep(IContext context)
            : base(context.EligibilityAndCharacterizations)
        {
        }
    }

    //public class EligibilityAndCharacterizationRep : StudentRep<EligibilityAndCharacterization>
    //{
    //    public EligibilityAndCharacterizationRep(IContext context)
    //    : base(context.EligibilityAndCharacterizations)
    //    {
    //    }

    //    public override async Task<List<EligibilityAndCharacterization>> GetAllAsync()
    //    {
    //        return await _student.Find(e => true).ToListAsync();
    //    }

    //    public override async Task<EligibilityAndCharacterization> GetByIdAsync(string id)
    //    {
    //        return await _student.Find(e => e.Id == id).FirstOrDefaultAsync();
    //    }

    //    public override async Task<EligibilityAndCharacterization> AddAsync(EligibilityAndCharacterization entity)
    //    {
    //        await _student.InsertOneAsync(entity);
    //        return entity;
    //    }

    //    public override async Task<EligibilityAndCharacterization> UpdateAsync(EligibilityAndCharacterization entity)
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
