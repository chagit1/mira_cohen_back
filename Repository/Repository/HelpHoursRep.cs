using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class HelpHoursRep : Student, IDataRepository<HelpHours>
    {
        public Task<HelpHours> AddAsync(HelpHours entity)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<HelpHours>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<HelpHours> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<HelpHours> UpdateAsync(HelpHours entity)
        {
            throw new NotImplementedException();
        }
    }
}
