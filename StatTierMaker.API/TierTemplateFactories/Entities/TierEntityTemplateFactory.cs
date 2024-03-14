using Microsoft.Extensions.Logging;
using StatTierMaker.API.TierFactories.Parameters;
using StatTierMaker.API.TierTemplates;
using StatTierMaker.API.Validation;
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
        private readonly IValidator validator;

        public TierEntityTemplateFactory(ILogger<TierEntityTemplateFactory> logger, IValidator validator)
        {
            this.logger = logger;
            this.validator = validator;
        }

        public async Task<TierEntityTemplate> CreateAsync(ICollection<TierParameterTemplate> parameterTemplates)
        {
            try
            {
                logger.LogInformation($"Creating {nameof(TierEntityTemplate)}");
                var result = new TierEntityTemplate()
                {
                    TierParameterTemplates = parameterTemplates
                };
                await validator.Validate(result);

                return await Task.FromResult(result);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, nameof(CreateAsync));
                throw;
            }
            finally
            {
                logger.LogInformation("Creation done.");
            }
        }
    }
}
