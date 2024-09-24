using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class StudentEntities
        //: IEtity
    {
        public string Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public DateTime BirthDate { get; set; }

        public string TZ { get; set; }

        public string MotherName { get; set; }

        public string FatherName { get; set; }

        public string FatherPhone { get; set; }

        public string MotherPhone { get; set; }

        public string HomePhone { get; set; }

        public string Address { get; set; }

        public string? InstitutionId { get; set; }

        public int FamilyPosition { get; set; }

        [ForeignKey("GradeLevel")]
        public string GradeLevel { get; set; }

        public StudentEntities()
        {

        }
        public StudentEntities(string firstName, string lastName)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
        }
    }
}
