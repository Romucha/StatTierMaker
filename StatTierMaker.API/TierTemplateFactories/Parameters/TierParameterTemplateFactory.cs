using Microsoft.Extensions.Logging;
using StatTierMaker.API.TierTemplates;
using StatTierMaker.API.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StatTierMaker.API.TierTemplateFactories.Parameters
{
    public class TierParameterTemplateFactory : ITierParameterTemplateFactory
    {
        private readonly ILogger<TierParameterTemplateFactory> logger;
        private readonly IValidator validator;

        public TierParameterTemplateFactory(ILogger<TierParameterTemplateFactory> logger, IValidator validator)
        {
            this.logger = logger;
            this.validator = validator;
        }

        public async Task<TierParameterTemplate> CreateAsync(string? name, string? description, double coefficient)
        {
            try
            {
                logger.LogInformation($"Creating {nameof(TierParameterTemplate)} with name: {name}; description: {description}; coefficient: {coefficient}");
                return await validator.ValidateAsync(new TierParameterTemplate()
                {
                    Name = name,
                    Description = description,
                    Coefficient = coefficient
                });
            }
            catch (Exception ex) 
            {
                logger.LogError(ex, this.GetType().Name);
                throw;
            }
            finally
            {
                logger.LogInformation("Creation done.");
            }
        }
    }
}
