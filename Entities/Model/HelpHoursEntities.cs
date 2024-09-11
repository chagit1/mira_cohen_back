using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class HelpHoursEntities : StudentEntities
    {

        public string StrengthAreas { get; set; }

        public string AreasForImprovement { get; set; }

        public string AcademicAchievements { get; set; }
        public HelpHoursEntities(string strengthAreas)
        {
            this.StrengthAreas = strengthAreas;
        }
    }
}
