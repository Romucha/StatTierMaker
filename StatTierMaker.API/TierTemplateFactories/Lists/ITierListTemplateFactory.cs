using StatTierMaker.API.TierTemplates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StatTierMaker.API.TierTemplateFactories.Lists
{
    /// <summary>
    /// Provides methods for creating tier list templates.
    /// </summary>
    public interface ITierListTemplateFactory
    {
        /// <summary>
        /// Creates tier list template.
        /// </summary>
        /// <param name="name">Name.</param>
        /// <param name="description">Description.</param>
        /// <returns></returns>
        Task<TierListTemplate> CreateAsync(string? name, string? description);
    }
}
