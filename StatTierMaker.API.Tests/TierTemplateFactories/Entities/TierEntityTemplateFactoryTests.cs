using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;
using StatTierMaker.API.TierTemplateFactories.Entities;
using StatTierMaker.API.TierTemplates;
using StatTierMaker.API.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StatTierMaker.API.Tests.TierTemplateFactories.Entities
{
    public class TierEntityTemplateFactoryTests
    {
        private readonly ILogger<TierEntityTemplateFactory> factoryLogger;
        private readonly ILogger<TierValidator> validatorLogger;
        private readonly IValidator validator;

        public TierEntityTemplateFactoryTests()
        {
            this.factoryLogger = new NullLoggerFactory().CreateLogger<TierEntityTemplateFactory>();
            this.validatorLogger = new NullLoggerFactory().CreateLogger<TierValidator>();
            this.validator = new TierValidator(validatorLogger);
        }

        [Fact]
        public async Task CreateAsync_Normal()
        {
            //arrange
            ITierEntityTemplateFactory tierEntityTemplateFactory = new TierEntityTemplateFactory(factoryLogger, validator);
            ICollection<TierParameterTemplate> parameterTemplates = new List<TierParameterTemplate>();
            //act
            var result = await tierEntityTemplateFactory.CreateAsync(parameterTemplates);
            //assert
            Assert.NotNull(result);
            Assert.NotNull(result.TierParameterTemplates);
            Assert.Empty(result.TierParameterTemplates);
        }

        [Fact]
        public async Task CreateAsync_ThrowsException_WhenParameterTemplatesAreNull()
        {
            //arrange
            ITierEntityTemplateFactory tierEntityTemplateFactory = new TierEntityTemplateFactory(factoryLogger, validator);
            ICollection<TierParameterTemplate>? parameterTemplates = null;
            //actt & assert
            await Assert.ThrowsAsync<ValidationException>(async () => await tierEntityTemplateFactory.CreateAsync(parameterTemplates));
        }
    }
}
