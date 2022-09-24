using System.Collections.Concurrent;
using Zer0.DomainDriven.Framework.Abstractions;
using Zer0.DomainDriven.Framework.Abstractions.Events;
using Zer0.Functional.Framework.Functors;
using Zer0.Functional.Framework.Types;

namespace Zer0.DomainDriven.Framework;

public abstract class QueuedDomainEventDispatcherBase : IDomainEventDispatcher
{
    protected readonly Queue<IDomainEvent> _domainEventQueue = new();

    public Result<Unit> ProcessAggregate(IAggregateRoot aggregateRoot)
    {
        IEnumerable<IDomainEvent> events = aggregateRoot.GetDomainEvents();

        foreach (IDomainEvent domainEvent in events)
        {
            _domainEventQueue.Enqueue(domainEvent);
        }

        return Unit.Value;
    }

    public abstract Task<Result<Unit>> DispatchQueuedEvents();
}
