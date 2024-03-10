using Microsoft.Extensions.Logging;
using StatTierMaker.API.TierFactories.Parameters;
using StatTierMaker.API.Tiers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StatTierMaker.API.Tests.TierFactories.Parameters
{
    public class TierEntityParameterFactoryTests
    {
        private readonly ILogger<TierEntityParameterFactory> mockLogger;

        public TierEntityParameterFactoryTests()
        {
            mockLogger = new LoggerFactory().CreateLogger<TierEntityParameterFactory>();
        }

        [Fact]
        public async Task CreateAsync_Normal()
        {
            //arrange
            ITierEntityParameterFactory tierEntityParameterFactory = new TierEntityParameterFactory(mockLogger);
            var name = "Test name";
            var description = "Test description";
            var value = TierValues.F;
            var coefficient = 1;
            //act
            var result = await tierEntityParameterFactory.CreateAsync(name, description, value, coefficient);
            //assert
            Assert.NotNull(result);
            Assert.Equal(name, result.Name);
            Assert.Equal(description, result.Description);
            Assert.Equal(value, result.Value);
            Assert.Equal(coefficient, result.Coefficient);
        }
    }
}
