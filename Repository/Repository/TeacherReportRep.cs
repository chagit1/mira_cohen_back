using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository

{
    public class TeacherReportRep : IDataRepository<TeacherReport>
    {
        public Task<TeacherReport> AddAsync(TeacherReport entity)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<TeacherReport>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<TeacherReport> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<TeacherReport> UpdateAsync(TeacherReport entity)
        {
            throw new NotImplementedException();
        }
    }
}
