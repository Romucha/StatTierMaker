using Microsoft.Extensions.Logging;
using StatTierMaker.API.Tiers;
using StatTierMaker.API.TierTemplates;
using StatTierMaker.API.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StatTierMaker.API.TierFactories.Parameters
{
    /// <summary>
    /// Default tier entity parameter factory. 
    /// </summary>
    public class TierParameterFactory : ITierParameterFactory
    {
        private readonly ILogger<TierParameterFactory> logger;
        private readonly IValidator validator;

        public TierParameterFactory(ILogger<TierParameterFactory> logger, IValidator validator) 
        {
            this.logger = logger;
            this.validator = validator;
        }
        public async Task<TierParameter> CreateAsync(TierParameterTemplate tierParameterTemplate, TierValue tierValue)
        {
            try
            {
                logger.LogInformation($"Creating new instance of {nameof(TierEntity)} from {nameof(TierParameterTemplate)} with name: {tierParameterTemplate.Name}; description: {tierParameterTemplate.Description}; coefficient: {tierParameterTemplate.Coefficient}...");
                return await validator.ValidateAsync(new TierParameter()
                {
                    Name = tierParameterTemplate.Name,
                    Description = tierParameterTemplate.Description,
                    Value = tierValue,
                    Coefficient = tierParameterTemplate.Coefficient
                });

            }
            catch (Exception ex) 
            {
                logger.LogError(ex, nameof(TierParameterFactory));
                throw;
            }
            finally
            {
                logger.LogInformation("Creation done.");
            }
        }
    }
}
