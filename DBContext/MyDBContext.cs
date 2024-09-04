using Microsoft.EntityFrameworkCore;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Diagnostics.Metrics;
using System.Drawing;
using Microsoft.EntityFrameworkCore;
using Repository;

namespace DBContext
{
    public class MyDBContext : DbContext, IContext
    {
        public DbSet<EligibilityAndCharacterization> EligibilityAndCharacterizations { get; set; }
        public DbSet<HelpHours> HelpHourses { get; set; }
        public DbSet<Institution> Institutions { get; set; }
        public DbSet<ParentReport> ParentReports { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<TeacherReport> TeacherReports { get; set; }
        public DbSet<User> Users { get; set; }
        //on configuring
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=MiraCohen;Trusted_Connection=True");
        }

    }
}

