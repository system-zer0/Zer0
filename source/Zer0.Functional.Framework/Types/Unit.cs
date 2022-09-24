using Zer0.Functional.Framework.Functors;

namespace Zer0.Functional.Framework.Types;

public readonly record struct Unit
{
    private static readonly Unit _value = new();

    /// <summary>
    /// Default and only value of the <see cref="Unit"/> type.
    /// </summary>
    public static ref readonly Unit Value => ref _value;

    public static Task<Unit> Task => System.Threading.Tasks.Task.FromResult(Value);
}
