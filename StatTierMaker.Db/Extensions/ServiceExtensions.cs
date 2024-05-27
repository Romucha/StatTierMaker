using Microsoft.Extensions.DependencyInjection;
using StatTierMaker.API.Calculator;
using StatTierMaker.API.Extensions;
using StatTierMaker.API.Validation;
using StatTierMaker.Db.Mapping;
using StatTierMaker.Db.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StatTierMaker.Db.Extensions
{
    public static class ServiceExtensions
    {
        public static void AddTierMakerDbServices(this IServiceCollection serviceDescriptors)
        {
            serviceDescriptors.AddScoped<TierParameterService>();
            serviceDescriptors.AddScoped<TierEntityService>();
            serviceDescriptors.AddScoped<TierService>();
            serviceDescriptors.AddScoped<TierListService>();

            serviceDescriptors.AddTierMakerAPIServices();

            serviceDescriptors.AddAutoMapper(typeof(TierMapperProfile));

            string dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), "StatTierMaker");
            if (!Directory.Exists(dbPath))
            {
                Directory.CreateDirectory(dbPath);
            }
            serviceDescriptors.AddSqlite<TierDbContext>($"Data Source={Path.Combine(dbPath, "StatTierMaker.db")}");
        }
    }
}
