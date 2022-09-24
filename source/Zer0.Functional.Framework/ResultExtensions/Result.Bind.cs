using Zer0.Functional.Framework.Types;
using Zer0.Functional.Framework.Functors;

namespace Zer0.Functional.Framework.ResultExtensions;

public static partial class Result
{
    /// <summary>
    /// Transforms the <paramref name="result"/> into another <see cref="Result{T}"/> using the <paramref name="binder"/> function.
    /// If the input result is Ok, returns the value of the binder call (which is <see cref="Result{T}"/> of <typeparamref name="TOut"/>).
    /// Otherwise returns Error case of the Result of <typeparamref name="TOut"/>.
    /// </summary>
    /// <typeparam name="TIn">Type of the value in the input result.</typeparam>
    /// <typeparam name="TOut">Type of the value in the returned result.</typeparam>
    /// <param name="result">The result to bind with.</param>
    /// <param name="binder">Function called with the input result value if it's Ok case.</param>
    public static Result<TOut> Bind<TIn, TOut>(this Result<TIn> result, Func<TIn, Result<TOut>> binder) =>
        result.IsSuccess ? binder(result.Value) : result.Error;

    /// <summary>
    /// Transforms the <paramref name="result"/> into another <see cref="Result{T}"/> using the <paramref name="binder"/> function.
    /// If the input result is Ok, returns the value of the binder call (which is <see cref="Result{T}"/> of <typeparamref name="TOut"/>).
    /// Otherwise returns Error case of the Result of <typeparamref name="TOut"/>.
    /// </summary>
    /// <typeparam name="TIn">Type of the value in the input result.</typeparam>
    /// <typeparam name="TOut">Type of the value in the returned result.</typeparam>
    /// <param name="result">The result to bind with.</param>
    /// <param name="binder">Function called with the input result value if it's Ok case.</param>
    public static async Task<Result<TOut>> BindAsync<TIn, TOut>(
        this Result<TIn> result,
        Func<TIn, Task<Result<TOut>>> binder) =>
        result.IsSuccess ? await binder(result.Value) : result.Error;

    /// <summary>
    /// Transforms the <paramref name="result"/> into another <see cref="Result{T}"/> using the <paramref name="binder"/> function.
    /// If the input result is Ok, returns the value of the binder call (which is <see cref="Result{T}"/> of <typeparamref name="TOut"/>).
    /// Otherwise returns Error case of the Result of <typeparamref name="TOut"/>.
    /// </summary>
    /// <typeparam name="TIn">Type of the value in the input result.</typeparam>
    /// <typeparam name="TOut">Type of the value in the returned result.</typeparam>
    /// <param name="result">The result to bind with.</param>
    /// <param name="binder">Function called with the input result value if it's Ok case.</param>
    public static async Task<Result<TOut>> BindAsync<TIn, TOut>(
        this Task<Result<TIn>> result,
        Func<TIn, Task<Result<TOut>>> binder)
        => await (await result).BindAsync(binder);

    /// <summary>
    /// Transforms the <paramref name="result"/> into another <see cref="Result{T}"/> using the <paramref name="binder"/> function.
    /// If the input result is Ok, returns the value of the binder call (which is <see cref="Result{T}"/> of <typeparamref name="TOut"/>).
    /// Otherwise returns Error case of the Result of <typeparamref name="TOut"/>.
    /// </summary>
    /// <typeparam name="TIn">Type of the value in the input result.</typeparam>
    /// <typeparam name="TOut">Type of the value in the returned result.</typeparam>
    /// <param name="result">The result to bind with.</param>
    /// <param name="binder">Function called with the input result value if it's Ok case.</param>
    public static async Task<Result<TOut>> BindAsync<TIn, TOut>(
        this Task<Result<TIn>> result,
        Func<TIn, Result<TOut>> binder)
        => (await result).Bind(binder);
}
