using Microsoft.Extensions.Logging;
using StatTierMaker.API.Tiers;
using StatTierMaker.API.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StatTierMaker.API.Calculator
{
    public class EntityWeightCalculator : IEntityWeightCalculator
    {
        private readonly ILogger<EntityWeightCalculator> logger;
        private readonly IValidator validator;

        public EntityWeightCalculator(ILogger<EntityWeightCalculator> logger, IValidator validator)
        {
            this.logger = logger;
            this.validator = validator;
        }

        public async Task<double> CalclulateWeightAsync(TierEntity entity, CancellationToken cancellationToken)
        {
            try
            {
                var validEntity = await validator.ValidateAsync(entity, cancellationToken);
                foreach (var item in validEntity.TierEntityParameters) 
                {
                    await validator.ValidateAsync(item, cancellationToken);
                }
                logger.LogInformation($"Calculating weight of entity {validEntity.Name}...");
                return validEntity.TierEntityParameters.Sum(c => (int)c.Value * c.Coefficient);
            }
            catch (Exception ex) 
            {
                logger.LogError(ex, nameof(CalclulateWeightAsync));
                throw;
            }
            finally
            {
                logger.LogInformation("Calculation done.");
            }
        }
    }
}
