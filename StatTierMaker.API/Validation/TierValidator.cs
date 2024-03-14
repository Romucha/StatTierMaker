using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StatTierMaker.API.Validation
{
    public class TierValidator : IValidator
    {
        private readonly ILogger<TierValidator> logger;

        public TierValidator(ILogger<TierValidator> logger)
        {
            this.logger = logger;
        }

        public async Task Validate<T>(T? value)
        {
            try
            {
                logger.LogInformation($"Validating {typeof(T)}...");
                ValidationContext validationContext = new ValidationContext(value);
                ICollection<ValidationResult> validationResults = new List<ValidationResult>();
                if (Validator.TryValidateObject(value, validationContext, validationResults, true))
                {
                    await Task.CompletedTask;
                }
                else
                {
                    throw new ArgumentException(string.Join("\n", validationResults));
                }
            }
            catch (Exception ex) 
            {
                logger.LogError(ex, nameof(Validate));
            }
            finally
            {
                logger.LogInformation("Validation done.");
            }
        }
    }
}
