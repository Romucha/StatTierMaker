using System.ComponentModel.DataAnnotations;

namespace StatTierMaker.API.Tiers;

/// <summary>
/// A tier list.
/// </summary>
public class TierList
{
    /// <summary>
    /// Id.
    /// </summary>
    [Key]
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
    /// Collection of tier entities.
    /// </summary>
    public ICollection<TierEntity>? TierEntities { get; set; }
}
