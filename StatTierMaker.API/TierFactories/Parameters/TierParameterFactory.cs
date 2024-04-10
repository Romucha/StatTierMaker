using Microsoft.Extensions.Logging;
using StatTierMaker.API.Tiers;
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
        public async Task<TierParameter> CreateAsync(string? name, string? descripton, double coefficient, CancellationToken token)
        {
            try
            {
                logger.LogInformation($"Creating new instance of {nameof(TierParameter)} with name: {name}; description: {descripton}; coefficient: {coefficient}...");
                return await validator.ValidateAsync(new TierParameter()
                {
                    Name = name,
                    Description = descripton,
                    Coefficient = coefficient
                }, token);

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
