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
    {

        private readonly IContext _context;

        public StudentRep(IContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _context.CreateCollectionsIfNotExists().Wait();
        }
        public async Task<List<Student>> GetAllAsync()
        {
            return await _context.Students.Find(Builders<Student>.Filter.Empty).ToListAsync();
        }

        public async Task<Student> GetByIdAsync(string id)
        {
            return await _context.Students.Find<Student>(student => student.Id == id).FirstOrDefaultAsync();          
        }

        public async Task<Student> AddAsync(Student student)
        {
            if (student == null) throw new ArgumentNullException(nameof(student));
            student.Id = ObjectId.GenerateNewId().ToString();

            var institution = await _context.Institutions
                    .Find(i => i.Id == student.InstitutionId)
                    .FirstOrDefaultAsync();

            if (institution != null)
            {
                institution.Students.Add(student);

                var filter = Builders<Institution>.Filter.Eq(i => i.Id, institution.Id);
                await _context.Institutions.ReplaceOneAsync(filter, institution);
            }
            await _context.Students.InsertOneAsync(student);
            return student;
        }
      
        public async Task<List<Student>> AddMultiAsync(List<Student> students)
        {
            try
            {
                if (students == null || students.Count == 0)
                    throw new ArgumentNullException(nameof(students), "Student list cannot be null or empty.");

                var institution = await _context.Institutions
                    .Find(i => i.Id == students.First().InstitutionId)
                    .FirstOrDefaultAsync();

                if (institution == null)
                    throw new InvalidOperationException("Institution not found.");

                students = students.Select(s =>
                {
                    s.Id = ObjectId.GenerateNewId().ToString();
                    return s;
                }).ToList();

                institution.Students.AddRange(students);

                var filter = Builders<Institution>.Filter.Eq(i => i.Id, institution.Id);
                var updateResult = await _context.Institutions.ReplaceOneAsync(filter, institution);

                if (updateResult.MatchedCount == 0)
                    throw new InvalidOperationException("Failed to update institution.");

                // הוספת הסטודנטים למסד הסטודנטים
                await _context.Students.InsertManyAsync(students);
                return students;
            }
            catch (ArgumentNullException ex)
            {
                // טיפול בחריגה של מערך null או ריק
                Console.Error.WriteLine($"Argument Error: {ex.Message}");
                throw;
            }
            catch (InvalidOperationException ex)
            {
                // טיפול בחריגות קשורות לאי מציאת המוסד או בעיות אחרות
                Console.Error.WriteLine($"Operation Error: {ex.Message}");
                throw;
            }
            catch (Exception ex)
            {
                // טיפול בחריגות כלליות אחרות
                Console.Error.WriteLine($"Unexpected Error: {ex.Message}");
                throw;
            }
        }

        public async Task<Student> UpdateAsync(Student entity)
        {
            if (entity == null) throw new ArgumentNullException(nameof(entity));
            var filter = Builders<Student>.Filter.Eq("Id", entity.Id);
            var result = await _context.Students.ReplaceOneAsync(filter, entity);
           
           
            var institution = await _context.Institutions.Find(i => i.Id == entity.InstitutionId).FirstOrDefaultAsync();

            if (institution != null)
            {
                var existingStudent = institution.Students.FirstOrDefault(s => s.Id == entity.Id);

                if (existingStudent != null)
                {
                    var index = institution.Students.IndexOf(existingStudent);
                    institution.Students[index] = entity;

                    var institutionFilter = Builders<Institution>.Filter.Eq(i => i.Id, institution.Id);
                    await _context.Institutions.ReplaceOneAsync(institutionFilter, institution);
                }
            }
            return result.ModifiedCount > 0 ? entity : null;
        }
        public async Task<bool> DeleteAsync(string id)
        {
            var filter = Builders<Student>.Filter.Eq("Id", id);
            var result = await _context.Students.DeleteOneAsync(filter);
            var student = await _context.Students.Find(s => s.Id == id).FirstOrDefaultAsync();

            var institution = await _context.Institutions.Find(i => i.Id == student.InstitutionId).FirstOrDefaultAsync();
            if (institution != null)
            {
                var existingStudent = institution.Students.FirstOrDefault(s => s.Id == id);
                if (existingStudent != null)
                {
                    institution.Students.Remove(existingStudent);

                    var institutionFilter = Builders<Institution>.Filter.Eq(i => i.Id, institution.Id);
                    await _context.Institutions.ReplaceOneAsync(institutionFilter, institution);
                }
            }
            return result.DeletedCount > 0;
        }
    }
}


