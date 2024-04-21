using StatTierMaker.API.Tiers;
using StatTierMaker.Db.DTO.Requests.Entities;
using StatTierMaker.Db.DTO.Requests.Tiers;
using StatTierMaker.Db.DTO.Responses.Entities;
using StatTierMaker.Db.DTO.Responses.Lists;
using StatTierMaker.Db.DTO.Responses.Tiers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StatTierMaker.Db.Repositories
{
    public interface IUnitOfWork
    {
        IRepository<TierList> TierListRepository { get; }
        IRepository<Tier> TierRepository { get; }

        IRepository<TierEntity> TierEntityRepository { get; }

        IRepository<TierParameter> TierParameterRepository { get; }

        Task SaveChangesAsync(CancellationToken cancellationToken);
    }
}
