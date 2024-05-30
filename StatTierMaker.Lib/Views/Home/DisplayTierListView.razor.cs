using Microsoft.AspNetCore.Components;
using StatTierMaker.Db.DTO.Responses.Lists;
using StatTierMaker.Lib.ViewModels.Home;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StatTierMaker.Lib.Views.Home
{
    public partial class DisplayTierListView
    {
        [Parameter]
        public GetTierListsResponse TierList { get; set; } = default!;

        [Inject]
        public DisplayTierListViewModel ViewModel { get; set; } = default!;

        protected override async Task OnInitializedAsync()
        {
            ViewModel.TierList = TierList;
            ViewModel.PropertyChanged += (o, e) => this.StateHasChanged();
            await base.OnInitializedAsync();
        }
    }
}
