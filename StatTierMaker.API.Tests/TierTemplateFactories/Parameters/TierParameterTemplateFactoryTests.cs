using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;
using StatTierMaker.API.TierTemplateFactories.Lists;
using StatTierMaker.API.TierTemplateFactories.Parameters;
using StatTierMaker.API.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StatTierMaker.API.Tests.TierTemplateFactories.Parameters
{
    public class TierParameterTemplateFactoryTests
    {
        private readonly ILogger<TierParameterTemplateFactory> factoryLogger;
        private readonly ILogger<TierValidator> validatorLogger;
        private readonly IValidator validator;

        public TierParameterTemplateFactoryTests()
        {
            this.factoryLogger = new NullLoggerFactory().CreateLogger<TierParameterTemplateFactory>();
            this.validatorLogger = new NullLoggerFactory().CreateLogger<TierValidator>();
            this.validator = new TierValidator(validatorLogger);
        }

        [Theory]
        [InlineData("Test name", "Test description", 0.5)]
        [InlineData("Test name", "", 1)]
        public async Task CreateAsync_Normal(string? name, string? description, double coefficient)
        {
            //arrange
            ITierParameterTemplateFactory tierParameterTemplateFactory = new TierParameterTemplateFactory(factoryLogger, validator);
            //act
            var result = await tierParameterTemplateFactory.CreateAsync(name, description, coefficient);
            //assert
            Assert.NotNull(result);
            Assert.Equal(name, result.Name);
            Assert.Equal(description, result.Description);
            Assert.Equal(coefficient, result.Coefficient);
        }

        [Theory]
        [InlineData("", "Test description", 1)]
        [InlineData(null, "Test description", 1)]
        [InlineData("Test name", null, 1)]
        [InlineData("Test name", "Test description", 0)]
        [InlineData("Test name", "Test description", -1)]
        public async Task CreateAsync_ThrowsException_WhenParametersAreInvalid(string? name, string? description, double coefficient)
        {
            //arrange
            ITierParameterTemplateFactory tierParameterTemplateFactory = new TierParameterTemplateFactory(factoryLogger, validator);
            //act & assert
            await Assert.ThrowsAsync<ValidationException>(async () => await tierParameterTemplateFactory.CreateAsync(name, description, coefficient));
        }
    }
}
