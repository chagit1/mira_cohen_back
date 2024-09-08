
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public static class ServicesRepositoriesCollection
    {
        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<IDataRepository<User>, UserRep>();
            services.AddScoped<IDataRepository<TeacherReport>, TeacherReportRep>();
            services.AddScoped<IDataRepository<Student>, StudentRep<Student>>();
            services.AddScoped<IDataRepository<ParentReport>, ParentReportRep>();
            services.AddScoped<IDataRepository<Institution>, InstitutionRep>();
            services.AddScoped<IDataRepository<HelpHours>, HelpHoursRep>();
            services.AddScoped<IDataRepository<EligibilityAndCharacterization>, EligibilityAndCharacterizationRep>();
            return services;

        }
        public static string ToStringProperties<T>(this T obj)
        {
            string str = "";//קבלת רשימת המאפיינים של העצם
            foreach (var item in obj.GetType().GetProperties())
            {
                str += item.Name;
                if (item.PropertyType.IsArray)
                {//התיחסות  למקרה של  אוספים
                    var q = item.GetValue(obj);

                    string s = String.Join(',', q as string[]);
                    str += "\n" + s;
                }
                else
                    //שרשור על ידי קבלת הערך מהמאפיןן
                    str += item.Name + ":" + item?.GetValue(obj) + ",";
            }
            return str.Remove(str.Length - 1);
        }
    }
}