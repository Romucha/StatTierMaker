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
using System.ComponentModel.DataAnnotations;

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
            ITierCalculator tierCalculator = new TierCalculator(calculatorLogger, entityWeightCalculator, validator);

            TierList tierList = new TierList()
            {
                Name = "Test name",
                Description = "Test description",
                Tiers = TierCollections.Normal().ToList(),
                Entities = EntityCollections.Normal().ToList()
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

        [Fact]
        public async Task CalculateAsync_Invalid()
        {
            //arrange
            IEntityWeightCalculator entityWeightCalculator = new EntityWeightCalculator(entityCalculatorLogger, validator);
            ITierCalculator tierCalculator = new TierCalculator(calculatorLogger, entityWeightCalculator, validator);

            TierList tierList = new TierList()
            {
                Name = "Test name",
                Description = "Test description",
                Tiers = TierCollections.WithInvalidElements().ToList(),
                Entities = EntityCollections.WithInvalidElements().ToList()
            };
            CancellationTokenSource cancellationTokenSource = new CancellationTokenSource();

            //act & assert
            await Assert.ThrowsAsync<ValidationException>(async() => await tierCalculator.CalculateAsync(tierList, cancellationTokenSource.Token));
        }

        [Fact]
        public async Task CalculateAsync_EmptyEntityCollection()
        {
            //arrange
            IEntityWeightCalculator entityWeightCalculator = new EntityWeightCalculator(entityCalculatorLogger, validator);
            ITierCalculator tierCalculator = new TierCalculator(calculatorLogger, entityWeightCalculator, validator);

            TierList tierList = new TierList()
            {
                Name = "Test name",
                Description = "Test description",
                Tiers = TierCollections.WithInvalidElements().ToList(),
                Entities = EntityCollections.Empty().ToList()
            };
            CancellationTokenSource cancellationTokenSource = new CancellationTokenSource();

            //act & assert
            await Assert.ThrowsAsync<InvalidOperationException>(async () => await tierCalculator.CalculateAsync(tierList, cancellationTokenSource.Token));
        }

        [Fact]
        public async Task CalculateAsync_EmptyTierCollection()
        {
            //arrange
            IEntityWeightCalculator entityWeightCalculator = new EntityWeightCalculator(entityCalculatorLogger, validator);
            ITierCalculator tierCalculator = new TierCalculator(calculatorLogger, entityWeightCalculator, validator);

            TierList tierList = new TierList()
            {
                Name = "Test name",
                Description = "Test description",
                Tiers = TierCollections.Empty().ToList(),
                Entities = EntityCollections.Normal().ToList()
            };
            CancellationTokenSource cancellationTokenSource = new CancellationTokenSource();

            //act & assert
            await Assert.ThrowsAsync<ValidationException>(async () => await tierCalculator.CalculateAsync(tierList, cancellationTokenSource.Token));
        }

        [Fact]
        public async Task CalculateAsync_NullEntityCollection()
        {
            //arrange
            IEntityWeightCalculator entityWeightCalculator = new EntityWeightCalculator(entityCalculatorLogger, validator);
            ITierCalculator tierCalculator = new TierCalculator(calculatorLogger, entityWeightCalculator, validator);

            TierList tierList = new TierList()
            {
                Name = "Test name",
                Description = "Test description",
                Tiers = TierCollections.Normal().ToList(),
                Entities = (List<TierEntity>)EntityCollections.Null()
            };
            CancellationTokenSource cancellationTokenSource = new CancellationTokenSource();

            //act & assert
            await Assert.ThrowsAsync<ValidationException>(async () => await tierCalculator.CalculateAsync(tierList, cancellationTokenSource.Token));
        }

        [Fact]
        public async Task CalculateAsync_NullTierCollection()
        {
            //arrange
            IEntityWeightCalculator entityWeightCalculator = new EntityWeightCalculator(entityCalculatorLogger, validator);
            ITierCalculator tierCalculator = new TierCalculator(calculatorLogger, entityWeightCalculator, validator);

            TierList tierList = new TierList()
            {
                Name = "Test name",
                Description = "Test description",
                Tiers = (List<Tier>)TierCollections.Null(),
                Entities = EntityCollections.Normal().ToList()
            };
            CancellationTokenSource cancellationTokenSource = new CancellationTokenSource();

            //act & assert
            await Assert.ThrowsAsync<ValidationException>(async () => await tierCalculator.CalculateAsync(tierList, cancellationTokenSource.Token));
        }

        [Fact]
        public async Task CalculateAsync_NullTierList()
        {
            //arrange
            IEntityWeightCalculator entityWeightCalculator = new EntityWeightCalculator(entityCalculatorLogger, validator);
            ITierCalculator tierCalculator = new TierCalculator(calculatorLogger, entityWeightCalculator, validator);

            TierList tierList = null;
            CancellationTokenSource cancellationTokenSource = new CancellationTokenSource();

            //act & assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () => await tierCalculator.CalculateAsync(tierList, cancellationTokenSource.Token));
        }
    }
}
