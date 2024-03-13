using Microsoft.Extensions.Logging;
using StatTierMaker.API.TierTemplates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StatTierMaker.API.TierTemplateFactories.Lists
{
    public class TierListTemplateFactory : ITierListTemplateFactory
    {
        private readonly ILogger<TierListTemplateFactory> logger;

        public TierListTemplateFactory(ILogger<TierListTemplateFactory> logger)
        {
            this.logger = logger;
        }

        public async Task<TierListTemplate> CreateAsync(string name, string description, TierEntityTemplate tierEntityTemplate)
        {
            try
            {
                logger.LogInformation($"Creating {nameof(TierListTemplate)} with name: {name}; description: {description}");
                return await Task.FromResult(new TierListTemplate()
                {
                    Name = name,
                    Description = description,
                    TierEntityTemplate = tierEntityTemplate
                });
            }
            catch (Exception ex) 
            {
                logger.LogError(ex, nameof(TierListTemplateFactory));
                throw;
            }
            finally
            {
                logger.LogInformation("Creation done.");
            }
        }
    }
}
