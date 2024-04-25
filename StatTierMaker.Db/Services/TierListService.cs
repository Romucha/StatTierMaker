using AutoMapper;
using Microsoft.Extensions.Logging;
using StatTierMaker.Db.DTO.Requests.Lists;
using StatTierMaker.Db.DTO.Responses.Lists;
using StatTierMaker.Db.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StatTierMaker.Db.Services
{
    public class TierListService : BaseService
    {
        private readonly ILogger<TierListService> logger;

        public TierListService(IUnitOfWork unitOfWork, IMapper mapper, ILogger<TierListService> logger) : base(unitOfWork, mapper)
        {
            this.logger = logger;
        }

        public async Task<GetTierListsResponse> GetTierLists(GetTierListsRequest getTierListsRequest, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public async Task<GetTierListResponse> GetTierList(GetTierListRequest getTierListRequest, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public async Task<AddTierListResponse> AddTierList(AddTierListRequest addTierListRequest, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public async Task<DeleteTierListResponse> DeleteTierList(DeleteTierListRequest deleteTierListRequest, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public async Task<UpdateTierListResponse> UpdateTierList(UpdateTierListRequest updateTierListRequest, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }
    }
}
