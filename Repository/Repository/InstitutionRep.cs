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
          
            var filter = Builders<User>.Filter.Eq(u => u.Id, institution.UserId);
            var update = Builders<User>.Update.Set(u => u.Institutions, institution);
            await _context.Users.UpdateOneAsync(filter, update);

            return institution;
        }

        public async Task<Institution> UpdateAsync(Institution institution)
        {
            if (institution == null) throw new ArgumentNullException(nameof(institution));
            await _context.Institutions.ReplaceOneAsync(u => u.Id == institution.Id, institution);
            return institution;
        }

        public async Task<bool> DeleteAsync(string id)
        {
            //var institution = _context.Institutions.Find<Institution>(institution => institution.Id == id).FirstOrDefaultAsync();
            //Institution institution1 = (Institution)institution.;
            //var resultUser = await _context.Users.DeleteOneAsync(i => i.Id == institution.User.Id);
            var result = await _context.Institutions.DeleteOneAsync(i => i.Id == id);
            return result.DeletedCount > 0;
        }

        public Task<List<Institution>> AddMultiAsync(List<Institution> entities)
        {
            throw new NotImplementedException();
        }
    }
}
