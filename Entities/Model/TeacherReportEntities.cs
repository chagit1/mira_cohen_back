using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class TeacherReportEntities
    {
        public string Id { get; set; }

        public string StudentId { get; set; }

        public string ReadingAndWritingSkills { get; set; }

        public string AcademicGap { get; set; }

        public string UnderstandingOfTheMaterial { get; set; }

        public string Memory { get; set; }

        public string GeneralKnowledge { get; set; }

        public string Motivation { get; set; }

        public string Vocabulary { get; set; }

        public string AcademicAchievements { get; set; }

        public string SocialAndEmotionalConduct { get; set; }

        public FamilyStatusEnumEntities FamilyStatus { get; set; }
    }
    public enum FamilyStatusEnumEntities
    {
        Divorced,
        Married,
        Separated
    }
}
