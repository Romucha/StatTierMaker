using StatTierMaker.API.Tiers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StatTierMaker.API.Tests.Calculator
{
    public record WeightedEnity
    {
        public TierEntity? TierEntity { get; set; }

        public double Weight { get; set; }
    }
}
