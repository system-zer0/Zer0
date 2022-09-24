using Zer0.Functional.Framework.Types;
using Zer0.Functional.Framework.Functors;

namespace Zer0.Functional.Framework.ResultExtensions;

public static partial class Result
{
    public static Result<T> Success<T>(T value) => value;
    public static Result<T> Fail<T>(Error error) => error;

    /// <summary>
    /// Transforms <see cref="Result{T}"/> with async value inside to <see cref="Task{T}"/> of the result,
    /// preserving original result's state and value.
    /// </summary>
    /// <typeparam name="T">Type of the value in the result.</typeparam>
    /// <param name="result">Result to take the value from.</param>
    public static async Task<Result<T>> WarpAsync<T>(this Result<Task<T>> result) =>
        result.IsSuccess ? await result.Value : result.Error;
}
