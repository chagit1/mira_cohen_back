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
    public class EligibilityAndCharacterizationService : StudentService<EligibilityAndCharacterization, EligibilityAndCharacterizationEntities>, IEligibilityAndCharacterizationService
    {
        public EligibilityAndCharacterizationService(IDataRepository<EligibilityAndCharacterization> repository, IMapper mapper)
            : base(repository, mapper)
        {
        }
    }
}
