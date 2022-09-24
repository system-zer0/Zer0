using Zer0.Functional.Framework.Types;
using Zer0.Functional.Framework.Functors;

namespace Zer0.Functional.Framework.ResultExtensions;

public static partial class Result
{
    /// <summary>
    /// Does the pattern matching on the <see cref="Result{T}"/> type.
    /// If the <paramref name="result"/> is Ok, calls <paramref name="ok"/> function
    /// with the value from the result as a parameter and returns its result.
    /// Otherwise calls <paramref name="error"/> function and returns its result.
    /// </summary>
    /// <typeparam name="TIn">Type of the value in the result.</typeparam>
    /// <typeparam name="TOut">Type of the returned value.</typeparam>
    /// <param name="result">The result to match on.</param>
    /// <param name="ok">Function called for the Ok case.</param>
    /// <param name="error">Function called for the Error case.</param>
    public static TOut Match<TIn, TOut>(this Result<TIn> result, Func<TIn, TOut> ok, Func<Error, TOut> error) =>
        result.IsSuccess ? ok(result.Value) : error(result.Error);

    /// <summary>
    /// Does the pattern matching on the <see cref="Result{T}"/> type.
    /// If the <paramref name="result"/> is Ok, returns <paramref name="ok"/> value.
    /// Otherwise returns <paramref name="error"/> value.
    /// </summary>
    /// <typeparam name="TIn">Type of the value in the result.</typeparam>
    /// <typeparam name="TOut">Type of the returned value.</typeparam>
    /// <param name="result">The result to match on.</param>
    /// <param name="ok">Value returned for the Ok case.</param>
    /// <param name="error">Value returned for the Error case.</param>
    public static TOut MatchTo<TIn, TOut>(this Result<TIn> result, TOut ok, TOut error) =>
        result.IsSuccess ? ok : error;

        /// <summary>
    /// Does the pattern matching on the <see cref="Result{T}"/> type.
    /// If the <paramref name="result"/> is Ok, calls <paramref name="ok"/> function
    /// with the value from the result as a parameter and returns its result.
    /// Otherwise calls <paramref name="error"/> function and returns its result.
    /// </summary>
    /// <typeparam name="TIn">Type of the value in the result.</typeparam>
    /// <typeparam name="TOut">Type of the returned value.</typeparam>
    /// <param name="result">The result to match on.</param>
    /// <param name="ok">Function called for the Ok case.</param>
    /// <param name="error">Function called for the Error case.</param>
    public static async Task<TOut> MatchAsync<TIn, TOut>(this Result<TIn> result, Func<TIn, Task<TOut>> ok,
        Func<Error, Task<TOut>> error) =>
        result.IsSuccess ? await ok(result.Value) : await error(result.Error);

    /// <summary>
    /// Does the pattern matching on the <see cref="Result{T}"/> type.
    /// If the <paramref name="result"/> is Ok, calls <paramref name="ok"/> function
    /// with the value from the result as a parameter and returns its result.
    /// Otherwise calls <paramref name="error"/> function and returns its result.
    /// </summary>
    /// <typeparam name="TIn">Type of the value in the result.</typeparam>
    /// <typeparam name="TOut">Type of the returned value.</typeparam>
    /// <param name="result">The result to match on.</param>
    /// <param name="ok">Function called for the Ok case.</param>
    /// <param name="error">Function called for the Error case.</param>
    public static async Task<TOut> MatchAsync<TIn, TOut>(this Result<TIn> result, Func<TIn, Task<TOut>> ok,
        Func<Error, TOut> error) =>
        result.IsSuccess ? await ok(result.Value) : error(result.Error);

    /// <summary>
    /// Does the pattern matching on the <see cref="Result{T}"/> type.
    /// If the <paramref name="result"/> is Ok, calls <paramref name="ok"/> function
    /// with the value from the result as a parameter and returns its result.
    /// Otherwise calls <paramref name="error"/> function and returns its result.
    /// </summary>
    /// <typeparam name="TIn">Type of the value in the result.</typeparam>
    /// <typeparam name="TOut">Type of the returned value.</typeparam>
    /// <param name="result">The result to match on.</param>
    /// <param name="ok">Function called for the Ok case.</param>
    /// <param name="error">Function called for the Error case.</param>
    public static async Task<TOut> MatchAsync<TIn, TOut>(this Result<TIn> result, Func<TIn, TOut> ok,
        Func<Error, Task<TOut>> error) =>
        result.IsSuccess ? ok(result.Value) : await error(result.Error);

    /// <summary>
    /// Does the pattern matching on the <see cref="Result{T}"/> type.
    /// If the <paramref name="result"/> is Ok, calls <paramref name="ok"/> function
    /// with the value from the result as a parameter and returns its result.
    /// Otherwise calls <paramref name="error"/> function and returns its result.
    /// </summary>
    /// <typeparam name="TIn">Type of the value in the result.</typeparam>
    /// <typeparam name="TOut">Type of the returned value.</typeparam>
    /// <param name="result">The result to match on.</param>
    /// <param name="ok">Function called for the Ok case.</param>
    /// <param name="error">Function called for the Error case.</param>
    public static async Task<TOut> MatchAsync<TIn, TOut>(this Task<Result<TIn>> result, Func<TIn, TOut> ok,
        Func<Error, TOut> error) => (await result).Match(ok, error);

    /// <summary>
    /// Does the pattern matching on the <see cref="Result{T}"/> type.
    /// If the <paramref name="result"/> is Ok, calls <paramref name="ok"/> function
    /// with the value from the result as a parameter and returns its result.
    /// Otherwise calls <paramref name="error"/> function and returns its result.
    /// </summary>
    /// <typeparam name="TIn">Type of the value in the result.</typeparam>
    /// <typeparam name="TOut">Type of the returned value.</typeparam>
    /// <param name="result">The result to match on.</param>
    /// <param name="ok">Function called for the Ok case.</param>
    /// <param name="error">Function called for the Error case.</param>
    public static async Task<TOut> MatchAsync<TIn, TOut>(this Task<Result<TIn>> result, Func<TIn, Task<TOut>> ok,
        Func<Error, Task<TOut>> error) => await (await result).MatchAsync(ok, error);

    /// <summary>
    /// Does the pattern matching on the <see cref="Result{T}"/> type.
    /// If the <paramref name="result"/> is Ok, calls <paramref name="ok"/> function
    /// with the value from the result as a parameter and returns its result.
    /// Otherwise calls <paramref name="error"/> function and returns its result.
    /// </summary>
    /// <typeparam name="TIn">Type of the value in the result.</typeparam>
    /// <typeparam name="TOut">Type of the returned value.</typeparam>
    /// <param name="result">The result to match on.</param>
    /// <param name="ok">Function called for the Ok case.</param>
    /// <param name="error">Function called for the Error case.</param>
    public static async Task<TOut> MatchAsync<TIn, TOut>(this Task<Result<TIn>> result, Func<TIn, Task<TOut>> ok,
        Func<Error, TOut> error) => await (await result).MatchAsync(ok, error);

    /// <summary>
    /// Does the pattern matching on the <see cref="Result{T}"/> type.
    /// If the <paramref name="result"/> is Ok, calls <paramref name="ok"/> function
    /// with the value from the result as a parameter and returns its result.
    /// Otherwise calls <paramref name="error"/> function and returns its result.
    /// </summary>
    /// <typeparam name="TIn">Type of the value in the result.</typeparam>
    /// <typeparam name="TOut">Type of the returned value.</typeparam>
    /// <param name="result">The result to match on.</param>
    /// <param name="ok">Function called for the Ok case.</param>
    /// <param name="error">Function called for the Error case.</param>
    public static async Task<TOut> MatchAsync<TIn, TOut>(this Task<Result<TIn>> result, Func<TIn, TOut> ok,
        Func<Error, Task<TOut>> error) => await (await result).MatchAsync(ok, error);
}
