using Zer0.Functional.Framework.Functors;

namespace Zer0.Functional.Framework.OptionalExtensions;

public static partial class Optional
{
    /// <summary>
    /// Performs pattern matching on the <see cref="Optional{T}"/> type.
    /// If the <paramref name="this"/> is Some, calls the <paramref name="some"/> function
    /// with the value from the <see cref="Optional{T}"/> as a parameter and returns its result.
    /// Otherwise calls the <paramref name="none"/> function and returns its result.
    /// </summary>
    /// <typeparam name="TIn">Type of the value in the <see cref="Optional{T}"/>.</typeparam>
    /// <typeparam name="TOut">Type of the returned value.</typeparam>
    /// <param name="this">The <see cref="Optional{T}"/> to match on.</param>
    /// <param name="some">Function called for the Some case.</param>
    /// <param name="none">Function called for the None case.</param>
    public static TOut Match<TIn, TOut>(this Optional<TIn> @this, Func<TIn, TOut> some, Func<TOut> none) =>
        @this.IsSome ? some(@this.Value) : none();

    /// <summary>
    /// Performs pattern matching on the <see cref="Optional{T}"/> type.
    /// If the <see cref="Optional{T}"/> is Some, returns the <paramref name="some"/> value.
    /// Otherwise returns the <paramref name="none"/> value.
    /// </summary>
    /// <typeparam name="TIn">Type of the value in the <see cref="Optional{T}"/>.</typeparam>
    /// <typeparam name="TOut">Type of the returned value.</typeparam>
    /// <param name="this">The <see cref="Optional{T}"/> to match on.</param>
    /// <param name="some">Value returned for the Some case.</param>
    /// <param name="none">Value returned for the None case.</param>
    public static TOut MatchTo<TIn, TOut>(this Optional<TIn> @this, TOut some, TOut none) =>
        @this.IsSome ? some : none;
}
