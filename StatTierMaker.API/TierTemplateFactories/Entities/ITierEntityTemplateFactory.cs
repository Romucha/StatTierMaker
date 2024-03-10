using StatTierMaker.API.Tiers;
using StatTierMaker.API.TierTemplates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StatTierMaker.API.TierTemplateFactories.Entities
{
    public interface ITierEntityTemplateFactory
    {
        Task<TierEntityTemplate> CreateAsync();
    }
}
