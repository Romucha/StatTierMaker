using Microsoft.Extensions.Logging;
using StatTierMaker.API.Tiers;
using StatTierMaker.API.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StatTierMaker.API.TierFactories.Entities
{
    /// <summary>
    /// Default tier entity factory.
    /// </summary>
    public class TierEntityFactory : ITierEntityFactory
    {
        private readonly ILogger<TierEntityFactory> logger;
        private readonly IValidator validator;

        public TierEntityFactory(ILogger<TierEntityFactory> logger, IValidator validator)
        {
            this.logger = logger;
            this.validator = validator;
        }

        public async Task<TierEntity> CreateAsync(string? name, string? description)
        {
            try
            {
                logger.LogInformation($"Creating new instance of {nameof(TierEntity)} with name: {name}, description: {description}...");
                return await validator.ValidateAsync(new TierEntity()
                {
                    Name = name,
                    Description = description,
                    TierEntityParameters = new List<TierParameter>()
                });
            }
            catch (Exception ex)
            {
                logger.LogError(ex, nameof(TierEntityFactory));
                throw;
            }
            finally
            {
                logger.LogInformation("Creation done.");
            }
        }
    }
}
