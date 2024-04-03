using Microsoft.Extensions.Logging;
using StatTierMaker.API.Tiers;
using StatTierMaker.API.TierTemplates;
using StatTierMaker.API.Validation;
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
        private readonly IValidator validator;

        public TierListFactory(ILogger<TierListFactory> logger, IValidator validator)
        {
            this.logger = logger;
            this.validator = validator;
        }

        public async Task<TierList> CreateAsync(TierListTemplate tierListTemplate)
        {
            try
            {
                logger.LogInformation($"Creating new instance of {nameof(TierList)} from {nameof(TierListTemplate)} with name: {tierListTemplate.Name}; description: {tierListTemplate.Description}...");
                var result = new TierList()
                {
                    Name = tierListTemplate.Name,
                    Description = tierListTemplate.Description,
                    Tiers = new List<TierEntity>()
                };
                return await validator.ValidateAsync(result);
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
