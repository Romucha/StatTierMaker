using Microsoft.AspNetCore.Components;
using StatTierMaker.Lib.ViewModels.Home;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StatTierMaker.Lib.Views.Home
{
    public partial class HomeView
    {
        [Inject]
        public HomeViewModel ViewModel { get; set; } = default!;

        protected override async Task OnInitializedAsync()
        {
            await ViewModel.GetTierListsAsync((0, 0, default));
            await base.OnInitializedAsync();
        }
    }
}
