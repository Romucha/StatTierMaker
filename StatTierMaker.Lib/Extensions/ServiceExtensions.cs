using Microsoft.Extensions.DependencyInjection;
using StatTierMaker.Lib.ViewModels.Tiers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StatTierMaker.Lib.Extensions
{
    public static class ServiceExtensions
    {
        public static void AddTierMakerVisualComponentServices(this IServiceCollection serviceDescriptors)
        {
            serviceDescriptors.AddTransient<TierVM>();
        }
    }
}
