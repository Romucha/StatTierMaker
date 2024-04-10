using Microsoft.Extensions.Logging;
using StatTierMaker.API.TierFactories.Parameters;
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
        private readonly ITierParameterFactory parameterFactory;

        public TierEntityFactory(ILogger<TierEntityFactory> logger, IValidator validator, ITierParameterFactory parameterFactory)
        {
            this.logger = logger;
            this.validator = validator;
            this.parameterFactory = parameterFactory;
        }

        public async Task<TierEntity> CreateAsync(string? name, string? description, IEnumerable<TierParameter> tierParameters, CancellationToken token = default)
        {
            try
            {
                logger.LogInformation($"Creating new instance of {nameof(TierEntity)} with name: {name}, description: {description}...");
                if (tierParameters is null)
                {
                    throw new ArgumentNullException(nameof(tierParameters));
                }
                return await validator.ValidateAsync(new TierEntity()
                {
                    Name = name,
                    Description = description,
                    TierEntityParameters = new List<TierParameter>(tierParameters)
                }, token);
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
