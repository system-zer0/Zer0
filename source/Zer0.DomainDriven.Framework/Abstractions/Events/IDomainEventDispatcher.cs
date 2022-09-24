using Zer0.Functional.Framework.Functors;
using Zer0.Functional.Framework.Types;

namespace Zer0.DomainDriven.Framework.Abstractions.Events;

public interface IDomainEventDispatcher
{
    Result<Unit> ProcessAggregate(IAggregateRoot aggregateRoot);
    Task<Result<Unit>> DispatchQueuedEvents();
}
