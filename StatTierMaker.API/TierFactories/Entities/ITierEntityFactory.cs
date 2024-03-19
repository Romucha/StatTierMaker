using StatTierMaker.API.Tiers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StatTierMaker.API.TierFactories.Entities
{
    /// <summary>
    /// Factory for making tier entites.
    /// </summary>
    public interface ITierEntityFactory
    {
        /// <summary>
        /// Creates tier entity.
        /// </summary>
        /// <param name="name">Name of a new entity.</param>
        /// <param name="description">Description of a new entity.</param>
        /// <returns></returns>
        Task<TierEntity> CreateAsync(string? name, string? description);
    }
}
