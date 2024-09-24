
using Entities;
using Microsoft.Extensions.DependencyInjection;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public static class ServiceCollectionExtentions
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {

            services.AddRepositories();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<ITeacherReportService, TeacherReportService>();
            services.AddScoped<IStudentService, StudentService>();
            services.AddScoped<IParentReportService, ParentReportService>();
            services.AddScoped<IInstitutionService, InstitutionService>();
            services.AddScoped<IHelpHoursService, HelpHoursService>();
            services.AddScoped<IEligibilityAndCharacterizationService, EligibilityAndCharacterizationService>();

            services.AddAutoMapper(typeof(MappingProfile));
            return services;
        }
    }
}
