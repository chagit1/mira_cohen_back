using AutoMapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Claims;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using Repository;
using Entities;

namespace Service
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<User, UserEntities>().ReverseMap();
            CreateMap<UserRole, UserRoleEntities>().ReverseMap();
            CreateMap<TeacherReport, TeacherReportEntities>().ReverseMap();
            CreateMap<FamilyStatusEnum, FamilyStatusEnumEntities>().ReverseMap();
            CreateMap<Student, StudentEntities>().ReverseMap();
            CreateMap<ParentReport, ParentReportEntities>().ReverseMap();
            CreateMap<Institution, InstitutionEntities>().ReverseMap();
            CreateMap<HelpHours, HelpHoursEntities>().ReverseMap();
            CreateMap<EligibilityAndCharacterization, EligibilityAndCharacterizationEntities>().ReverseMap();
            
        }
    }
}
