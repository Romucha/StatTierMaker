using Microsoft.Extensions.Logging.Abstractions;
using StatTierMaker.Db.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StatTierMaker.Db.Tests.Services.Parameters
{
    public partial class TierParameterServiceTests : BaseServiceTests
    {
        private readonly TierParameterService tierParameterService;

        public TierParameterServiceTests()
        {
            tierParameterService = new TierParameterService(UnitOfWork, Mapper, new NullLogger<TierParameterService>());
        }
    }
}
