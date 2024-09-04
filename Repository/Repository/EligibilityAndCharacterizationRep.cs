using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class EligibilityAndCharacterizationRep : Student, IDataRepository<EligibilityAndCharacterization>
    {
        public Task<EligibilityAndCharacterization> AddAsync(EligibilityAndCharacterization entity)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<EligibilityAndCharacterization>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<EligibilityAndCharacterization> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<EligibilityAndCharacterization> UpdateAsync(EligibilityAndCharacterization entity)
        {
            throw new NotImplementedException();
        }
    }
}
