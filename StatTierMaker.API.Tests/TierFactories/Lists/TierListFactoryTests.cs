using Microsoft.Extensions.Logging;
using StatTierMaker.API.TierFactories.Lists;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StatTierMaker.API.Tests.TierFactories.Lists
{
    public class TierListFactoryTests
    {
        private readonly ILogger<TierListFactory> mockLogger;

        public TierListFactoryTests() 
        {
            mockLogger = new LoggerFactory().CreateLogger<TierListFactory>();
        }

        [Fact]
        public async Task CreateAsync_Normal()
        {
            //arrange
            ITierListFactory tierListFactory = new TierListFactory(mockLogger);
            var name = "Test name";
            var description = " Test description";
            //act
            var result = await tierListFactory.CreateAsync(name, description);
            //assert
            Assert.NotNull(result);
            Assert.Equal(name, result.Name);
            Assert.Equal(description, result.Description);
        }
    }
}
