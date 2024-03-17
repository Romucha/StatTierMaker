using Microsoft.Extensions.Logging;
using StatTierMaker.API.TierFactories.Lists;
using StatTierMaker.API.TierTemplates;
using StatTierMaker.API.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            TierListTemplate tierListTemplate = new TierListTemplate()
            {
                Name = "Test name",
                Description = " Test description",
            };
            //act
            var result = await tierListFactory.CreateAsync(tierListTemplate);
            //assert
            Assert.NotNull(result);
            Assert.Equal(tierListTemplate.Name, result.Name);
            Assert.Equal(tierListTemplate.Description, result.Description);
        }
    }
}
