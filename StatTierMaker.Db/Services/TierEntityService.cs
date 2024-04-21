using AutoMapper;
using Microsoft.Extensions.Logging;
using StatTierMaker.Db.DTO.Requests.Entities;
using StatTierMaker.Db.DTO.Responses.Entities;
using StatTierMaker.Db.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StatTierMaker.Db.Services
{
    public class TierEntityService : BaseService
    {
        private readonly ILogger<TierEntityService> logger;

        public TierEntityService(IUnitOfWork unitOfWork, IMapper mapper, ILogger<TierEntityService> logger) : base(unitOfWork, mapper)
        {
            this.logger = logger;
        }

        public async Task<GetTierEntitiesResponse> GetTierEntities(GetTierEntitiesRequest getTierEntitiesRequest, CancellationToken cancellationToken = default)
        {

        }

        public async Task<GetTierEntityResponse> GetTierEntity(GetTierEntityRequest getTierEntityRequest, CancellationToken cancellationToken = default)
        {

        }

        public async Task<AddTierEntityResponse> AddTierEntity(AddTierEntityRequest addTierEntityRequest, CancellationToken cancellationToken = default)
        {

        }

        public async Task<DeleteTierEntityResponse> DeleteTierEntityService(DeleteTierEntityRequest deleteTierEntityRequest, CancellationToken cancellationToken = default)
        {

        }

        public async Task<UpdateTierEntityResponse> UpdateTierEntity(UpdateTierEntityRequest updateTierEntityRequest, CancellationToken cancellationToken = default)
        {

        }
    }
}
