using Microsoft.Extensions.Logging;
using StatTierMaker.API.TierFactories.Parameters;
using StatTierMaker.API.Tiers;
using StatTierMaker.API.TierTemplates;
using StatTierMaker.API.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StatTierMaker.API.Tests.TierFactories.Parameters
{
    public class TierEntityParameterFactoryTests
    {
        private readonly ILogger<TierParameterFactory> factoryLogger;
        private readonly IValidator validator;

        public TierEntityParameterFactoryTests()
        {
            factoryLogger = new LoggerFactory().CreateLogger<TierParameterFactory>();
            var validatorLogger = new LoggerFactory().CreateLogger<TierValidator>();
            validator = new TierValidator(validatorLogger);
        }

        [Fact]
        public async Task CreateAsync_Normal()
        {
            //arrange
            ITierParameterFactory tierEntityParameterFactory = new TierParameterFactory(factoryLogger, validator);
            var tierParameterTemplate = new TierParameterTemplate()
            {
                Name = "Test name",
                Description = "Test description",
                Coefficient = 1,
            };
            TierValue tierValue = TierValue.A;
            //act
            var result = await tierEntityParameterFactory.CreateAsync(tierParameterTemplate, tierValue);
            //assert
            Assert.NotNull(result);
            Assert.Equal(tierParameterTemplate.Name, result.Name);
            Assert.Equal(tierParameterTemplate.Description, result.Description);
            Assert.Equal(tierValue, result.Value);
            Assert.Equal(tierParameterTemplate.Coefficient, result.Coefficient);
        }
    }
}
