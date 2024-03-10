using Microsoft.Extensions.Logging;
using StatTierMaker.API.Tiers;
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

        public TierParameterFactory(ILogger<TierParameterFactory> logger) 
        {
            this.logger = logger;
        }
        public async Task<TierParameter> CreateAsync(string name, string description, TierValues value, double coefficient)
        {
            try
            {
                logger.LogInformation($"Creating new instance of {nameof(TierEntity)} with name: {name}, description: {description}, value: {value}, coefficient: {coefficient}...");
                return await Task.FromResult(new TierParameter()
                {
                    Name = name,
                    Description = description,
                    Value = value,
                    Coefficient = coefficient
                });

            }
            catch (Exception ex) 
            {
                logger.LogError(ex, nameof(TierParameterFactory));
                throw;
            }
            finally
            {
                logger.LogInformation("Creaton done.");
            }
        }
    }
}
