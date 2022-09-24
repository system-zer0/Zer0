using Zer0.Functional.Framework.Types;

namespace Zer0.Functional.Framework.Functors;

public readonly record struct Effect<T>
{
    private readonly Action<T> _action;

    private Effect(Action<T> action)
    {
        _action = action;
    }

    public Unit Execute(T value)
    {
        _action(value);
        return Unit.Value;
    }

    public Result<Unit> TryExecute(T value, Func<Exception, Error> errorHandler)
    {
        try
        {
            _action(value);
            return Unit.Value;
        }
        catch (Exception e)
        {
            return errorHandler(e);
        }
    }

    public static Effect<T> Of(Action<T> action)
    {
        return new Effect<T>(action);
    }

    public static implicit operator Action<T>(Effect<T> effect) => effect._action;
    public static implicit operator Effect<T>(Action<T> action) => new(action);
}
