using Zer0.DomainDriven.Framework.Abstractions;

namespace Zer0.DomainDriven.Framework;

public abstract class Entity<TIdentity> where TIdentity : IIdentity
{
    public TIdentity Id { get; }

    public Entity(TIdentity id)
    {
        Id = id;
    }
}
