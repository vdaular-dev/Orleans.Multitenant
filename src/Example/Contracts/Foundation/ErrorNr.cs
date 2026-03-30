#pragma warning disable CS1591 // XML documentation is generated for the sample contracts assembly, but this enum is intentionally lightweight and undocumented.

namespace Orleans4Multitenant.Contracts;

[Flags]
public enum ErrorNr
{
    UserNotFound = 1,

    ValidationError = 1024,
    IdIsNotEmpty = 1 | ValidationError
}

#pragma warning restore CS1591
