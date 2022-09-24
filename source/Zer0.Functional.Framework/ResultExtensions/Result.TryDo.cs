using Zer0.Functional.Framework.Functors;
using Zer0.Functional.Framework.Types;

namespace Zer0.Functional.Framework.ResultExtensions;

public static partial class Result
{
    /// <summary>
    /// Tries to perform the <paramref name="action"/> with the value of the <paramref name="result"/> if it's Ok case.
    /// If the action fails the error handler is used to generate an <see cref="Error"/> result
    /// In all other cases the unmodified result is returned.
    /// </summary>
    /// <typeparam name="T">Type of the value in the result.</typeparam>
    /// <param name="result">The result to check for a value.</param>
    /// <param name="action">Function executed if the result is Ok case.</param>
    /// <param name="errorHandler">Function that generates error details in case of exception.</param>
    public static Result<T> Tap<T>(this Result<T> result, Effect<T> action, Func<Exception, Error> errorHandler)
    {
        if (!result.IsSuccess) return result;
        Result<Unit> tapResult = action.TryExecute(result.Value, errorHandler);
        return tapResult.IsFailure ? tapResult.Error : result;
    }

    /// <summary>
    /// Performs the <paramref name="action"/> with the value of the <paramref name="result"/> if it's Ok case.
    /// If the action fails the <see cref="Error"/> from the tap action is returned.
    /// In all other cases the unmodified result is returned.
    /// </summary>
    /// <typeparam name="T">Type of the value in the result.</typeparam>
    /// <param name="result">The result to check for a value.</param>
    /// <param name="action">Function executed if the result is Ok case.</param>
    /// <param name="errorHandler">Function that generates error details in case of exception.</param>
    public static async Task<Result<T>> TapAsync<T>(
        this Result<T> result,
        AsyncEffect<T> action,
        Func<Exception, Error> errorHandler)
    {
        if (!result.IsSuccess) return result;

        Result<Unit> tapResult = await action.TryExecute(result.Value, errorHandler);

        return tapResult.IsFailure ? tapResult.Error : result;
    }

    /// <summary>
    /// Performs the <paramref name="action"/> with the value of the <paramref name="result"/> if it's Ok case.
    /// If the action fails the <see cref="Error"/> from the tap action is returned.
    /// In all other cases the unmodified result is returned.
    /// </summary>
    /// <typeparam name="T">Type of the value in the result.</typeparam>
    /// <typeparam name="U">Type of the value in the tap result.</typeparam>
    /// <param name="result">The result to check for a value.</param>
    /// <param name="action">Function executed if the result is Ok case.</param>
    /// <param name="errorHandler">Function that generates error details in case of exception.</param>
    public static async Task<Result<T>> TapAsync<T, U>(
        this Task<Result<T>> result,
        AsyncEffect<T> action,
        Func<Exception, Error> errorHandler) =>
        await (await result).TapAsync(action, errorHandler);
}
