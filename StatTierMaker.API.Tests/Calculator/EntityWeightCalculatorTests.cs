using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;
using StatTierMaker.API.Calculator;
using StatTierMaker.API.Tiers;
using StatTierMaker.API.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using StatTierMaker.Tests.Common.TestData.Entities;

namespace StatTierMaker.API.Tests.Calculator
{
    public class EntityWeightCalculatorTests
    {
        private readonly ILogger<EntityWeightCalculator> calculatorLogger;
        private readonly IValidator validator;

        public EntityWeightCalculatorTests() 
        {
            calculatorLogger = new NullLoggerFactory().CreateLogger<EntityWeightCalculator>();
            validator = new TierValidator(new NullLogger<TierValidator>());
        }

        [Fact]
        public async Task CalclulateWeightAsync_Normal()
        {
            //arrange
            IEntityWeightCalculator entityWeightCalculator = new EntityWeightCalculator(calculatorLogger, validator);
            var entity = SingularEntities.Normal();
            CancellationTokenSource source = new CancellationTokenSource();
            //act
            var weight = await entityWeightCalculator.CalclulateWeightAsync(entity, source.Token);
            //assert
            Assert.Equal(12, weight);
        }

        [Fact]
        public async Task CalclulateWeightAsync_ThrowsException_WhenParametersAreInvalid()
        {
            //arrange
            IEntityWeightCalculator entityWeightCalculator = new EntityWeightCalculator(calculatorLogger, validator);
            var entity = SingularEntities.Invalid();
            CancellationTokenSource source = new CancellationTokenSource();
            //act & assert
            await Assert.ThrowsAsync<ValidationException>(async () => await entityWeightCalculator.CalclulateWeightAsync(entity, source.Token));
        }

        [Fact]
        public async Task CalclulateWeightAsync_ThrowsException_WhenEntityIsDefault()
        {
            //arrange
            IEntityWeightCalculator entityWeightCalculator = new EntityWeightCalculator(calculatorLogger, validator);
            var entity = SingularEntities.Default();
            CancellationTokenSource source = new CancellationTokenSource();
            //act & assert
            await Assert.ThrowsAsync<ValidationException>(async () => await entityWeightCalculator.CalclulateWeightAsync(entity, source.Token));
        }


        [Fact]
        public async Task CalclulateWeightAsync_ThrowsException_WhenEntityIsNull()
        {
            //arrange
            IEntityWeightCalculator entityWeightCalculator = new EntityWeightCalculator(calculatorLogger, validator);
            var entity = SingularEntities.Null();
            CancellationTokenSource source = new CancellationTokenSource();
            //act & assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () => await entityWeightCalculator.CalclulateWeightAsync(entity, source.Token));
        }
    }
}
