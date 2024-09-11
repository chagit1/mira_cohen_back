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
    public class EligibilityAndCharacterizationRep : StudentRep<EligibilityAndCharacterization>
    {
        public EligibilityAndCharacterizationRep(IContext context)
        : base(context)
        {
        }
    }
}
