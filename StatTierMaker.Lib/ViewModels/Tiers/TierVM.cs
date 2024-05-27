using AutoMapper;
using CommunityToolkit.Mvvm.ComponentModel;
using StatTierMaker.API.Tiers;
using StatTierMaker.Db.DTO.Requests.Tiers;
using StatTierMaker.Db.DTO.Responses.Lists;
using StatTierMaker.Db.DTO.Responses.Tiers;
using StatTierMaker.Db.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StatTierMaker.Lib.ViewModels.Tiers
{
    public class TierVM : ObservableObject
    {
        private readonly TierListService tierService;
        private readonly IMapper mapper;
        private GetTierListResponse tierList = default!;
        public GetTierListResponse TierList
        {
            get => tierList;
            set => SetProperty(ref tierList, value);
        }

        public TierVM(TierListService tierService, IMapper mapper)
        {
            this.tierService = tierService;
            this.mapper = mapper;
            var request = new Db.DTO.Requests.Lists.AddTierListRequest
            {
                Name = "The tier",
                Description = "",
                Entities = { },
                Tiers = { }
            };
            var response = tierService.AddTierList(request).Result;
            TierList = tierService.GetTierList(new Db.DTO.Requests.Lists.GetTierListRequest
            {
                Id = response.Id,
            }).Result;
        }
    }
}
