using Microsoft.Extensions.Logging;
using StatTierMaker.API.TierFactories.Entities;
using StatTierMaker.API.TierFactories.Lists;
using StatTierMaker.API.TierFactories.Parameters;
using StatTierMaker.API.Tiers;
using StatTierMaker.Db.Repositories;
using StatTierMaker.Db.Tests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StatTierMaker.Db
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly IRepository<Tier> tierRepository;
        private readonly IRepository<TierList> listRepository;
        private readonly IRepository<TierEntity> entityRepository;
        private readonly IRepository<TierParameter> parameterRepository;
        private readonly ILogger<UnitOfWork> logger;
        private readonly ITierEntityFactory tierEntityFactory;
        private readonly ITierListFactory tierListFactory;
        private readonly ITierParameterFactory tierParameterFactory;

        public UnitOfWork(
            IRepository<Tier> tierRepository, 
            IRepository<TierList> listRepository, 
            IRepository<TierEntity> entityRepository,
            IRepository<TierParameter> parameterRepository,
            ILogger<UnitOfWork> logger,
            ITierEntityFactory tierEntityFactory,
            ITierListFactory tierListFactory,
            ITierParameterFactory tierParameterFactory)
        {
            this.tierRepository = tierRepository;
            this.listRepository = listRepository;
            this.entityRepository = entityRepository;
            this.parameterRepository = parameterRepository;
            this.logger = logger;
            this.tierEntityFactory = tierEntityFactory;
            this.tierListFactory = tierListFactory;
            this.tierParameterFactory = tierParameterFactory;
        }
    }
}
