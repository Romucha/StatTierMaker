using StatTierMaker.API.Tiers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StatTierMaker.API.TierFactories.Parameters
{
    /// <summary>
    /// Factory for making tier entity parameters.
    /// </summary>
    public interface ITierParameterFactory
    {
        /// <summary>
        /// Create tier entity parameter.
        /// </summary>
        /// <param name="name">Name of parameter.</param>
        /// <param name="description">Description of parameter.</param>
        /// <param name="coefficient">Coefficient of parameter.</param>
        /// <returns></returns>
        Task<TierParameter> CreateAsync(string? name, string? description, double coefficient);
    }
}
