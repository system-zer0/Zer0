using Zer0.DomainDriven.Framework.Abstractions.Events;

namespace Zer0.DomainDriven.Framework.Abstractions;

public interface IAggregateRoot
{
    public IEnumerable<IDomainEvent> GetDomainEvents();
    internal void ClearDomainEvents();
}

public interface IAggregateRoot<out TIdentity> : IAggregateRoot
{
    public TIdentity GetIdentity();
}
