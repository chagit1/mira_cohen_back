using Microsoft.EntityFrameworkCore;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Diagnostics.Metrics;
using System.Drawing;
using Microsoft.EntityFrameworkCore;
using Repository;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;

namespace DBContext
{
    public class MyDBContext : IContext
    {
        private readonly IMongoDatabase _database;

        public MyDBContext(IConfiguration configuration)
        {
            var client = new MongoClient(configuration.GetConnectionString("MongoDB"));
            _database = client.GetDatabase("MiraCohenDB");
        }

        public IMongoCollection<EligibilityAndCharacterization> EligibilityAndCharacterizations
            => _database.GetCollection<EligibilityAndCharacterization>("EligibilityAndCharacterizations");

        public IMongoCollection<HelpHours> HelpHours
            => _database.GetCollection<HelpHours>("HelpHours");

        public IMongoCollection<Institution> Institutions
            => _database.GetCollection<Institution>("Institutions");

        public IMongoCollection<ParentReport> ParentReports
            => _database.GetCollection<ParentReport>("ParentReports");

        public IMongoCollection<Student> Students
            => _database.GetCollection<Student>("Students");

        public IMongoCollection<TeacherReport> TeacherReports
            => _database.GetCollection<TeacherReport>("TeacherReports");

        public IMongoCollection<User> Users
            => _database.GetCollection<User>("Users");

        public Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            // ל-MongoDB אין "שינויים לא נשמרים" כמו ב-EF, כך שהמתודה הזו יכולה להיות פשוטה או להשאיר אותה ריקה
            return Task.FromResult(1);
        }
    }
}

