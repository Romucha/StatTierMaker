using Microsoft.Extensions.Logging;
using StatTierMaker.API.TierFactories.Entities;
using StatTierMaker.API.Tiers;
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

        public async Task<TierList> CreateAsync(string? name, string? description, CancellationToken token = default)
        {
            try
            {
                logger.LogInformation($"Creating new instance of {nameof(TierList)} with name: {name}; description: {description}...");
                var result = new TierList()
                {
                    Name = name,
                    Description = description,
                    Tiers = new List<Tier>(),
                    Entities = new List<TierEntity>()
                };
                foreach (var t in Enum.GetValues<TierValue>())
                {
                    result.Tiers.Add(new Tier()
                    {
                        Name = t.ToString(),
                        Description = t.ToString(),
                        Value = t,
                        Entities = new List<TierEntity>()
                    });
                }
                return await validator.ValidateAsync(result, token);
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
