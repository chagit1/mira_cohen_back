using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class InstitutionRep : IDataRepository<Institution>
    {
        public Task<Institution> AddAsync(Institution entity)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Institution>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Institution> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Institution> UpdateAsync(Institution entity)
        {
            throw new NotImplementedException();
        }
    }
}
