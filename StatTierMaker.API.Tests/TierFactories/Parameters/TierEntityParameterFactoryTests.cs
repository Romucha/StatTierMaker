using Microsoft.Extensions.Logging;
using StatTierMaker.API.TierFactories.Parameters;
using StatTierMaker.API.Tiers;
using StatTierMaker.API.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

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
            var name = "Test name";
            var description = "Test description";
            var coefficient = 1;
            TierValue tierValue = TierValue.F;
            //act
            var result = await tierEntityParameterFactory.CreateAsync(name, description, coefficient);
            //assert
            Assert.NotNull(result);
            Assert.Equal(name, result.Name);
            Assert.Equal(description, result.Description);
            Assert.Equal(tierValue, result.Value);
            Assert.Equal(coefficient, result.Coefficient);
        }
    }
}
