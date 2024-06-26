﻿using StatTierMaker.API.Tiers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StatTierMaker.API.Calculator
{
    internal record IntervalValue
    {
        public double Minimum { get; set; }

        public double Maximum { get; set; }

        public TierValue Value { get; set; }
    }
}
