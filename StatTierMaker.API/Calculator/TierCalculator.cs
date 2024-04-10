using Microsoft.Extensions.Logging;
using StatTierMaker.API.Tiers;
using StatTierMaker.API.Validation;
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
        private readonly IEntityWeightCalculator entityWeightCalculator;
        private readonly IValidator validator;

        public TierCalculator(ILogger<TierCalculator> logger, IEntityWeightCalculator entityWeightCalculator, IValidator validator)
        {
            this.logger = logger;
            this.entityWeightCalculator = entityWeightCalculator;
            this.validator = validator;
        }

        public async Task<TierList> CalculateAsync(TierList tierList, CancellationToken cancellationToken)
        {
            /*
             * How to calculate tier list:
             * 1. Get list of entities in tier list.
             * 2. For each entity calculate its weigth: (sum of parameter values multiplied by parameter coefficients).
             * 3. Determine the values of tier list by taking max and min values, subtracting one from another and splitting the value into different intervals.
             * 4. Set tier for each entity according to those intervals.
             * */
            try
            {
                var validTierList = await validator.ValidateAsync(tierList, cancellationToken);
                logger.LogInformation($"Calculating tier list with name: {tierList.Name}...");
                var weightedEnities = new List<WeightedEnity>();

                foreach (var item in tierList.Entities) 
                {
                    weightedEnities.Add(new WeightedEnity()
                    {
                        TierEntity = item,
                        Weight = await entityWeightCalculator.CalclulateWeightAsync(item, cancellationToken)
                    });
                }
                weightedEnities = weightedEnities.OrderBy(c => c.Weight).ToList();

                var minEntity = weightedEnities.Min(c => c.Weight);
                var maxEntity = weightedEnities.Max(c => c.Weight);

                var tierValues = Enum.GetValues<TierValue>();
                var intervalValue = (maxEntity - minEntity) / tierValues.Length;
                var intervals = new List<IntervalValue>();
                
                for (int i = 0; i < tierValues.Length; ++i)
                {
                    intervals.Add(new IntervalValue()
                    {
                        Minimum = intervalValue * (int)tierValues[i],
                        Maximum = i < tierValues.Length - 1 ? intervalValue * (int)tierValues[i + 1] : double.MaxValue,
                        Value = tierValues[i],
                    });
                }

                //think about logic of tiers once more
                foreach (var item in weightedEnities) 
                {
                    foreach (var interval in intervals)
                    {
                        if (item.Weight >= interval.Minimum && item.Weight < interval.Maximum)
                        {
                            var tier = tierList.Tiers?.FirstOrDefault(c => c.Value == interval.Value);
                            if (tier != null)
                            {
                                item.TierEntity.Tier = tier;
                                tier.Entities?.Add(item.TierEntity);
                            }

                            break;
                        }
                    }
                }

                return tierList;
            }
            catch (Exception ex)
            {
                logger.LogError(ex, nameof(CalculateAsync));
                throw;
            }
            finally
            {
                logger.LogInformation("Calculation done.");
            }
        }
    }
}
