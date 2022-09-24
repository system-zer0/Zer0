using Zer0.Functional.Framework.Functors;

namespace Zer0.Functional.Framework.OptionalExtensions;

public partial class Optional
{
    /// <summary>
    /// Transforms the <see cref="Optional{T}"/> into another <see cref="Optional{U}"/> using the <paramref name="binder"/> function.
    /// If the input <see cref="Optional{T}"/> is Some, returns the value of the binder call as <see cref="Optional{U}"/>.
    /// Otherwise returns None case of the <see cref="Optional{U}"/>.
    /// </summary>
    /// <typeparam name="T">Type of the value in the input <see cref="Optional{T}"/>.</typeparam>
    /// <typeparam name="U">Type of the value in the returned <see cref="Optional{U}"/>.</typeparam>
    /// <param name="this">The <see cref="Optional{T}"/> to bind with.</param>
    /// <param name="binder">Function called with the input <see cref="Optional{T}"/> value if it is Some.</param>
    public static Optional<U> Bind<T, U>(this Optional<T> @this, Func<T, U?> binder) =>
        @this.IsSome ? FromNullable(binder(@this.Value)) : None<U>();
}
