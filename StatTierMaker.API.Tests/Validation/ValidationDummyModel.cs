using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StatTierMaker.API.Tests.Validation
{
    /// <summary>
    /// Dummy model for validation tests.
    /// </summary>
    public class ValidationDummyModel
    {
        /// <summary>
        /// Dummy number with range attribute.
        /// </summary>
        [Range(0,10)]
        public int DummyNumber { get; set; }

        /// <summary>
        /// Dummy string with range attribute and excluded minimum.
        /// </summary>
        [Range(0,10, MinimumIsExclusive = true)]
        public int DummyNumberMinimumExluded { get; set; }

        /// <summary>
        /// Dummy string with required attribute.
        /// </summary>
        [Required]
        public string? RequiredDummyString { get; set; }

        /// <summary>
        /// Dummy string withou attributes.
        /// </summary>
        public string? OptionalDummyString { get; set; }
    }
}
