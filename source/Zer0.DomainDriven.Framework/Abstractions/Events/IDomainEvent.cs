namespace Zer0.DomainDriven.Framework.Abstractions.Events;

public interface IDomainEvent
{
    public DateTime OccuredAt { get; }
}
