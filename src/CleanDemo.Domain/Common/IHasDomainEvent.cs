namespace WrightCodes.CleanDemo.Domain.Common;

/// <summary>
/// Interface defines when an entity is expected to have domain events.
/// </summary>
public interface IHasDomainEvent
{
    /// <summary>
    /// Gets a collection of domain events relating to a given entity.
    /// </summary>
    public List<DomainEvent> DomainEvents { get; }
}