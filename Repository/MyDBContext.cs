using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class MyDBContext : IContext
    {
        private readonly IMongoDatabase _database;

        private readonly ILogger<MyDBContext> _logger;
        public IOptions<MiraCohenDatabaseSettings> miraCohenDatabaseSettings;
        public MyDBContext(IOptions<MiraCohenDatabaseSettings> miraCohenDatabaseSettings)
        {
            this.miraCohenDatabaseSettings = miraCohenDatabaseSettings;
            var connectionString = miraCohenDatabaseSettings.Value.ConnectionString;
            var mongoClient = new MongoClient(connectionString);
            _database = mongoClient.GetDatabase("MiraCohenDB");
            CreateCollectionsIfNotExists();
        }

        public async Task CreateCollectionsIfNotExists()
        {
            var collectionnames = _database.ListCollectionNames().ToList();

            if (!collectionnames.Contains("Users"))
            {
                await _database.CreateCollectionAsync("Users");
            }
            if (!collectionnames.Contains("TeacherReports"))
            {
                await _database.CreateCollectionAsync("TeacherReports");
            }
            if (!collectionnames.Contains("ParentReports"))
            {
                await _database.CreateCollectionAsync("ParentReports");
            }
            if (!collectionnames.Contains("Institutions"))
            {
                await _database.CreateCollectionAsync("Institutions");
            }
            if (!collectionnames.Contains("Helphours"))
            {
                await _database.CreateCollectionAsync("Helphours");
            }
            if (!collectionnames.Contains("EligibilityAndCharacterizations"))
            {
                await _database.CreateCollectionAsync("EligibilityAndCharacterizations");
            }
            if (!collectionnames.Contains("Students"))
            {
                await _database.CreateCollectionAsync("Students");
            }

        }
        public IMongoCollection<EligibilityAndCharacterization> EligibilityAndCharacterizations
        => _database.GetCollection<EligibilityAndCharacterization>(miraCohenDatabaseSettings.Value.EligibilityAndCharacterizationsCollectionName);


        public IMongoCollection<HelpHours> HelpHours
        => _database.GetCollection<HelpHours>(miraCohenDatabaseSettings.Value.HelpHoursCollectionName);

        public IMongoCollection<Institution> Institutions
               => _database.GetCollection<Institution>(miraCohenDatabaseSettings.Value.InstitutionsCollectionName);

        public IMongoCollection<ParentReport> ParentReports
        => _database.GetCollection<ParentReport>(miraCohenDatabaseSettings.Value.ParentReportsCollectionName);

        public IMongoCollection<Student> Students
        => _database.GetCollection<Student>(miraCohenDatabaseSettings.Value.StudentsCollectionName);

        public IMongoCollection<TeacherReport> TeacherReports
        => _database.GetCollection<TeacherReport>(miraCohenDatabaseSettings.Value.TeacherReportsCollectionName);

        public IMongoCollection<User> Users
        => _database.GetCollection<User>(miraCohenDatabaseSettings.Value.UsersCollectionName);

        public IMongoCollection<T> GetCollection<T>(string collectionName)
        {
            return _database.GetCollection<T>(collectionName);
        }

        public IMongoCollection<BsonDocument> GetCollection(string collectionName)
        {
            return _database.GetCollection<BsonDocument>(collectionName);
        }

        public Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            // ל-MongoDB אין "שינויים לא נשמרים" כמו ב-EF, כך שהמתודה הזו יכולה להיות פשוטה או להשאיר אותה ריקה
            return Task.FromResult(1);
        }
    }
    //   

    //    public IMongoCollection<T> GetCollection<T>()
    //    {
    //        return _database.GetCollection<T>(typeof(T).Name);
    //    }

    //=> _database.GetCollection<User>("Users");





}
