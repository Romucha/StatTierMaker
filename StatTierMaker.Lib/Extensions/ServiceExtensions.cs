using Microsoft.Extensions.DependencyInjection;
using StatTierMaker.Lib.ViewModels.About;
using StatTierMaker.Lib.ViewModels.Home;
using StatTierMaker.Lib.ViewModels.Settings;
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
            serviceDescriptors.AddTransient<AboutViewModel>();
            serviceDescriptors.AddTransient<HomeViewModel>();
            serviceDescriptors.AddTransient<SettingsViewModel>();
            serviceDescriptors.AddTransient<DisplayTierListViewModel>();
        }
    }
}
