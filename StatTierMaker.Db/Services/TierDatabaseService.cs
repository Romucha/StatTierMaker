using AutoMapper;
using Microsoft.Extensions.Logging;
using StatTierMaker.Db.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StatTierMaker.Db.Services
{
    public class TierDatabaseService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly ILogger<TierDatabaseService> logger;
        private readonly IMapper mapper;

        public TierDatabaseService(IUnitOfWork unitOfWork, ILogger<TierDatabaseService> logger, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.logger = logger;
            this.mapper = mapper;
        }
        //TBD
        //add methods with mapped parameters here
    }
}
