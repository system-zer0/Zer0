using Zer0.Functional.Framework.ResultExtensions;
using Zer0.Functional.Framework.Types;

namespace Zer0.Functional.Framework.Functors;

public readonly record struct Result<T>
{
    private static Error NullResultError => new Error("Error.NullResult", "Tried to convert null into result.");


    private readonly T? _value;
    public T Value => _value ?? throw new InvalidOperationException("Cannot access Value of an Error Result");
    public bool IsSuccess => _value is not null && Error == Error.None;
    public bool IsFailure => !IsSuccess;
    public Error Error { get; }

    private Result(T value)
    {
        Error = Error.None;
        _value = value;
    }

    private Result(Error error)
    {
        Error = error;
        _value = default;
    }

    /// <summary>
    /// Maps the value of this <see cref="Result{T}"/> into another <see cref="Result{T}"/> using the <paramref name="selector"/> function.
    /// If the input result is Ok, returns the Ok case with the value of the mapper call (which is <typeparamref name="TOut"/>).
    /// Otherwise returns Error case of the Result of <typeparamref name="TOut"/>.
    /// </summary>
    /// <typeparam name="T">Type of the value in the input result.</typeparam>
    /// <typeparam name="TOut">Type of the value in the returned result.</typeparam>
    /// <param name="selector">Function called with the input result value if it's Ok case.</param>
    public Result<TOut> Select<TOut>(Func<T, TOut> selector)
    {
        if (selector == null) throw new ArgumentNullException(nameof(selector));
        return IsSuccess ? selector(Value) : Error;
    }

    public T Return(Func<T> whenError)
    {
        return IsSuccess ? _value! : whenError();
    }

    public static implicit operator Result<T>(T? value) => value is null ? new Result<T>(NullResultError) : new Result<T>(value);
    public static implicit operator Result<T>(Error error) => new(error);
}
