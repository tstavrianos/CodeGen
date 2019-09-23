using System;

namespace CodeGen
{
    [Flags]
    public enum Modifiers
    {
        None = 0,
        Public = 1,
        Protected = 2,
        Internal = 4,
        Private = 8,
        Static = 16,
        Const = 32,
        Sealed = 64,
        Abstract = 128,
        Virtual = 256,
        Override = 512,
        Implicit = 1024,
        Explicit = 2048,
        Operator = 4096,
        ReadOnly = 8192,
        Partial = 16384
    }
}