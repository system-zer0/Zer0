using Zer0.Functional.Framework.Types;
using Zer0.Functional.Framework.Functors;

namespace Zer0.Functional.Framework.ResultExtensions;

public static partial class Result
{
    public static Result<T> Success<T>(T value) => value;
    public static Result<T> Fail<T>(Error error) => error;
}
