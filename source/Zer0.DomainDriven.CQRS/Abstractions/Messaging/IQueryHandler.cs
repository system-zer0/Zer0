using MediatR;
using Zer0.Functional.Framework.Functors;

namespace Zer0.DomainDriven.CQRS.Abstractions.Messaging;

public interface IQueryHandler<in TQuery, TResult> : IRequestHandler<TQuery, Result<TResult>> where TQuery : ICommand<TResult>
{

}
