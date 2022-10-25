using MoonSharp.Interpreter;
// ReSharper disable InconsistentNaming

namespace GameEngineDemo2.Core.Lua;

/// <summary>
/// Special Type for use `Lua` wait function
/// </summary>
[MoonSharpUserData]
public class Task
{
    [MoonSharpHidden]
    public readonly Task<DynValue> luaTask;
    
    public Task(Task<DynValue> luaTask)
    {
        this.luaTask = luaTask;
    }
}