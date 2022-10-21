using MoonSharp.Interpreter;

namespace GameEngineDemo2.Core.Lua;

[MoonSharpUserData]
public class Task
{
    [MoonSharpHidden]
    public readonly Task<DynValue> task;
    
    public Task(Task<DynValue> task)
    {
        this.task = task;
    }
}