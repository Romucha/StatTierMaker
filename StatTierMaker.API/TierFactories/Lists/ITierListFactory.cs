using StatTierMaker.API.Tiers;
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
        /// <param name="name">Name of tier list.</param>
        /// <param name="description">Description of tier list.</param>
        /// <returns></returns>
        Task<TierList> CreateAsync(string? name, string? description, CancellationToken token = default);
    }
}
