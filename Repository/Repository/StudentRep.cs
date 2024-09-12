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

            if (entity is Student student)
            {
                var institution = await _context.Institutions
                    .Find(i => i.Id == student.InstitutionId)
                    .FirstOrDefaultAsync();

                if (institution != null)
                {
                    institution.Students.Add(student);

                    var filter = Builders<Institution>.Filter.Eq(i => i.Id, institution.Id);
                    await _context.Institutions.ReplaceOneAsync(filter, institution);
                }
            }

            return entity;
        }

        public async Task<T> UpdateAsync(T entity)
        {
            if (entity == null) throw new ArgumentNullException(nameof(entity));
            var id = new ObjectId(GetIdValue(entity));
            var filter = Builders<T>.Filter.Eq("Id", id);
            var result = await _Students.ReplaceOneAsync(filter, entity);

            if (entity is Student student)
            {
                var institution = await _context.Institutions.Find(i => i.Id == student.InstitutionId).FirstOrDefaultAsync();

                if (institution != null)
                {
                    var existingStudent = institution.Students.FirstOrDefault(s => s.Id == student.Id);

                    if (existingStudent != null)
                    {
                        var index = institution.Students.IndexOf(existingStudent);
                        institution.Students[index] = student;

                        var institutionFilter = Builders<Institution>.Filter.Eq(i => i.Id, institution.Id);
                        await _context.Institutions.ReplaceOneAsync(institutionFilter, institution);
                    }
                }
            }

            return result.ModifiedCount > 0 ? entity : default(T);
        }

        public async Task<bool> DeleteAsync(string studentId)
        {
            var student = await _Students.Find(s => s.Id == studentId).FirstOrDefaultAsync();

            if (student == null)
            {
                throw new Exception($"Student with ID {studentId} not found.");
            }

            var filter = Builders<T>.Filter.Eq(e => e.Id, studentId);
            var deleteResult = await _Students.DeleteOneAsync(filter);

            if (deleteResult.DeletedCount == 0)
            {
                throw new Exception($"Failed to delete student with ID {studentId}.");
            }

            var institution = await _context.Institutions.Find(i => i.Id == student.InstitutionId).FirstOrDefaultAsync();
            if (institution != null)
            {
                var existingStudent = institution.Students.FirstOrDefault(s => s.Id == studentId);
                if (existingStudent != null)
                {
                    institution.Students.Remove(existingStudent);

                    var institutionFilter = Builders<Institution>.Filter.Eq(i => i.Id, institution.Id);
                    await _context.Institutions.ReplaceOneAsync(institutionFilter, institution);
                }
            }

            return deleteResult.DeletedCount > 0;
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


