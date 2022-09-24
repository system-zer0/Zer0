using Zer0.DomainDriven.Framework.Abstractions;

namespace Zer0.DomainDriven.Framework;

public abstract record Identity<T>(T Value): IIdentity;
