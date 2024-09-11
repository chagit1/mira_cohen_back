using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace Repository
{
    public class ParentReport : Student
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("StudentId")]
        [BsonIgnoreIfNull]
        public string StudentId { get; }

        [BsonElement("StrengthArea")]
        [BsonIgnoreIfNull]
        public string StrengthArea { get; set; }

        [BsonElement("BirthProcessAndEarlyDevelopment")]
        [BsonIgnoreIfNull]
        public string BirthProcessAndEarlyDevelopment { get; set; }

        [BsonElement("Weaning")]
        [BsonIgnoreIfNull]
        public string Weaning { get; set; }

        [BsonElement("PreSchoolEducation")]
        [BsonIgnoreIfNull]
        public string PreSchoolEducation { get; set; }

        [BsonElement("ParamedicalSupport")]
        [BsonIgnoreIfNull]
        public string ParamedicalSupport { get; set; }

        [BsonElement("PreSchoolDifficulties")]
        [BsonIgnoreIfNull]
        public string PreSchoolDifficulties { get; set; }

        [BsonElement("ElementaryEducation")]
        [BsonIgnoreIfNull]
        public string ElementaryEducation { get; set; }

        [BsonElement("ReadingAndWritingDevelopment")]
        [BsonIgnoreIfNull]
        public string ReadingAndWritingDevelopment { get; set; }

        [BsonElement("UnderstandingInstructions")]
        [BsonIgnoreIfNull]
        public string UnderstandingInstructions { get; set; }

        [BsonElement("ElementarySchoolDifficulties")]
        [BsonIgnoreIfNull]
        public string ElementarySchoolDifficulties { get; set; }

        [BsonElement("AcademicDifficulties")]
        public string AcademicDifficulties { get; set; }

        [BsonElement("SocialAndEmotionalDifficulties")]
        [BsonIgnoreIfNull]
        public string SocialAndEmotionalDifficulties { get; set; }

        [BsonElement("WasWithoutFramework")]
        public bool WasWithoutFramework { get; set; }

        [BsonElement("CurrentAcademicStatus")]
        [BsonIgnoreIfNull]
        public string CurrentAcademicStatus { get; set; }

        [BsonElement("CurrentReadingGap")]
        [BsonIgnoreIfNull]
        public string CurrentReadingGap { get; set; }

        [BsonElement("CurrentWritingGap")]
        [BsonIgnoreIfNull]
        public string CurrentWritingGap { get; set; }

        [BsonElement("CurrentMotivationGap")]
        [BsonIgnoreIfNull]
        public string CurrentMotivationGap { get; set; }
        
        [BsonElement("CurrentSocialGap")]
        [BsonIgnoreIfNull]
        public string CurrentSocialGap { get; set; }

        [BsonElement("CurrentEmotionalGap")]
        [BsonIgnoreIfNull]
        public string CurrentEmotionalGap { get; set; }

        [BsonElement("CurrentCulturalAndLeisureGap")]
        [BsonIgnoreIfNull]
        public string CurrentCulturalAndLeisureGap { get; set; }

        public ParentReport()
        {
            this.AcademicDifficulties = "rgdrg";
        }
    }
}