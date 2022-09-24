using Zer0.DomainDriven.Framework.Abstractions;
using Zer0.DomainDriven.Framework.Abstractions.Events;

namespace Zer0.DomainDriven.Framework;

public abstract class AggregateRoot<TIdentity> : IAggregateRoot<TIdentity> where TIdentity : IIdentity
{
    private readonly List<IDomainEvent> _domainEvents = new List<IDomainEvent>();

    private readonly TIdentity _identity;

    protected AggregateRoot(TIdentity id)
    {
        _identity = id;
    }

    public TIdentity GetIdentity()
    {
        return _identity;
    }

    /// <summary>
    /// Returns the Domain Events within the aggregate, ordered by their time of occurence.
    /// </summary>
    public IEnumerable<IDomainEvent> GetDomainEvents()
    {
        return _domainEvents.OrderBy(x => x.OccuredAt);
    }

    void IAggregateRoot.ClearDomainEvents() => ClearDomainEvents();
    private void ClearDomainEvents()
    {
        _domainEvents.Clear();
    }

    protected void RaiseDomainEvent(IDomainEvent domainEvent)
    {
        _domainEvents.Add(domainEvent);
    }

    protected void RaiseDomainEvents(params IDomainEvent[] domainEvents)
    {
        _domainEvents.AddRange(domainEvents);
    }
}
