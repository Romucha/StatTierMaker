using Microsoft.Extensions.Logging;
using StatTierMaker.API.TierFactories.Lists;
using StatTierMaker.API.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace StatTierMaker.API.Tests.TierFactories.Lists
{
    public class TierListFactoryTests
    {
        private readonly ILogger<TierListFactory> factoryLogger;
        private readonly IValidator validator;

        public TierListFactoryTests() 
        {
            factoryLogger = new LoggerFactory().CreateLogger<TierListFactory>();
            var validatorLogger = new LoggerFactory().CreateLogger<TierValidator>();
            validator = new TierValidator(validatorLogger);
        }

        [Fact]
        public async Task CreateAsync_Normal()
        {
            //arrange
            ITierListFactory tierListFactory = new TierListFactory(factoryLogger, validator);
            var name = "Test name";
            var description = " Test description";
            //act
            var result = await tierListFactory.CreateAsync(name, description);
            //assert
            Assert.NotNull(result);
            Assert.Equal(name, result.Name);
            Assert.Equal(description, result.Description);
            Assert.NotNull(result.Tiers);
            Assert.NotEmpty(result.Tiers);
            Assert.NotNull(result.Entities);
            Assert.Empty(result.Entities);
        }
    }
}
