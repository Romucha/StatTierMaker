using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;
using StatTierMaker.API.Validation;
using System;
using System.Collections.Generic;
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
                DummyNumber = -1,
                DummyNumberMinimumExluded = 1,
                RequiredDummyString = "test",
                OptionalDummyString = "test",
            };
            //act
            await validator.Validate(model);
            //assert
        }
    }
}
