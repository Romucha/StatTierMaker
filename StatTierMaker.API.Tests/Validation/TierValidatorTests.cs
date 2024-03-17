using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;
using StatTierMaker.API.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StatTierMaker.API.Tests.Validation
{
    public class TierValidatorTests
    {
        private readonly ILogger<TierValidator> validatorLogger;

        public TierValidatorTests()
        {
            validatorLogger = new NullLoggerFactory().CreateLogger<TierValidator>();
        }

        [Fact]
        public async Task Validate_Normal_WhenNormalModel()
        {
            //arrange
            IValidator validator = new TierValidator(validatorLogger);
            ValidationDummyModel model = new ValidationDummyModel()
            {
                DummyNumber = 1,
                DummyNumberMinimumExluded = 1,
                RequiredDummyString = "test",
                OptionalDummyString = "test",
            };
            //act
            await validator.ValidateAsync(model);
            //assert
            //nothing to assert
        }

        [Fact]
        public async Task Validate_Normal_WhenOptionalParametersAreNull()
        {
            //arrange
            IValidator validator = new TierValidator(validatorLogger);
            ValidationDummyModel model = new ValidationDummyModel()
            {
                DummyNumber = 1,
                DummyNumberMinimumExluded = 1,
                RequiredDummyString = "test",
                OptionalDummyString = null,
            };
            //act
            var result = await validator.ValidateAsync(model);
            //assert
            Assert.NotNull(result);
            Assert.Equal(model, result);
        }

        [Theory]
        [InlineData(-1, 1, "test")]
        [InlineData(0, 0, "test")]
        [InlineData(1,1, null)]
        public async Task Validate_ThrowsException_WhenInvalidParameters(int number, int numberMinimumExcluded, string? requiredString)
        {
            //arrange
            IValidator validator = new TierValidator(validatorLogger);
            ValidationDummyModel model = new ValidationDummyModel()
            {
                DummyNumber = number,
                DummyNumberMinimumExluded = numberMinimumExcluded,
                RequiredDummyString = requiredString,
            };
            //act & assert
            await Assert.ThrowsAsync<ValidationException>(async () => await validator.ValidateAsync(model));
        }
    }
}
