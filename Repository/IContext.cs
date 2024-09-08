using Microsoft.EntityFrameworkCore;
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
        //DbSet<EligibilityAndCharacterization> EligibilityAndCharacterizations { get; set; }
        //DbSet<HelpHours> HelpHourses { get; set; }
        //DbSet<Institution> Institutions { get; set; }
        //DbSet<ParentReport> ParentReports { get; set; }
        //DbSet<Student> Students { get; set; }
        //DbSet<TeacherReport> TeacherReports { get; set; }
        //DbSet<User> Users { get; set; }


        //Task<int> SaveChangesAsync(CancellationToken cancellationToken = default(CancellationToken));

        IMongoCollection<EligibilityAndCharacterization> EligibilityAndCharacterizations { get; }
        IMongoCollection<HelpHours> HelpHours { get; }
        IMongoCollection<Institution> Institutions { get; }
        IMongoCollection<ParentReport> ParentReports { get; }
        IMongoCollection<Student> Students { get; }
        IMongoCollection<TeacherReport> TeacherReports { get; }
        IMongoCollection<User> Users { get; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default(CancellationToken));



    }
}
