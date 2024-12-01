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
    public class ParentReportRep : IDataRepository<ParentReport>
    {
        private readonly IContext _context;

        public ParentReportRep(IContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _context.CreateCollectionsIfNotExists().Wait();

        }
        public async Task<List<ParentReport>> GetAllAsync()
        {
            return await _context.ParentReports.Find(ParentReport => true).ToListAsync();
        }

        public async Task<ParentReport> GetByIdAsync(string parentReportId)
        {
            return await _context.ParentReports.Find<ParentReport>(parentReport => parentReport.ParentReportId == parentReportId).FirstOrDefaultAsync();
        }

        public async Task<ParentReport> AddAsync(ParentReport parentReport)
        {
            if (parentReport == null) throw new ArgumentNullException(nameof(parentReport));

            parentReport.ParentReportId = ObjectId.GenerateNewId().ToString();

            // שליפת התלמיד לפי ID
            var student = await _context.Students
                .Find(i => i.Id == parentReport.StudentId)
                .FirstOrDefaultAsync();

            if (student == null)
                throw new InvalidOperationException("Student not found");

            // בדיקה אם התלמיד הוא מסוג זכאות ואפיון
            if (student is EligibilityAndCharacterization eligibilityAndCharacterization)
            {
                eligibilityAndCharacterization.ParentReport = parentReport;

                var filter = Builders<Student>.Filter.Eq(i => i.Id, student.Id);
                await _context.Students.ReplaceOneAsync(filter, eligibilityAndCharacterization);
            }
            else
            {
                throw new InvalidOperationException("The student is not of type EntitlementStudent");
            }

            // שמירת דוח ההורים
            await _context.ParentReports.InsertOneAsync(parentReport);

            return parentReport;
        }

        public async Task<ParentReport> UpdateAsync(ParentReport parentReport)
        {
            if (parentReport == null)
                throw new ArgumentNullException(nameof(parentReport));

            var existingParentReport = await _context.ParentReports
                .Find(r => r.ParentReportId == parentReport.ParentReportId)
                .FirstOrDefaultAsync();

            if (existingParentReport == null)
                throw new InvalidOperationException("Parent report not found");

            UpdateProperties(parentReport, existingParentReport);

            // עדכון דוח ההורים במסד הנתונים
            await _context.ParentReports.ReplaceOneAsync(
                Builders<ParentReport>.Filter.Eq(r => r.ParentReportId, parentReport.ParentReportId),
                existingParentReport
            );

            // שליפת התלמיד המשויך לדוח ההורים
            var student = await _context.Students
                .Find(s => s.Id == parentReport.StudentId)
                .FirstOrDefaultAsync();

            if (student == null)
                throw new InvalidOperationException("Student not found");

            // בדיקה אם התלמיד הוא מסוג זכאות ואפיון
            if (student is EligibilityAndCharacterization eligibilityAndCharacterization)
            {
                // עדכון דוח ההורים בתלמיד
                eligibilityAndCharacterization.ParentReport = existingParentReport;

                // עדכון התלמיד במסד הנתונים
                var filter = Builders<Student>.Filter.Eq(s => s.Id, eligibilityAndCharacterization.Id);
                await _context.Students.ReplaceOneAsync(filter, eligibilityAndCharacterization);
            }
            else
            {
                throw new InvalidOperationException("The student is not of type EntitlementStudent");
            }

            return existingParentReport;
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

        public async Task<bool> DeleteAsync(string parentReportId)
        {
            var result = await _context.ParentReports.DeleteOneAsync(p => p.ParentReportId == parentReportId);
            return result.DeletedCount > 0;
        }
    }
}
