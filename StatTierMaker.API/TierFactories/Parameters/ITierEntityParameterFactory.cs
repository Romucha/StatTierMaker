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
    public interface ITierEntityParameterFactory
    {
        /// <summary>
        /// Create tier entity parameter.
        /// </summary>
        /// <param name="name">Name of parameter.</param>
        /// <param name="description">Description of parameter.</param>
        /// <param name="value">Value of parameter.</param>
        /// <param name="coefficient">Coefficient of parameter.</param>
        /// <returns></returns>
        Task<TierEntityParameter> Create(string name, string description, TierValues value, double coefficient);
    }
}
