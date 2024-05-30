using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using StatTierMaker.Db.DTO.Requests.Lists;
using StatTierMaker.Db.DTO.Responses.Lists;
using StatTierMaker.Db.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StatTierMaker.Lib.ViewModels.Home
{
    public class DisplayTierListViewModel : ObservableObject
    {
        private readonly TierListService tierListService;

        private GetTierListsResponse tierList = default!;
        public GetTierListsResponse TierList
        {
            get => tierList;
            set => SetProperty(ref tierList, value);
        }

        public DisplayTierListViewModel(TierListService tierListService)
        {
            this.tierListService = tierListService;
        }

        public IAsyncRelayCommand<int> DeleteTierListCommand => new AsyncRelayCommand<int>(deleteTierList);

        private async Task deleteTierList(int id)
        {
            DeleteTierListRequest deleteTierListRequest = new DeleteTierListRequest()
            {
                Id = id
            };
            var response = await tierListService.DeleteTierList(deleteTierListRequest);
        }
    }
}
