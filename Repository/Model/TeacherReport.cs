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
    public class TeacherReport
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("StudentId")]
        [BsonIgnoreIfNull]
        public string StudentId { get; set; }

        [BsonElement("ReadingAndWritingSkills")]
        [BsonIgnoreIfNull]
        public string ReadingAndWritingSkills { get; set; }

        [BsonElement("AcademicGap")]
        [BsonIgnoreIfNull]
        public string AcademicGap { get; set; }

        [BsonElement("UnderstandingOfTheMaterial")]
        [BsonIgnoreIfNull]
        public string UnderstandingOfTheMaterial { get; set; }

        [BsonElement("Memory")]
        [BsonIgnoreIfNull]
        public string Memory { get; set; }

        [BsonElement("GeneralKnowledge")]
        [BsonIgnoreIfNull]
        public string GeneralKnowledge { get; set; }

        [BsonElement("Motivation")]
        [BsonIgnoreIfNull]
        public string Motivation { get; set; }

        [BsonElement("Vocabulary")]
        [BsonIgnoreIfNull]
        public string Vocabulary { get; set; }

        [BsonElement("AcademicAchievements")]
        [BsonIgnoreIfNull]
        public string AcademicAchievements { get; set; }

        [BsonElement("SocialAndEmotionalConduct")]
        [BsonIgnoreIfNull]
        public string SocialAndEmotionalConduct { get; set; }

        [BsonElement("FamilyStatus")]
        [BsonIgnoreIfNull]
        public FamilyStatusEnum FamilyStatus { get; set; }
        public TeacherReport(string socialAndEmotionalConduct)
        {
            this.SocialAndEmotionalConduct = socialAndEmotionalConduct;            
        }
    }


    public enum FamilyStatusEnum
    {
        Divorced,
        Married,
        Separated
    }

}
