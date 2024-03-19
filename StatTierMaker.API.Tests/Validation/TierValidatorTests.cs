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

        [Theory]
        [InlineData(1, 1, "test1", "test2")]
        [InlineData(1, 1, "test1", null)]
        public async Task Validate_Normal_WhenNormalModel(int dummyNumber, int dummyNumberMinimumExcluded, string? requiredDummyString, string? optionalDummyString)
        {
            //arrange
            IValidator validator = new TierValidator(validatorLogger);
            ValidationDummyModel model = new ValidationDummyModel()
            {
                DummyNumber = dummyNumber,
                DummyNumberMinimumExluded = dummyNumberMinimumExcluded,
                RequiredDummyString = requiredDummyString,
                OptionalDummyString = optionalDummyString,
            };
            //act
            var result = await validator.ValidateAsync(model);
            //assert
            Assert.NotNull(result);
            Assert.Equal(model, result);
            Assert.Equal(dummyNumber, result.DummyNumber);
            Assert.Equal(dummyNumberMinimumExcluded, result.DummyNumberMinimumExluded);
            Assert.Equal(requiredDummyString, result.RequiredDummyString);
            Assert.Equal(optionalDummyString, result.OptionalDummyString);
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
