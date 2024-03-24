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
            var entity = new TierEntity()
            {
                Name = "Test name",
                Description = "Test description",
                TierEntityParameters = new List<TierParameter>()
                {
                    new TierParameter()
                    {
                        Name = "Parameter 1",
                        Description = "Description 1",
                        Coefficient = 0.1,
                        Value = TierValue.E,
                    },
                    new TierParameter()
                    {
                        Name = "Parameter 2",
                        Description = "Description 2",
                        Coefficient = 2,
                        Value = TierValue.S,
                    },
                    new TierParameter()
                    {
                        Name = "Parameter 3",
                        Description = "Description 3",
                        Coefficient = 1,
                        Value = TierValue.A,
                    }
                }
            };
            CancellationTokenSource source = new CancellationTokenSource();
            //act
            var weight = await entityWeightCalculator.CalclulateWeightAsync(entity, source.Token);
            //assert
            // nothing to assert yet
        }

        [Fact]
        public async Task CalclulateWeightAsync_ThrowsException_WhenParametersAreInvalid()
        {
            //arrange

            //act

            //assert
        }
    }
}
