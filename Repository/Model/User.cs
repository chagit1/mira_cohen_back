using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class User
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public UserRole Role { get; set; } // Enum: Manager, Client

        // Navigation Properties
        public virtual ICollection<Institution> Institutions { get; set; }
    }
        public enum UserRole
        {
         Manager,
         Client
        }
}
