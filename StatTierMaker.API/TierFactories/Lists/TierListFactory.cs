using Microsoft.Extensions.Logging;
using StatTierMaker.API.Tiers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StatTierMaker.API.TierFactories.Lists
{
    /// <summary>
    /// Default tier list factory.
    /// </summary>
    public class TierListFactory : ITierListFactory
    {
        private readonly ILogger<TierListFactory> logger;

        public TierListFactory(ILogger<TierListFactory> logger)
        {
            this.logger = logger;
        }

        public async Task<TierList> CreateAsync(string name, string description)
        {
            try
            {
                logger.LogInformation($"Creating new instance of {nameof(TierList)} with name: {name}, description: {description}...");
                return await Task.FromResult(new TierList()
                {
                    Name = name,
                    Description = description,
                    TierEntities = new List<TierEntity>()
                });
            }
            catch (Exception ex) 
            {
                logger.LogError(ex, nameof(TierList));
                throw;
            }
            finally
            {
                logger.LogInformation("Creation done.");
            }
        }
    }
}
