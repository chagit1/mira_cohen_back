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


        //public StudentRep(IContext context)
        //{
        //    _context.Students = context.GetCollection<T>("Students");
        //}

        private readonly IContext _context;

        public StudentRep(IContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _context.CreateCollectionsIfNotExists().Wait();
            _Students = (IMongoCollection<T>?)_context.Students;

        }

        //public StudentRep(IOptions<MiraCohenDatabaseSettings> miraCohenDatabaseSettings)
        //{
        //    var mongoClient = new MongoClient(miraCohenDatabaseSettings.Value.ConnectionString);
        //    var mongoDatabase = mongoClient.GetDatabase(miraCohenDatabaseSettings.Value.DatabaseName);
        //    _context.Students = mongoDatabase.GetCollection<T>(miraCohenDatabaseSettings.Value.StudentsCollectionName);
        //}


        public async Task<List<T>> GetAllAsync()
        {
            return await _Students.Find(e => true).ToListAsync();
        }

        public async Task<T> GetByIdAsync(string id)
        {
            return await _Students.Find(e => GetIdValue(e) == id).FirstOrDefaultAsync();
        }

        public async Task<T> AddAsync(T entity) 
        {
            entity.Id = ObjectId.GenerateNewId().ToString();
            if (entity == null) throw new ArgumentNullException(nameof(entity));
            await _Students.InsertOneAsync(entity);
            return entity;
        }

        public async Task<T> UpdateAsync(T entity)
        {
            await _Students.ReplaceOneAsync(e => GetIdValue(e) == GetIdValue(entity), entity);
            return entity;
        }

        public async Task<bool> DeleteAsync(string id)
        {
            var result = await _Students.DeleteOneAsync(e => GetIdValue(e) == id);
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

    //public class StudentRep<T> : IDataRepository<T>
    //{
    //    protected readonly IMongoCollection<T> _student;

    //    protected StudentRep(IMongoCollection<T> student)
    //    {
    //        _student = student;
    //    }

    //    public virtual async Task<List<T>> GetAllAsync()
    //    {
    //        return await _student.Find(e => true).ToListAsync();
    //    }

    //    public virtual async Task<T> GetByIdAsync(string id)
    //    {
    //        return await _student.Find(e => ((dynamic)e).Id == id).FirstOrDefaultAsync();
    //    }

    //    public virtual async Task<T> AddAsync(T entity)
    //    {
    //        await _student.InsertOneAsync(entity);
    //        return entity;
    //    }

    //    public virtual async Task<T> UpdateAsync(T entity)
    //    {
    //        await _student.ReplaceOneAsync(e => ((dynamic)e).Id == ((dynamic)entity).Id, entity);
    //        return entity;
    //    }

    //    public virtual async Task DeleteAsync(string id)
    //    {
    //        await _student.DeleteOneAsync(e => ((dynamic)e).Id == id);
    //    }
    //}


