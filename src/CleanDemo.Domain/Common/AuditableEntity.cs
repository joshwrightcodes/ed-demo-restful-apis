namespace WrightCodes.CleanDemo.Domain.Common;

/// <summary>
/// Base class that defines common auditable properties for an entity.
/// </summary>
public abstract record AuditableEntity
{
    /// <summary>
    /// Gets or sets when the entity was created.
    /// </summary>
    public DateTimeOffset CreatedOn { get; set; }

    /// <summary>
    /// Gets or sets the user id of the user who created the entity.
    /// </summary>
    public string CreatedBy { get; set; }

    /// <summary>
    /// Gets or sets when the entity was last modified.
    /// </summary>
    public DateTimeOffset ModifiedOn { get; set; }

    /// <summary>
    /// Gets or sets the user id of the user who last modified the entity.
    /// </summary>
    public string ModifiedBy { get; set; }
}