using Zer0.Functional.Framework.Types;

namespace Zer0.Functional.Framework.Functors;

public readonly record struct AsyncEffect<T>
{
    private readonly Func<T, Task<Unit>> _action;

    private AsyncEffect(Func<T, Task<Unit>> action)
    {
        _action = action;
    }

    public Task<Unit> Execute(T value)
    {
        return _action(value);
    }

    public async Task<Result<Unit>> TryExecute(T value, Func<Exception, Error> errorHandler)
    {
        try
        {
            return await _action(value);
        }
        catch (Exception e)
        {
            return errorHandler(e);
        }
    }

    public static AsyncEffect<T> Of(Func<T, Task<Unit>> action)
    {
        return new AsyncEffect<T>(action);
    }

    public static AsyncEffect<T> Of(Func<T, Task> action)
    {
        return Of(async e =>
        {
            await action(e);
            return Unit.Value;
        });
    }

    public static implicit operator Func<T, Task<Unit>>(AsyncEffect<T> effect) => effect._action;
    public static implicit operator AsyncEffect<T>(Func<T, Task<Unit>> action) => new(action);
}
