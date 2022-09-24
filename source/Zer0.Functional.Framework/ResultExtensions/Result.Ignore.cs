using Zer0.Functional.Framework.Types;
using Zer0.Functional.Framework.Functors;

namespace Zer0.Functional.Framework.ResultExtensions;

public static partial class Result
{
    ///<summary>
    /// Ignores the value of the <see cref="Result{T}" /> and returns <see cref="Result{Unit}" /> instead.
    /// If the input <see cref="Result{T}" /> is Error then the error details are preserved.
    ///</summary>
    /// <typeparam name="T">Type of the encapsulated value.</typeparam>
    /// <param name="result">The result of which the value should be ignored.</param>
    public static Result<Unit> Ignore<T>(this Result<T> result) => result.Select(_ => Unit.Value);

    ///<summary>
    /// Rejects the value of the <see cref="Result{T}" /> and returns <see cref="Result{Unit}" /> instead.
    /// If the input <see cref="Result{T}" /> is Error then the error details are preserved.
    ///</summary>
    /// <typeparam name="T">Type of the encapsulated value.</typeparam>
    /// <param name="result">The result of which the value should be ignored.</param>
    public static async Task<Result<Unit>> IgnoreAsync<T>(this Task<Result<T>> result) => (await result).Ignore();
}
