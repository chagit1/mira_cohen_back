using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public interface IEligibilityAndCharacterizationService : IStudentService
    {
        Task<List<EligibilityAndCharacterizationEntities>> GetAllAsync();
        Task<EligibilityAndCharacterizationEntities> GetByIdAsync(string id);
        Task<EligibilityAndCharacterizationEntities> UpdateAsync(EligibilityAndCharacterizationEntities eligibilityAndCharacterizationEntities);


    }
}
