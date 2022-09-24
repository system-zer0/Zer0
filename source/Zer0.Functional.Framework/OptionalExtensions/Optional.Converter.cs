using Zer0.Functional.Framework.Functors;

namespace Zer0.Functional.Framework.OptionalExtensions;

public partial class Optional
{
    /// <summary>
    /// Creates a Some instance of the <see cref="Optional{T}"/> type, encapsulating the provided value.
    /// </summary>
    /// <typeparam name="T">Type of the encapsulated value.</typeparam>
    /// <param name="value">The value to encapsulate.</param>
    public static Optional<T> Some<T>(T value) => new Optional<T>(value);

    /// <summary>
    /// Creates the None case instance of the <see cref="Optional{T}"/> type, containing no value.
    /// </summary>
    /// <typeparam name="T">Desired type parameter for <see cref="Optional{T}"/> type.</typeparam>
    public static Optional<T> None<T>() => default;

    /// <summary>
    /// Creates a <see cref="Optional{T}"/> from a nullable object.
    /// </summary>
    /// <param name="value">The (possibly <see langword="null"/>) value</param>
    /// <typeparam name="T">Desired type parameter for <see cref="Optional{T}"/> type.</typeparam>
    public static Optional<T> FromNullable<T>(T? value) => value is null ? None<T>() : Some(value);

    /// <summary>
    /// Creates a nullable <see cref="T"/> from a <see cref="Optional{T}"/>.
    /// </summary>
    /// <param name="this">The <see cref="Optional{T}"/> to unwrap</param>
    /// <typeparam name="T">Desired type parameter for <see cref="Optional{T}"/> type.</typeparam>
    public static T? AsNullable<T>(this Optional<T> @this) => @this.IsSome ? @this.Value : default;
}
