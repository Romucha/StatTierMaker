using Microsoft.Extensions.Logging.Abstractions;
using Microsoft.Extensions.Logging;
using StatTierMaker.API.Calculator;
using StatTierMaker.API.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StatTierMaker.API.Tiers;
using StatTierMaker.API.Tests.TestData.Entities;
using StatTierMaker.API.Tests.TestData.Tiers;

namespace StatTierMaker.API.Tests.Calculator
{
    public class TierCalculatorTests
    {
        private readonly ILogger<TierCalculator> calculatorLogger;
        private readonly ILogger<EntityWeightCalculator> entityCalculatorLogger;
        private readonly IValidator validator;

        public TierCalculatorTests()
        {
            calculatorLogger = new NullLoggerFactory().CreateLogger<TierCalculator>();
            entityCalculatorLogger = new NullLoggerFactory().CreateLogger<EntityWeightCalculator>();
            validator = new TierValidator(new NullLogger<TierValidator>());
        }

        [Fact]
        public async Task CalculateAsync_Normal()
        {
            //arrange
            IEntityWeightCalculator entityWeightCalculator = new EntityWeightCalculator(entityCalculatorLogger, validator);
            ITierCalculator tierCalculator = new TierCalculator(calculatorLogger, entityWeightCalculator);
            var tierEntities = EntityCollections.Normal();

            TierList tierList = new TierList()
            {
                Name = "Test name",
                Description = "Test description",
                Tiers = TierCollections.Normal().ToList(),
                Entities = tierEntities.ToList()
            };
            CancellationTokenSource cancellationTokenSource = new CancellationTokenSource();
            //act
            var result = await tierCalculator.CalculateAsync(tierList, cancellationTokenSource.Token);
            //assert
            Assert.NotNull(result);
            Assert.NotNull(result.Tiers);
            Assert.NotNull(result.Entities);
            foreach (var entity in tierList.Entities)
            {
                Assert.NotNull(entity);
                Assert.NotNull(entity.Tier);
            }
            foreach (var tier in result.Tiers) 
            {
                Assert.NotNull(tier);
                Assert.NotNull(tier.Entities);
            }
        }
    }
}
