using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class StudentRep<T> : IDataRepository<T>
    {
        protected readonly IMongoCollection<T> _collection;

        public StudentRep(IMongoCollection<T> collection)
        {
            _collection = collection;
        }

        public async Task<List<T>> GetAllAsync()
        {
            return await _collection.Find(e => true).ToListAsync();
        }

        public async Task<T> GetByIdAsync(string id)
        {
            return await _collection.Find(e => ((dynamic)e).Id == id).FirstOrDefaultAsync();
        }

        public async Task<T> AddAsync(T entity)
        {
            await _collection.InsertOneAsync(entity);
            return entity;
        }

        public async Task<T> UpdateAsync(T entity)
        {
            await _collection.ReplaceOneAsync(e => ((dynamic)e).Id == ((dynamic)entity).Id, entity);
            return entity;
        }

        public async Task<bool> DeleteAsync(string id)
        {
            var result = await _collection.DeleteOneAsync(e => ((dynamic)e).Id == id);
            return result.DeletedCount > 0;
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

}
