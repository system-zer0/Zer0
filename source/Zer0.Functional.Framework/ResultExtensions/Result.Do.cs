using Zer0.Functional.Framework.Types;
using Zer0.Functional.Framework.Functors;

namespace Zer0.Functional.Framework.ResultExtensions;

public static partial class Result
{
    /// <summary>
    /// Performs the <paramref name="effect"/> with the value of the <paramref name="result"/> if it's Ok case.
    /// If the result is Error case nothing happens.
    /// In both cases unmodified result is returned.
    /// </summary>
    /// <typeparam name="T">Type of the value in the result.</typeparam>
    /// <param name="result">The result to check for a value.</param>
    /// <param name="effect">Function executed if the result is Ok case.</param>
    public static Result<T> Do<T>(this Result<T> result, Effect<T> effect)
    {
        if (result.IsSuccess) effect.Execute(result.Value);
        return result;
    }

    /// <summary>
    /// Performs the <paramref name="effect"/> if the <paramref name="result"/> is Error case.
    /// If the result is Ok case nothing happens.
    /// In both cases unmodified result is returned.
    /// </summary>
    /// <typeparam name="T">Type of the value in the result.</typeparam>
    /// <param name="result">The result to check for a value.</param>
    /// <param name="effect">Function executed if the result is Error case.</param>
    public static Result<T> DoWhenError<T>(this Result<T> result, Effect<Error> effect)
    {
        if (result.IsFailure) effect.Execute(result.Error);
        return result;
    }

    /// <summary>
    /// Performs the <paramref name="effect"/> with the value of the <paramref name="result"/> if it's Ok case.
    /// If the result is Error case nothing happens.
    /// In both cases unmodified result is returned.
    /// </summary>
    /// <typeparam name="T">Type of the value in the result.</typeparam>
    /// <param name="result">The result to check for a value.</param>
    /// <param name="effect">Function executed if the result is Ok case.</param>
    public static async Task<Result<T>> DoAsync<T>(this Task<Result<T>> result, Effect<T> effect) =>
        (await result).Do(effect);

    /// <summary>
    /// Performs the <paramref name="effect"/> with the value of the <paramref name="result"/> if it's Ok case.
    /// If the result is Error case nothing happens.
    /// In both cases unmodified result is returned.
    /// </summary>
    /// <typeparam name="T">Type of the value in the result.</typeparam>
    /// <param name="result">The result to check for a value.</param>
    /// <param name="effect">Function executed if the result is Ok case.</param>
    public static async Task<Result<T>> DoAsync<T>(this Result<T> result, AsyncEffect<T> effect)
    {
        if (result.IsSuccess) await effect.Execute(result.Value);
        return result;
    }

    /// <summary>
    /// Performs the <paramref name="effect"/> with the value of the <paramref name="result"/> if it's Ok case.
    /// If the result is Error case nothing happens.
    /// In both cases unmodified result is returned.
    /// </summary>
    /// <typeparam name="T">Type of the value in the result.</typeparam>
    /// <param name="result">The result to check for a value.</param>
    /// <param name="effect">Function executed if the result is Ok case.</param>
    public static async Task<Result<T>> DoAsync<T>(this Task<Result<T>> result, AsyncEffect<T> effect) =>
        await (await result).DoAsync(effect);

    /// <summary>
    /// Performs the <paramref name="effect"/> if the <paramref name="result"/> is Error case.
    /// If the result is Ok case nothing happens.
    /// In both cases unmodified result is returned.
    /// </summary>
    /// <typeparam name="T">Type of the value in the result.</typeparam>
    /// <param name="result">The result to check for a value.</param>
    /// <param name="effect">Function executed if the result is Error case.</param>
    public static async Task<Result<T>> DoWhenErrorAsync<T>(this Result<T> result, AsyncEffect<Error> effect)
    {
        if (result.IsFailure) await effect.Execute(result.Error);
        return result;
    }

    /// <summary>
    /// Performs the <paramref name="effect"/> if the <paramref name="result"/> is Error case.
    /// If the result is Ok case nothing happens.
    /// In both cases unmodified result is returned.
    /// </summary>
    /// <typeparam name="T">Type of the value in the result.</typeparam>
    /// <param name="result">The result to check for a value.</param>
    /// <param name="effect">Function executed if the result is Error case.</param>
    public static async Task<Result<T>> DoWhenErrorAsync<T>(this Task<Result<T>> result, AsyncEffect<Error> effect) =>
        await (await result).DoWhenErrorAsync(effect);
}
