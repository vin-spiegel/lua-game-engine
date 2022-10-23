using MoonSharp.Interpreter;

namespace GameEngineDemo2.Core.Lua;

/// <summary>
/// This Engine has several unique built-in functions and variables in its Lua implementation.
/// These are not packaged by default with Lua.
/// </summary>
public static class Globals
{
    /// <summary>
    /// Returns the type of the given object as a string
    /// also supporting specific types (e.g. Vector).
    /// </summary>
    public static string? Typeof(object obj)
    {
        return obj.ToString();
    }
    
    /// <summary>
    /// Yields the current thread until the specified amount of time in seconds have elapsed, with throttling.
    /// </summary>
    public static DynValue Wait(double t = 0)
    {
        return Lua.Wait.Execute(t);
    }
}