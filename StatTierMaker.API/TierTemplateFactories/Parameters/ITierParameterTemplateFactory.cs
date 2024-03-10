using StatTierMaker.API.TierTemplates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StatTierMaker.API.TierTemplateFactories.Parameters
{
    /// <summary>
    /// Provides methods for creating tier parameter templates.
    /// </summary>
    public interface ITierParameterTemplateFactory
    {
        /// <summary>
        /// Creates tier parameter templates.
        /// </summary>
        /// <param name="name">Name.</param>
        /// <param name="description">Description.</param>
        /// <param name="coefficient">Coefficient.</param>
        /// <returns></returns>
        Task<TierParameterTemplate> CreateAsync(string name, string description, double coefficient);
    }
}
