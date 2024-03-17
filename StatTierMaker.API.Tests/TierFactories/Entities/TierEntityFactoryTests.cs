using Microsoft.Extensions.Logging;
using StatTierMaker.API.TierFactories.Entities;
using StatTierMaker.API.TierTemplates;
using StatTierMaker.API.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StatTierMaker.API.Tests.TierFactories.Entities
{
    public class TierEntityFactoryTests
    {
        private ILogger<TierEntityFactory> factorylogger;
        private readonly IValidator validator;

        public TierEntityFactoryTests()
        {
            factorylogger = new LoggerFactory().CreateLogger<TierEntityFactory>();
            var validatorLogger = new LoggerFactory().CreateLogger<TierValidator>();
            validator = new TierValidator(validatorLogger);
        }

        [Fact]
        public async Task CreateAsync_Normal()
        {
            //arrange
            var name = "Test name";
            var description = "Test description";
            ITierEntityFactory tierEntityFactory = new TierEntityFactory(factorylogger, validator);
            //act
            var result = await tierEntityFactory.CreateAsync(name, description);
            //assert
            Assert.NotNull(result);
            Assert.Equal(name, result.Name);
            Assert.Equal(description, result.Description);
        }
    }
}
