using MediatR;
using Zer0.Functional.Framework.Functors;

namespace Zer0.DomainDriven.CQRS.Abstractions.Messaging;

public interface ICommand : IRequest<Result<Unit>>
{

}

public interface ICommand<T> : IRequest<Result<T>>
{

}
