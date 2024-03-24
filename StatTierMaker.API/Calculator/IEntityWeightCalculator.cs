using StatTierMaker.API.Tiers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StatTierMaker.API.Calculator
{
    public interface IEntityWeightCalculator
    {
        Task<double> CalclulateWeightAsync(TierEntity entity,CancellationToken cancellationToken);
    }
}
