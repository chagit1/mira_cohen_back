using Microsoft.EntityFrameworkCore;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public interface IContext
    {
        IMongoCollection<T> GetCollection<T>(string v);
        IMongoCollection<BsonDocument> GetCollection(string collectionName);
        IMongoCollection<EligibilityAndCharacterization> EligibilityAndCharacterizations { get; }
        IMongoCollection<HelpHours> HelpHours { get; }
        IMongoCollection<Institution> Institutions { get; }
        IMongoCollection<ParentReport> ParentReports { get; }
        IMongoCollection<Student> Students { get; }
        IMongoCollection<TeacherReport> TeacherReports { get; }
        IMongoCollection<User> Users { get; }
        Task CreateCollectionsIfNotExists();
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default(CancellationToken));    
    }
}
