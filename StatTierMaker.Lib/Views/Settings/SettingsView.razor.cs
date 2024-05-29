using Microsoft.AspNetCore.Components;
using StatTierMaker.Lib.ViewModels.Settings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StatTierMaker.Lib.Views.Settings
{
    public partial class SettingsView
    {
        [Inject]
        public SettingsViewModel ViewModel { get; set; } = default!;
    }
}
