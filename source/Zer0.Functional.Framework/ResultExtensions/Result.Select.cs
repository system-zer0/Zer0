using Zer0.Functional.Framework.Functors;

namespace Zer0.Functional.Framework.ResultExtensions;

public static partial class Result
{
    /// <summary>
    /// Maps the value of the <paramref name="result"/> into another <see cref="Result{T}"/> using the <paramref name="selector"/> function.
    /// If the input result is Ok, returns the Ok case with the value of the mapper call (which is <typeparamref name="TOut"/>).
    /// Otherwise returns Error case of the Result of <typeparamref name="TOut"/>.
    /// </summary>
    /// <typeparam name="TIn">Type of the value in the input result.</typeparam>
    /// <typeparam name="TOut">Type of the value in the returned result.</typeparam>
    /// <param name="result">The result to map on.</param>
    /// <param name="selector">Function called with the input result value if it's Ok case.</param>
    public static async Task<Result<TOut>>
        SelectAsync<TIn, TOut>(this Result<TIn> result, Func<TIn, Task<TOut>> selector) =>
        result.IsSuccess ? await selector(result.Value) : result.Error;

    /// <summary>
    /// Maps the value of the <paramref name="result"/> into another <see cref="Result{T}"/> using the <paramref name="selector"/> function.
    /// If the input result is Ok, returns the Ok case with the value of the mapper call (which is <typeparamref name="TOut"/>).
    /// Otherwise returns Error case of the Result of <typeparamref name="TOut"/>.
    /// </summary>
    /// <typeparam name="TIn">Type of the value in the input result.</typeparam>
    /// <typeparam name="TOut">Type of the value in the returned result.</typeparam>
    /// <param name="result">The result to map on.</param>
    /// <param name="selector">Function called with the input result value if it's Ok case.</param>
    public static async Task<Result<TOut>> SelectAsync<TIn, TOut>(
        this Task<Result<TIn>> result,
        Func<TIn, Task<TOut>> selector)
        => await (await result).SelectAsync(selector);

    /// <summary>
    /// Maps the value of the <paramref name="result"/> into another <see cref="Result{T}"/> using the <paramref name="selector"/> function.
    /// If the input result is Ok, returns the Ok case with the value of the mapper call (which is <typeparamref name="TOut"/>).
    /// Otherwise returns Error case of the Result of <typeparamref name="TOut"/>.
    /// </summary>
    /// <typeparam name="TIn">Type of the value in the input result.</typeparam>
    /// <typeparam name="TOut">Type of the value in the returned result.</typeparam>
    /// <param name="result">The result to map on.</param>
    /// <param name="selector">Function called with the input result value if it's Ok case.</param>
    public static async Task<Result<TOut>> SelectAsync<TIn, TOut>(
        this Task<Result<TIn>> result,
        Func<TIn, TOut> selector) =>
        (await result).Select(selector);
}
