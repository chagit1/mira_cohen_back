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
          : base(context.HelpHours)
        {
        }
    }
}
