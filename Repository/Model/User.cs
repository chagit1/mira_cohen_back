using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public enum UserRole
    {
        Manager,
        Client
    }
    public class User
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("Name")]
        public string Name { get; set; }

        [BsonElement("Email")]
        [BsonIgnoreIfNull]
        public string? Email { get; set; }

        [BsonElement("Password")]
        [BsonIgnoreIfNull]
        public string? Password { get; set; }

        [BsonElement("Role")]
        [BsonIgnoreIfNull]
        public UserRole? Role { get; set; }

        [BsonElement("Institutions")]
        [BsonIgnoreIfNull]
        public List<Institution>? Institutions { get; set; }

        public User(string name, string email, string password)
        {
            this.Name = name;
            this.Email = email;
            this.Password = password;
        }
    }
       
}
