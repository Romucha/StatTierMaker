using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;
using StatTierMaker.API.TierTemplateFactories.Entities;
using StatTierMaker.API.TierTemplateFactories.Lists;
using StatTierMaker.API.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StatTierMaker.API.Tests.TierTemplateFactories.Lists
{
    public class TierListTemplateFactoryTests
    {
        private readonly ILogger<TierListTemplateFactory> factoryLogger;
        private readonly ILogger<TierValidator> validatorLogger;
        private readonly IValidator validator;

        public TierListTemplateFactoryTests()
        {
            this.factoryLogger = new NullLoggerFactory().CreateLogger<TierListTemplateFactory>();
            this.validatorLogger = new NullLoggerFactory().CreateLogger<TierValidator>();
            this.validator = new TierValidator(validatorLogger);
        }

        [Theory]
        [InlineData("Test name", "Test description")]
        [InlineData("Test name", "")]
        public async Task CreateAsync_Normal(string? name, string? description)
        {
            //arrange
            ITierListTemplateFactory tierListTemplateFactory = new TierListTemplateFactory(factoryLogger, validator);
            //act
            var result = await tierListTemplateFactory.CreateAsync(name, description);
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
            ITierListTemplateFactory tierListTemplateFactory = new TierListTemplateFactory(factoryLogger, validator);
            //act & assert
            await Assert.ThrowsAsync<ValidationException>(async () => await tierListTemplateFactory.CreateAsync(name, description));
        }
    }
}
