using Zer0.Functional.Framework.Functors;
using Zer0.Functional.Framework.Types;

namespace Zer0.Functional.Framework.OptionalExtensions;

public static partial class Optional
{
    /// <summary>
    /// Invokes the <see cref="Effect{T}"/> with the value of the <see cref="Optional{T}"/> if it is Some.
    /// If the <see cref="Optional{T}"/> is None nothing happens.
    /// In both cases unmodified <see cref="Optional{T}"/> is returned.
    /// </summary>
    /// <typeparam name="T">Type of the value in the <see cref="Optional{T}"/>.</typeparam>
    /// <param name="this">The <see cref="Optional{T}"/> to check for a value.</param>
    /// <param name="action">Function executed if the <see cref="Optional{T}"/> is Some.</param>
    public static Optional<T> Do<T>(this Optional<T> @this, Effect<T> action)
    {
        if (@this.IsSome) action.Execute(@this.Value);
        return @this;
    }

    /// <summary>
    /// Invokes the <see cref="Effect{T}"/> if the <see cref="Optional{T}"/> is None.
    /// If the <see cref="Optional{T}"/> is Some nothing happens.
    /// In both cases unmodified <see cref="Optional{T}"/> is returned.
    /// </summary>
    /// <typeparam name="T">Type of the value in the <see cref="Optional{T}"/>.</typeparam>
    /// <param name="this">The <see cref="Optional{T}"/> to check for a value.</param>
    /// <param name="action">Function executed if the <see cref="Optional{T}"/> is None.</param>
    public static Optional<T> DoWhenNone<T>(this Optional<T> @this, Effect<Unit> action)
    {
        if (@this.IsNone) action.Execute(Unit.Value);
        return @this;
    }
}
