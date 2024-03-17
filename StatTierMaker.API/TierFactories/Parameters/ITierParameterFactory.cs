using StatTierMaker.API.Tiers;
using StatTierMaker.API.TierTemplates;
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
        /// <param name="tierParameterTemplate">Template of a tier parameter.</param>
        /// <param name="tierValue">Tier value.</param>
        /// <returns></returns>
        Task<TierParameter> CreateAsync(TierParameterTemplate tierParameterTemplate, TierValue tierValue);
    }
}
