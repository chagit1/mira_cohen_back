using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class ParentReportRep : IDataRepository<ParentReport>
    {
        public Task<ParentReport> AddAsync(ParentReport entity)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<ParentReport>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<ParentReport> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<ParentReport> UpdateAsync(ParentReport entity)
        {
            throw new NotImplementedException();
        }
    }
}
