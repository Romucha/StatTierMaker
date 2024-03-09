namespace StatTierMaker.API.Tiers;

/// <summary>
/// A tier list.
/// </summary>
public class TierList
{
    /// <summary>
    /// Id.
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// Name of tier list.
    /// </summary>
    public string? Name { get; set; }

    /// <summary>
    /// Desctiption of tier list.
    /// </summary>
    public string? Description { get; set; }

    /// <summary>
    /// Collection of tier entities.
    /// </summary>
    public ICollection<TierEntity>? TierEntities { get; set; }
}
