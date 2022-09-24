using MediatR;
using Zer0.Functional.Framework.Functors;

namespace Zer0.DomainDriven.CQRS.Abstractions.Messaging;

public interface ICommandHandler<in TCommand, TResult> : IRequestHandler<TCommand, Result<TResult>> where TCommand : ICommand<TResult>
{

}

public interface ICommandHandler<in TCommand> : IRequestHandler<TCommand, Result<Unit>> where TCommand : ICommand
{
}
