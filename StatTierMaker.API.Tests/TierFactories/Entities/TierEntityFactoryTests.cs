using Microsoft.Extensions.Logging;
using StatTierMaker.API.TierFactories.Entities;
using StatTierMaker.API.TierTemplates;
using StatTierMaker.API.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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

        [Theory]
        [InlineData("Test name", "Test description")]
        [InlineData("Test name", "")]
        public async Task CreateAsync_Normal(string? name, string? description)
        {
            //arrange
            ITierEntityFactory tierEntityFactory = new TierEntityFactory(factorylogger, validator);
            //act
            var result = await tierEntityFactory.CreateAsync(name, description);
            //assert
            Assert.NotNull(result);
            Assert.Equal(name, result.Name);
            Assert.Equal(description, result.Description);
        }

        [Theory]
        [InlineData("", "Test description")]
        [InlineData(null, "Test description")]
        [InlineData("Test name", null)]
        public async Task CreateAsync_ThrowsException_WhenParametersAreInvalid(string? name, string? description)
        {
            //arrange
            ITierEntityFactory tierEntityFactory = new TierEntityFactory(factorylogger, validator);
            //act & assert
            await Assert.ThrowsAsync<ValidationException>(async () => await tierEntityFactory.CreateAsync(name, description));
        }
    }
}
