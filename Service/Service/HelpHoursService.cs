using AutoMapper;
using Entities;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class HelpHoursService : StudentService<HelpHours, HelpHoursEntities>, IHelpHoursService
    {
        public HelpHoursService(IDataRepository<HelpHours> repository, IMapper mapper)
            : base(repository, mapper)
        {
        }
    }
}
