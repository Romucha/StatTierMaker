using AutoMapper;
using Microsoft.Extensions.Logging;
using StatTierMaker.Db.DTO.Requests.Tiers;
using StatTierMaker.Db.DTO.Responses.Tiers;
using StatTierMaker.Db.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StatTierMaker.Db.Services
{
    public class TierService : BaseService
    {
        private readonly ILogger<TierService> logger;

        public TierService(IUnitOfWork unitOfWork, IMapper mapper, ILogger<TierService> logger) : base(unitOfWork, mapper)
        {
            this.logger = logger;
        }

        public async Task<GetTiersResponse> GetTiers(GetTiersRequest getTiersRequest, CancellationToken cancellationToken = default)
        {

        }

        public async Task<GetTierResponse> GetTier(GetTierRequest getTierRequest, CancellationToken cancellationToken = default)
        {

        }

        public async Task<AddTierResponse> AddTier(AddTierRequest addTierRequest, CancellationToken cancellationToken = default)
        {

        }

        public async Task<DeleteTierResponse> DeleteTier(DeleteTierRequest deleteTierRequest, CancellationToken cancellationToken = default)
        {

        }

        public async Task<UpdateTierResponse> UpdateTier(UpdateTierRequest updateTierRequest, CancellationToken cancellationToken = default)
        {

        }
    }
}
