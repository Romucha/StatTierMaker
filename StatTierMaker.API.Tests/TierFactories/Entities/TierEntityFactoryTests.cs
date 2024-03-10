using Microsoft.Extensions.Logging;
using StatTierMaker.API.TierFactories.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StatTierMaker.API.Tests.TierFactories.Entities
{
    public class TierEntityFactoryTests
    {
        private ILogger<TierEntityFactory> mocklogger;

        public TierEntityFactoryTests()
        {
            mocklogger = new LoggerFactory().CreateLogger<TierEntityFactory>();
        }

        [Fact]
        public async Task CreateAsync_Normal()
        {
            //arrange
            var name = "Test name";
            var description = "Test description";
            ITierEntityFactory tierEntityFactory = new TierEntityFactory(mocklogger);
            //act
            var result = await tierEntityFactory.CreateAsync(name, description);
            //assert
            Assert.NotNull(result);
            Assert.Equal(name, result.Name);
            Assert.Equal(description, result.Description);
        }
    }
}
