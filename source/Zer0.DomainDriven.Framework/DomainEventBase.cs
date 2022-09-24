using Zer0.DomainDriven.Framework.Abstractions.Events;

namespace Zer0.DomainDriven.Framework;

public abstract class DomainEventBase : IDomainEvent
{
    public DateTime OccuredAt { get; } = DateTime.Now;
}
