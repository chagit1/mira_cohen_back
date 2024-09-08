using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class Institution
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("User")]
        public int UserId { get; set; }
        public virtual User User { get; set; } // Virtual navigation property

        public string InstitutionName { get; set; }

        public string Symbol { get; set; }

        public string ManagerName { get; set; }

        public string ContactPerson { get; set; }

        public string ContactPhone { get; set; }

        public string ContactEmail { get; set; }

        public string SupervisorName { get; set; }

        // Navigation Properties
        public virtual ICollection<Student> Students { get; set; }
    }
}
