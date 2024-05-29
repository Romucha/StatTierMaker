using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Extensions.Logging;
using StatTierMaker.Db.DTO.Requests.Lists;
using StatTierMaker.Db.DTO.Responses.Lists;
using StatTierMaker.Db.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StatTierMaker.Lib.ViewModels.Home
{
    public class HomeViewModel : ObservableObject
    {
        private readonly ILogger<HomeViewModel> logger;
        private readonly TierListService tierListService;

        private ObservableCollection<GetTierListsResponse> tierLists = default!;
        public ObservableCollection<GetTierListsResponse> TierLists
        {
            get => tierLists;
            set => SetProperty(ref tierLists, value);
        }

        public IAsyncRelayCommand<(int, int, CancellationToken)> GetTierListsCommand => new AsyncRelayCommand<(int, int, CancellationToken)>(GetTierListsAsync);

        public HomeViewModel(ILogger<HomeViewModel> logger, TierListService tierListService)
        {
            this.logger = logger;
            this.tierListService = tierListService;
        }

        public async Task GetTierListsAsync((int pageNumber, int pageSize, CancellationToken cancellationToken) request)
        {
            GetTierListsRequest getTierListsRequest = new GetTierListsRequest()
            {
                PageNumber = request.pageNumber,
                PageSize = request.pageSize
            };
            TierLists = new ObservableCollection<GetTierListsResponse>((await tierListService.GetTierLists(getTierListsRequest, request.cancellationToken)).TierLists);
        }
    }
}
