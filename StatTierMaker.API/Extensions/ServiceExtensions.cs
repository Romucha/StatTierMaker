using Microsoft.Extensions.DependencyInjection;
using StatTierMaker.API.Calculator;
using StatTierMaker.API.TierFactories.Entities;
using StatTierMaker.API.TierFactories.Lists;
using StatTierMaker.API.TierFactories.Parameters;
using StatTierMaker.API.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StatTierMaker.API.Extensions
{
    public static class ServiceExtensions
    {
        public static void AddTierMakerAPIServices(this IServiceCollection serviceDescriptors)
        {
            serviceDescriptors.AddScoped<ITierCalculator, TierCalculator>();
            serviceDescriptors.AddScoped<IEntityWeightCalculator, EntityWeightCalculator>();
            serviceDescriptors.AddScoped<IValidator, TierValidator>();

            serviceDescriptors.AddTransient<ITierEntityFactory, TierEntityFactory>();
            serviceDescriptors.AddTransient<ITierListFactory, TierListFactory>();
            serviceDescriptors.AddTransient<ITierParameterFactory, TierParameterFactory>();
        }
    }
}
