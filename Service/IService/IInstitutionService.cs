using Entities;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public interface IInstitutionService
    {
        Task<List<InstitutionEntities>> GetAllAsync();
        Task<InstitutionEntities> GetByIdAsync(string id);
        Task<InstitutionEntities> AddAsync(InstitutionEntities dto);
        Task<InstitutionEntities> UpdateAsync(InstitutionEntities dto);
        Task<bool> DeleteAsync(string id);
        Task<Institution> AddInstitutionAsync(InstitutionEntities institutionDto);
    }
}
