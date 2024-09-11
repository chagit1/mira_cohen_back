using Microsoft.Extensions.Options;
using MongoDB.Driver;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class HelpHoursRep : StudentRep<HelpHours>
    {
        public HelpHoursRep(IContext context)
       : base(context) // פשוט להעביר את ה-context למחלקת הבסיס
        {
        }
        //public HelpHoursRep(IOptions<MiraCohenDatabaseSettings> miraCohenDatabaseSettings):base(miraCohenDatabaseSettings)
        //{
        //var mongoClient = new MongoClient(miraCohenDatabaseSettings.Value.ConnectionString);
        //var mongoDatabase = mongoClient.GetDatabase(miraCohenDatabaseSettings.Value.DatabaseName);
        //_collection = mongoDatabase.GetCollection<HelpHours>(miraCohenDatabaseSettings.Value.HelpHoursCollectionName);
        //}




    }
}
