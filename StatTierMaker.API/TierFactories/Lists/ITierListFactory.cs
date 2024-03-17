using StatTierMaker.API.Tiers;
using StatTierMaker.API.TierTemplates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StatTierMaker.API.TierFactories.Lists
{
    /// <summary>
    /// Factory for making of tier lists.
    /// </summary>
    public interface ITierListFactory
    {
        /// <summary>
        /// Creates tier list.
        /// </summary>
        /// <param name="tierListTemplate">Template of a tier list.</param>
        /// <returns></returns>
        Task<TierList> CreateAsync(TierListTemplate tierListTemplate);
    }
}
