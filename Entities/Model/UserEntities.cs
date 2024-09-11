using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class UserEntities
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public UserRoleEntities? Role { get; set; } // String representation of UserRole enum

        public UserEntities(string name, string email, string password)
        {
            this.Name = name;
            this.Email = email;
            this.Password = password;
        }
    }
    public enum UserRoleEntities
    {
        Manager,
        Client
    }
}
