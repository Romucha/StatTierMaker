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
                Tiers = new List<Tier>()
            };
            CancellationTokenSource cancellationTokenSource = new CancellationTokenSource();
            //act
            await tierCalculator.CalculateAsync(tierList, tierEntities, cancellationTokenSource.Token);
            //assert
        }
    }
}
