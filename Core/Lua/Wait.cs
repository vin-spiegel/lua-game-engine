using MoonSharp.Interpreter;

namespace GameEngineDemo2.Core.Lua;

/// <summary>
/// Yields the current thread until the specified amount of time in seconds have elapsed, with throttling.
/// </summary>
public class Wait
{
    /// <exclude/>
    [MoonSharpUserDataMetamethod("__call")]
    public static DynValue __call(object self)
    {
        return Execute(0);
    }
    
    /// <exclude/>
    [MoonSharpUserDataMetamethod("__call")]
    public static DynValue __call(Wait self, double t)
    {
        return Execute(t);
    }
    
    private static DynValue Execute(double t)
    {
        return Execute(global::System.Threading.Tasks.Task.Delay((int)(t * 1000f)));
    }
    
    [MoonSharpHidden]
    public static DynValue Execute(Task<DynValue> task)
    {
        return DynValue.NewYieldReq(new[]
        {
            UserData.Create(new Task(task))
        });
    }

    private static DynValue Execute(global::System.Threading.Tasks.Task task)
    {
        async Task<DynValue> WaitTask()
        {
            await task;
            return DynValue.Void;
        }
        return Execute(WaitTask());
    }
}