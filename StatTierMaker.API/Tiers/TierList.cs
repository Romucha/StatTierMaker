using StatTierMaker.API.Attributes;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StatTierMaker.API.Tiers;

/// <summary>
/// A tier list.
/// </summary>
public class TierList
{
    /// <summary>
    /// Id.
    /// </summary>
    [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    /// <summary>
    /// Name of tier list.
    /// </summary>
    [Required]
    public string? Name { get; set; }

    /// <summary>
    /// Desctiption of tier list.
    /// </summary>
    [Required(AllowEmptyStrings = true)]
    public string? Description { get; set; }

    /// <summary>
    /// Collection of tiers.
    /// </summary>
    [Required]
    [CollectionNotEmpty]
    public ICollection<Tier>? Tiers { get; set; }

    /// <summary>
    /// List of all entities that belong to tier list.
    /// </summary>
    [Required]
    public ICollection<TierEntity>? Entities { get; set; }
}
