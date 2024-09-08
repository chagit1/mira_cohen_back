﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class ParentReport
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("Student")]
        public int StudentId { get; set; }
        public virtual Student Student { get; set; } // Virtual navigation property

        public string StrengthArea { get; set; }

        public string BirthProcessAndEarlyDevelopment { get; set; }

        public string Weaning { get; set; }

        public string PreSchoolEducation { get; set; }

        public string ParamedicalSupport { get; set; }

        public string PreSchoolDifficulties { get; set; }

        public string ElementaryEducation { get; set; }

        public string ReadingAndWritingDevelopment { get; set; }

        public string UnderstandingInstructions { get; set; }

        public string ElementarySchoolDifficulties { get; set; }

        public string AcademicDifficulties { get; set; }

        public string SocialAndEmotionalDifficulties { get; set; }

        public bool WasWithoutFramework { get; set; }

        public string CurrentAcademicStatus { get; set; }

        public string CurrentReadingGap { get; set; }

        public string CurrentWritingGap { get; set; }

        public string CurrentMotivationGap { get; set; }

        public string CurrentSocialGap { get; set; }

        public string CurrentEmotionalGap { get; set; }

        public string CurrentCulturalAndLeisureGap { get; set; }
    }
}