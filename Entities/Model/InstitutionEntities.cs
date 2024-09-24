using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class InstitutionEntities
    {
        public string Id { get; set; }

        public string? UserId { get; set; }

        public string InstitutionName { get; set; }

        public string Symbol { get; set; }

        public string ManagerName { get; set; }

        public string ContactPerson { get; set; }

        public string ContactPhone { get; set; }

        public string ContactEmail { get; set; }

        public string InspectorName { get; set; }

        public List<StudentEntities>? Students { get; set; }
       
    }
}
