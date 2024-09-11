using Microsoft.EntityFrameworkCore;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Diagnostics.Metrics;
using System.Drawing;
using Microsoft.EntityFrameworkCore;
using Repository;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using Microsoft.Extensions.Options;
using Microsoft.Extensions.Logging;

namespace Repository
{
    public class MiraCohenDatabaseSettings
    {
        public string ConnectionString { get; set; } = null!;

        public string DatabaseName { get; set; } = null!;

        public string UsersCollectionName { get; set; } = null!;

        public string TeacherReportsCollectionName { get; set; } = null!;
        public string StudentsCollectionName { get; set; } = null!;
        public string ParentReportsCollectionName { get; set; } = null!;
        public string InstitutionsCollectionName { get; set; } = null!;
        public string HelpHoursCollectionName { get; set; } = null!;
        public string EligibilityAndCharacterizationsCollectionName { get; set; } = null!;

    }
}

