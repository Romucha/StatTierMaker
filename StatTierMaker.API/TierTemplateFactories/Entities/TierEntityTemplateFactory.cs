using Microsoft.Extensions.Logging;
using StatTierMaker.API.TierFactories.Parameters;
using StatTierMaker.API.TierTemplates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StatTierMaker.API.TierTemplateFactories.Entities
{
    /// <summary>
    /// Provides methods for creating tier list templates.
    /// </summary>
    public class TierEntityTemplateFactory : ITierEntityTemplateFactory
    {
        private readonly ILogger<TierEntityTemplateFactory> logger;

        private readonly ITierParameterFactory parameterFactory;

        public TierEntityTemplateFactory(ILogger<TierEntityTemplateFactory> logger, ITierParameterFactory tierParameterFactory)
        {
            this.logger = logger;
            this.parameterFactory = tierParameterFactory;
        }

        public async Task<TierEntityTemplate> CreateAsync()
        {
            try
            {
                logger.LogInformation($"Creating {nameof(TierEntityTemplate)}");
                return await Task.FromResult(new TierEntityTemplate()
                {
                    TierParameterTemplates = new List<TierParameterTemplate>()
                });
            }
            catch (Exception ex)
            {
                logger.LogError(ex, nameof(TierEntityTemplateFactory));
                throw;
            }
            finally
            {
                logger.LogInformation("Creation done.");
            }
        }
    }
}
