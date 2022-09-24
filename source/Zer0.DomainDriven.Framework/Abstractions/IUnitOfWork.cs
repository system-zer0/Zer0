using Zer0.Functional.Framework.Functors;
using Zer0.Functional.Framework.Types;

namespace Zer0.DomainDriven.Framework.Abstractions;

public interface IUnitOfWork
{
    public Task<Result<Unit>> Commit(CancellationToken ct = default);
}
