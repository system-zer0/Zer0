using MediatR;
using Zer0.Functional.Framework.Functors;

namespace Zer0.DomainDriven.CQRS.Abstractions.Messaging;

public interface IQuery<T> : IRequest<Result<T>>
{

}
