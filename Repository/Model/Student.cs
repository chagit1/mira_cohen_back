using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class Student
    {
        [Key]
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public DateTime BirthDate { get; set; }

        public string IdNumber { get; set; }

        public string MotherName { get; set; }

        public string FatherName { get; set; }

        public string FatherPhone { get; set; }

        public string MotherPhone { get; set; }

        public string HomePhone { get; set; }

        public string Address { get; set; }

        [ForeignKey("Institution")]
        public int InstitutionId { get; set; }
        public virtual Institution Institution { get; set; } // Virtual navigation property

        public int FamilyPosition { get; set; }

        public string GradeLevel { get; set; }

        // Navigation Properties
        public virtual ICollection<EligibilityAndCharacterization> Eligibilities { get; set; } // A student can have multiple eligibilities
        public virtual ICollection<HelpHours> AssistanceHours { get; set; } // A student can have multiple assistance hours
        public virtual ParentReport ParentReport { get; set; } // A student can have one parent report
        public virtual TeacherReport TeacherReport { get; set; } // A student can have one teacher report
    }
}
