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

        public UserRoleEntities? Role { get; set; }

        public InstitutionEntities? Institutions { get; set; }

    }
    public enum UserRoleEntities
    {
        Manager,
        Client
    }
}
