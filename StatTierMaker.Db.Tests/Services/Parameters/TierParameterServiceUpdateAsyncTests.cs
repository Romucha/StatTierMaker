using Microsoft.Extensions.Logging.Abstractions;
using StatTierMaker.API.Tiers;
using StatTierMaker.Db.Services;
using StatTierMaker.Tests.Common.TestAPIData.Entities;
using StatTierMaker.Tests.Common.TestAPIData.Parameters;
using StatTierMaker.Tests.Common.TestDbData.Parameters.Add;
using StatTierMaker.Tests.Common.TestDbData.Parameters.Delete;
using StatTierMaker.Tests.Common.TestDbData.Parameters.Get;
using StatTierMaker.Tests.Common.TestDbData.Parameters.GetAll;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StatTierMaker.Db.Tests.Services.Parameters
{
    public partial class TierParameterServiceTests
    {
        [Fact]
        public async Task UpdateAsync_Normal()
        {
            Assert.Fail();
        }

        [Fact]
        public async Task UpdateAsync_ThrowsException_WhenRequestIsInvalid()
        {
            Assert.Fail();
        }

        [Fact]
        public async Task UpdateAsync_ThrowsException_WhenRequestIsDefault()
        {
            Assert.Fail();
        }

        [Fact]
        public async Task UpdateAsync_ThrowsException_WhenRequestIsNull()
        {
            Assert.Fail();
        }
    }
}
