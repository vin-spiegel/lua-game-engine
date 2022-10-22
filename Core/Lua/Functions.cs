using MoonSharp.Interpreter;

namespace GameEngineDemo2.Core.Lua;

/// <summary>
/// This Engine has several unique built-in functions and variables in its Lua implementation.
/// These are not packaged by default with Lua.
/// </summary>
[MoonSharpUserData]
public static class Functions
{
    public static string? Typeof(object obj)
    {
        return obj.ToString();
    }
}