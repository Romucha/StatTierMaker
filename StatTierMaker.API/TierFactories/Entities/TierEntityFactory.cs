using Microsoft.Extensions.Logging;
using StatTierMaker.API.Tiers;
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

        public TierEntityFactory(ILogger<TierEntityFactory> logger)
        {
            this.logger = logger;
        }

        public async Task<TierEntity> CreateAsync(string name, string description)
        {
            try
            {
                logger.LogInformation($"Creating new instance of {nameof(TierEntity)} with name: {name}, description: {description}...");
                return await Task.FromResult(new TierEntity()
                {
                    Name = name,
                    Description = description,
                    TierEntityParameters = new List<TierEntityParameter>()
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
