using Microsoft.Extensions.Logging.Abstractions;
using StatTierMaker.Db.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StatTierMaker.Db.Tests.Services.Entities
{
    public partial class TierEntityServiceTests : BaseServiceTests
    {
        private readonly TierEntityService tierEntityService;

        public TierEntityServiceTests() : base()
        {
            tierEntityService = new TierEntityService(UnitOfWork, Mapper, new NullLogger<TierEntityService>(), Validator);
        }
    }
}
