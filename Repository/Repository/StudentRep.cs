using Entities;
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
    public class StudentRep : IDataRepository<Student>
    //where T : IEntityRep
    {
        //protected readonly IMongoCollection _Students;

        private readonly IContext _context;

        public StudentRep(IContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _context.CreateCollectionsIfNotExists().Wait();
        }
        public async Task<List<Student>> GetAllAsync()
        {
            return await _context.Students.Find(e => true).ToListAsync();
        }

        public async Task<Student> GetByIdAsync(string id)
        {
            return await _context.Students.Find<Student>(student => student.Id == id).FirstOrDefaultAsync();

            //var filter = Builders.Filter.Eq("Id", id);
            //return await _Students.Find(filter).FirstOrDefaultAsync();
        }

        //public async Task<T> AddAsync(T entity)
        //{
        //    if (entity == null) throw new ArgumentNullException(nameof(entity));

        //    //if (string.IsNullOrEmpty(entity.Id))
        //    //{
        //    //    entity.Id = ObjectId.GenerateNewId().ToString();
        //    //}

        //    await _Students.InsertOneAsync(entity);


        //    if (entity is Student student)
        //    {

        //        var institution = await _context.Institutions
        //            .Find(i => i.Id == student.InstitutionId)
        //            .FirstOrDefaultAsync();

        //        //if (institution != null)
        //        //{
        //        //    // בדיקה אם הסטודנט כבר קיים ברשימת הסטודנטים של המוסד
        //        //    if (!institution.Students.Any(s => s.Id == student.Id))
        //        //    {
        //        //        institution.Students.Add(student);

        //        //        // עדכון המוסד עם רשימת הסטודנטים המעודכנת
        //        //        var filter = Builders<Institution>.Filter.Eq(i => i.Id, institution.Id);
        //        //        await _context.Institutions.ReplaceOneAsync(filter, institution);
        //        //    }
        //        //}
        //    }




        //    //if (entity is Student student)
        //    //{
        //    //    var institution = await _context.Institutions
        //    //        .Find(i => i.Id == student.InstitutionId)
        //    //        .FirstOrDefaultAsync();

        //    //    if (institution != null)
        //    //    {
        //    //        institution.Students.Add(student);

        //    //        var filter = Builders<Institution>.Filter.Eq(i => i.Id, institution.Id);
        //    //        await _context.Institutions.ReplaceOneAsync(filter, institution);
        //    //    }
        //    //}

        //    return entity;
        //}


        public async Task<Student> AddAsync(Student student)
        {
            if (student == null) throw new ArgumentNullException(nameof(student));
            student.Id = ObjectId.GenerateNewId().ToString();


            await _context.Students.InsertOneAsync(student);
            return student;
        }

        public async Task<Student> UpdateAsync(Student entity)
        {
            if (entity == null) throw new ArgumentNullException(nameof(entity));
            var filter = Builders<Student>.Filter.Eq("Id", entity.Id);
            var result = await _context.Students.ReplaceOneAsync(filter, entity);
            return result.ModifiedCount > 0 ? entity : null;
            //if (entity == null) throw new ArgumentNullException(nameof(entity));
            //var id = new ObjectId(GetIdValue(entity));
            //var filter = Builders<T>.Filter.Eq("Id", id);
            //var result = await _Students.ReplaceOneAsync(filter, entity);

            //if (entity is Student student)
            //{
            //    var institution = await _context.Institutions.Find(i => i.Id == student.InstitutionId).FirstOrDefaultAsync();

            //    if (institution != null)
            //    {
            //        var existingStudent = institution.Students.FirstOrDefault(s => s.Id == student.Id);

            //        if (existingStudent != null)
            //        {
            //            var index = institution.Students.IndexOf(existingStudent);
            //            institution.Students[index] = student;

            //            var institutionFilter = Builders<Institution>.Filter.Eq(i => i.Id, institution.Id);
            //            await _context.Institutions.ReplaceOneAsync(institutionFilter, institution);
            //        }
            //    }
            //}

            //return result.ModifiedCount > 0 ? entity : default(T);
        }
        public async Task<bool> DeleteAsync(string id)
        {
            var filter = Builders<Student>.Filter.Eq("Id", id);
            var result = await _context.Students.DeleteOneAsync(filter);
            return result.DeletedCount > 0;
        }
        //public async Task<bool> DeleteAsync(string studentId)
        //{
        //var student = await _Students.Find(s => s.Id == studentId).FirstOrDefaultAsync();

        //if (student == null)
        //{
        //    throw new Exception($"Student with ID {studentId} not found.");
        //}

        //var filter = Builders<T>.Filter.Eq(e => e.Id, studentId);
        //var deleteResult = await _Students.DeleteOneAsync(filter);

        //if (deleteResult.DeletedCount == 0)
        //{
        //    throw new Exception($"Failed to delete student with ID {studentId}.");
        //}

        //var institution = await _context.Institutions.Find(i => i.Id == student.InstitutionId).FirstOrDefaultAsync();
        //if (institution != null)
        //{
        //    var existingStudent = institution.Students.FirstOrDefault(s => s.Id == studentId);
        //    if (existingStudent != null)
        //    {
        //        institution.Students.Remove(existingStudent);

        //        var institutionFilter = Builders<Institution>.Filter.Eq(i => i.Id, institution.Id);
        //        await _context.Institutions.ReplaceOneAsync(institutionFilter, institution);
        //    }
        //}

        //return deleteResult.DeletedCount > 0;
        //    return true;
        //}

        //    private string GetIdValue(T entity)
        //    {
        //        var propertyInfo = entity.GetType().GetProperty("Id");
        //        if (propertyInfo == null)
        //        {
        //            throw new InvalidOperationException("Entity does not have an 'Id' property");
        //        }
        //        return propertyInfo.GetValue(entity)?.ToString();
        //    }

        //    Task<List<Student>> IDataRepository<Student>.GetAllAsync()
        //    {
        //        throw new NotImplementedException();
        //    }

        //    Task<Student> IDataRepository<Student>.GetByIdAsync(string id)
        //    {
        //        throw new NotImplementedException();
        //    }

        //    public Task<Student> UpdateAsync(Student entity)
        //    {
        //        throw new NotImplementedException();
        //    }
        //}
    }
}


