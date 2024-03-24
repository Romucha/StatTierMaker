using Microsoft.Extensions.Logging;
using StatTierMaker.API.Tiers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StatTierMaker.API.Calculator
{
    public class TierCalculator : ITierCalculator
    {
        private readonly ILogger<TierCalculator> logger;

        public TierCalculator(ILogger<TierCalculator> logger)
        {
            this.logger = logger;
        }

        public async Task CalculateAsync(TierList tierList, CancellationToken cancellationToken)
        {
            /*
             * How to calculate tier list:
             * 1. Get list of entities in tier list.
             * 2. For each entity calculate its weigth: (sum of parameter values multiplied by parameter coefficients).
             * 3. Determine the values of tier list by taking max and min values, subtracting one from another and splitting the value into different intervals.
             * 4. Set tier for each entity according to those intervals.
             * */

            throw new NotImplementedException();
        }
    }
}
