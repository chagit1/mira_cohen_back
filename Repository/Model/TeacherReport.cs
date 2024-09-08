using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class TeacherReport
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("Student")]
        public int StudentId { get; set; }
        public virtual Student Student { get; set; } // Virtual navigation property

        public string ReadingAndWritingSkills { get; set; }

        public string AcademicGap { get; set; }

        public string UnderstandingOfTheMaterial { get; set; }

        public string Memory { get; set; }

        public string GeneralKnowledge { get; set; }

        public string Motivation { get; set; }

        public string Vocabulary { get; set; }

        public string AcademicAchievements { get; set; }

        public string SocialAndEmotionalConduct { get; set; }

        public FamilyStatusEnum FamilyStatus { get; set; } // Enum: Divorced, Married, Separated
    }

    public enum FamilyStatusEnum
    {
        Divorced,
        Married,
        Separated
    }
}
