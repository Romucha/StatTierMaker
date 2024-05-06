using Microsoft.Extensions.Logging.Abstractions;
using StatTierMaker.Db.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StatTierMaker.Db.Tests.Services.Tiers
{
    public partial class TierServiceTests : BaseServiceTests
    {
        private readonly TierService tierService;

        public TierServiceTests()
        {
            tierService = new TierService(UnitOfWork, Mapper, new NullLogger<TierService>(), Validator);
        }
    }
}
