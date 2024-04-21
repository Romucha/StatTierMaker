using AutoMapper;
using Microsoft.Extensions.Logging;
using StatTierMaker.Db.DTO.Requests.Parameters;
using StatTierMaker.Db.DTO.Requests.Tiers;
using StatTierMaker.Db.DTO.Responses.Parameters;
using StatTierMaker.Db.DTO.Responses.Tiers;
using StatTierMaker.Db.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StatTierMaker.Db.Services
{
    public class TierParameterService : BaseService
    {
        private readonly ILogger<TierParameterService> logger;

        public TierParameterService(IUnitOfWork unitOfWork, IMapper mapper, ILogger<TierParameterService> logger) : base(unitOfWork, mapper)
        {
            this.logger = logger;
        }

        public async Task<GetTierParameterResponse> GetTierParameter(GetTierParameterRequest getTierParameterRequest, CancellationToken cancellationToken = default)
        {

        }

        public async Task<GetTierParametersResponse> GetTierParameters(GetTierParametersRequest getTierParametersRequest, CancellationToken cancellationToken = default)
        {

        }

        public async Task<AddTierParameterResponse> AddTierParameter(AddTierParameterRequest addTierParameterRequest, CancellationToken cancellationToken = default)
        {

        }

        public async Task<DeleteTierParameterResponse> DeleteTier(DeleteTierParameterRequest deleteTierParameterRequest, CancellationToken cancellationToken = default)
        {

        }

        public async Task<UpdateTierParameterResponse> UpdateTier(UpdateTierParameterRequest updateTierParameterRequest, CancellationToken cancellationToken = default)
        {

        }
    }
}
