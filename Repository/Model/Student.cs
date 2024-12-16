using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

using Entities;

namespace Repository
{
    [BsonDiscriminator(RootClass = true)]
    [BsonKnownTypes(typeof(EligibilityAndCharacterization), typeof(HelpHours))]
    public class Student 
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        
        [BsonElement("FirstName")]
        [BsonIgnoreIfNull]
        public string? FirstName { get; set; }

        [BsonElement("LastName")]
        [BsonIgnoreIfNull]
        public string? LastName { get; set; }

        [BsonElement("BirthDate")]
        [BsonIgnoreIfNull]
        public DateTime? BirthDate { get; set; }

        [BsonElement("TZ")]
        [BsonIgnoreIfNull]
        public string? TZ { get; set; }

        [BsonElement("MotherName")]
        [BsonIgnoreIfNull]
        public string? MotherName { get; set; }

        [BsonElement("FatherName")]
        [BsonIgnoreIfNull]
        public string? FatherName { get; set; }

        [BsonElement("FatherPhone")]
        [BsonIgnoreIfNull]
        public string? FatherPhone { get; set; }

        [BsonElement("MotherPhone")]
        [BsonIgnoreIfNull]
        public string? MotherPhone { get; set; }

        [BsonElement("HomePhone")]
        [BsonIgnoreIfNull]
        public string? HomePhone { get; set; }

        [BsonElement("Address")]
        [BsonIgnoreIfNull]
        public string? Address { get; set; }

        [BsonElement("InstitutionId")]
        public string? InstitutionId { get; set; }

        [BsonElement("FamilyPosition")]
        [BsonIgnoreIfNull]
        public int? FamilyPosition { get; set; }

        [BsonElement("GradeLevel")]
        [BsonIgnoreIfNull]
        public string? GradeLevel { get; set; }

        public Student()
        {
           this.Id = ObjectId.GenerateNewId().ToString();
        }
        public Student(string firstName, string lastName)
        {
            
            this.FirstName = firstName;
            this.LastName = lastName;
        }       
    }
}
