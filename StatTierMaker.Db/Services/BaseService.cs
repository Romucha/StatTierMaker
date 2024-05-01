using AutoMapper;
using Microsoft.Extensions.Logging;
using StatTierMaker.API.Validation;
using StatTierMaker.Db.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StatTierMaker.Db.Services
{
    public abstract class BaseService
    {
        protected readonly IUnitOfWork UnitOfWork;
        protected readonly IMapper Mapper;
        protected readonly IValidator Validator;

        public BaseService(IUnitOfWork unitOfWork, IMapper mapper, IValidator validator)
        {
            this.UnitOfWork = unitOfWork;
            this.Mapper = mapper;
            this.Validator = validator;
        }
    }
}
