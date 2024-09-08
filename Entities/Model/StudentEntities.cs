using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class StudentEntities
    {
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

        public int InstitutionId { get; set; }

        public string InstitutionName { get; set; } // For simplicity, you can include the institution name

        public int FamilyPosition { get; set; }

        public string GradeLevel { get; set; }
    }
}
