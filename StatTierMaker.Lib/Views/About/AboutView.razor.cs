using Microsoft.AspNetCore.Components;
using StatTierMaker.Lib.ViewModels.About;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StatTierMaker.Lib.Views.About
{
    public partial class AboutView
    {
        [Inject]
        public AboutViewModel ViewModel { get; set; } = default!;
    }
}
