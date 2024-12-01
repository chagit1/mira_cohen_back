using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using MongoDB.Bson;
using MongoDB.Driver;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Repository

{
    public class TeacherReportRep : IDataRepository<TeacherReport>
    {
        private readonly IContext _context;
        public TeacherReportRep(IContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _context.CreateCollectionsIfNotExists().Wait();

        }
        public async Task<List<TeacherReport>> GetAllAsync()
        {
            return await _context.TeacherReports.Find(teacherReport => true).ToListAsync();
        }

        public async Task<TeacherReport> GetByIdAsync(string id)
        {
            return await _context.TeacherReports.Find<TeacherReport>(teacherReport => teacherReport.Id == id).FirstOrDefaultAsync();
        }
      
        public async Task<TeacherReport> AddAsync(TeacherReport teacherReport)
        {
            if (teacherReport == null) throw new ArgumentNullException(nameof(teacherReport));

            teacherReport.Id = ObjectId.GenerateNewId().ToString();

            // שליפת התלמיד לפי ID
            var student = await _context.Students
                .Find(i => i.Id == teacherReport.StudentId)
                .FirstOrDefaultAsync();

            if (student == null)
                throw new InvalidOperationException("Student not found");

            // בדיקה אם התלמיד הוא מסוג זכאות ואפיון
            if (student is EligibilityAndCharacterization eligibilityAndCharacterization)
            {
                eligibilityAndCharacterization.TeacherReport = teacherReport;

                var filter = Builders<Student>.Filter.Eq(i => i.Id, student.Id);
                await _context.Students.ReplaceOneAsync(filter, eligibilityAndCharacterization);
            }
            else
            {
                throw new InvalidOperationException("The student is not of type EntitlementStudent");
            }

            // שמירת דוח ההורים
            await _context.TeacherReports.InsertOneAsync(teacherReport);

            return teacherReport;
        }

        public async Task<TeacherReport> UpdateAsync(TeacherReport teacherReport)
        {
            if (teacherReport == null)
                throw new ArgumentNullException(nameof(teacherReport));

            var existingteacherReport = await _context.TeacherReports
                .Find(r => r.Id == teacherReport.Id)
                .FirstOrDefaultAsync();

            if (existingteacherReport == null)
                throw new InvalidOperationException("Parent report not found");

            UpdateProperties(teacherReport, existingteacherReport);

            // עדכון דוח ההורים במסד הנתונים
            await _context.TeacherReports.ReplaceOneAsync(
                Builders<TeacherReport>.Filter.Eq(r => r.Id, teacherReport.Id),
                existingteacherReport
            );

            // שליפת התלמיד המשויך לדוח ההורים
            var student = await _context.Students
                .Find(s => s.Id == teacherReport.StudentId)
                .FirstOrDefaultAsync();

            if (student == null)
                throw new InvalidOperationException("Student not found");

            // בדיקה אם התלמיד הוא מסוג זכאות ואפיון
            if (student is EligibilityAndCharacterization eligibilityAndCharacterization)
            {
                // עדכון דוח ההורים בתלמיד
                eligibilityAndCharacterization.TeacherReport = existingteacherReport;

                // עדכון התלמיד במסד הנתונים
                var filter = Builders<Student>.Filter.Eq(s => s.Id, eligibilityAndCharacterization.Id);
                await _context.Students.ReplaceOneAsync(filter, eligibilityAndCharacterization);
            }
            else
            {
                throw new InvalidOperationException("The student is not of type EntitlementStudent");
            }

            return existingteacherReport;
        }

        public static void UpdateProperties<T>(T source, T destination)
        {
            var properties = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);
            foreach (var property in properties)
            {
                if (property.CanWrite)
                {
                    var value = property.GetValue(source);
                    property.SetValue(destination, value);
                }
            }
        }


        public async Task<bool> DeleteAsync(string id)
        {
            var result = await _context.TeacherReports.DeleteOneAsync(t => t.Id == id);
            return result.DeletedCount > 0;
        }
    }
}
