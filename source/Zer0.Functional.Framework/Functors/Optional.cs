using Zer0.Functional.Framework.OptionalExtensions;

namespace Zer0.Functional.Framework.Functors;

public readonly record struct Optional<T>
{
    private readonly T? _value;
    public T Value => _value ?? throw new InvalidOperationException($"Cannot access the Value of {nameof(Optional<T>)} in its None state");
    public bool IsSome => _value != null;
    public bool IsNone => !IsSome;

    internal Optional(T? value)
    {
        _value = value;
    }

    /// <summary>
    /// Maps the value of the <see cref="Optional{T}"/> into another <see cref="Optional{TResult}"/> using the <paramref name="selector"/> function.
    /// If the input <see cref="Optional{T}"/> is Some, returns a <see cref="Optional.Some{TResult}(TResult)"/> instance with the return value of the selector call.
    /// Otherwise returns <see cref="Optional.None{TResult}()"/>.
    /// </summary>
    /// <typeparam name="T">Type of the value in the input <see cref="Optional{T}"/>.</typeparam>
    /// <typeparam name="TResult">Type of the value in the returned <see cref="Optional{TResult}"/>.</typeparam>
    /// <param name="selector">Function called with the input <see cref="Optional{T}"/> value if it's Some case.</param>
    public Optional<TResult> Select<TResult>(Func<T, TResult> selector)
    {
        if (selector == null) throw new ArgumentNullException(nameof(selector));

        return IsSome ? Optional.Some(selector(Value)) : Optional.None<TResult>();
    }

    public T Return(Func<T> whenError)
    {
        return IsSome ? Value : whenError();
    }

    /// <summary>
    /// Creates a string representation of the <see cref="Optional{T}"/>.
    /// </summary>
    public override string ToString() => IsSome
            ? $"Some({Value})"
            : $"None<{typeof(T).Name}>";

    public static implicit operator T?(Optional<T> option) => option.IsSome ? option.Value : default;
    public static implicit operator Optional<T>(T? value) => Optional.FromNullable(value);
}
