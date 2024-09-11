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
    public class StudentRep<T> : IDataRepository<T> where T : IEntityRep
    {
        protected readonly IMongoCollection<T> _Students;

        private readonly IContext _context;

        public StudentRep(IContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _context.CreateCollectionsIfNotExists().Wait();
            _Students = (IMongoCollection<T>)_context.GetCollection<T>(typeof(T).Name);
        }
        public async Task<List<T>> GetAllAsync()
        {
            return await _Students.Find(e => true).ToListAsync();
        }

        public async Task<T> GetByIdAsync(string id)
        {
            var filter = Builders<T>.Filter.Eq("Id", id);
            return await _Students.Find(filter).FirstOrDefaultAsync();
        }

        public async Task<T> AddAsync(T entity) 
        {
            if (entity == null) throw new ArgumentNullException(nameof(entity));
            entity.Id = ObjectId.GenerateNewId().ToString();
            await _Students.InsertOneAsync(entity);
            return entity;
        }

        public async Task<T> UpdateAsync(T entity)
        {
            if (entity == null) throw new ArgumentNullException(nameof(entity));
            var id = new ObjectId(GetIdValue(entity));
            var filter = Builders<T>.Filter.Eq("Id", id);
            var result = await _Students.ReplaceOneAsync(filter, entity);
            return result.ModifiedCount > 0 ? entity : default(T);
        }

        public async Task<bool> DeleteAsync(string id)
        {
            var filter = Builders<T>.Filter.Eq("Id", id);

            var result = await _Students.DeleteOneAsync(filter);
            return result.DeletedCount > 0;
        }
    
        private string GetIdValue(T entity)
        {
            var propertyInfo = entity.GetType().GetProperty("Id");
            if (propertyInfo == null)
            {
                throw new InvalidOperationException("Entity does not have an 'Id' property");
            }
            return propertyInfo.GetValue(entity)?.ToString();
        }
    }
}


