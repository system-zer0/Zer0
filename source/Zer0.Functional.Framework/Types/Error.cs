namespace Zer0.Functional.Framework.Types;

public readonly record struct Error(string Code, string Message)
{
    public static Error None => new Error(string.Empty, string.Empty);

    public static implicit operator string(Error error) => error.Code;

    public static bool operator ==(Error? a, Error? b) => Equals(a, b);

    public static bool operator !=(Error? a, Error? b) => !(a == b);
}
