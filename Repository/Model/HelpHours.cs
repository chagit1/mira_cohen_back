using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class HelpHours : Student
    {
        [BsonElement("StrengthAreas")]
        [BsonIgnoreIfNull]
        public string StrengthAreas { get; set; }

        [BsonElement("AreasForImprovement")]
        [BsonIgnoreIfNull]
        public string AreasForImprovement { get; set; }

        [BsonElement("AcademicAchievements")]
        [BsonIgnoreIfNull]
        public string AcademicAchievements { get; set; }

        public HelpHours(string strengthAreas)
        {
            this.StrengthAreas = strengthAreas;
        }
    }
}
