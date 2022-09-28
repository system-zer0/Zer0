using Zer0.Functional.Framework.Types;
using Zer0.Functional.Framework.Functors;

namespace Zer0.Functional.Framework.ResultExtensions;

public static partial class Result
{
    /// <summary>
    /// If the <see cref="Result{T}"/> is in its Success State, invokes the side effect with the result value.
    /// Returns the original result regardless of the outcome of the effect.
    /// </summary>
    /// <typeparam name="T">Type of the value in the input result.</typeparam>
    /// <param name="result">The result to map on.</param>
    /// <param name="sideEffect">The side effect to invoke with the result value.</param>
    public static Result<T> Tee<T>(this Result<T> result, Action<T> sideEffect)
    {
        if (result.IsSuccess)
        {
            sideEffect.Invoke(result.Value);
        }

        return result;
    }
}
