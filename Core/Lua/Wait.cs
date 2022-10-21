using MoonSharp.Interpreter;

namespace GameEngineDemo2.Core.Lua;

public class Wait
{
    /// <exclude/>
    [MoonSharpUserDataMetamethod("__call")]
    public static DynValue __call(object self, double t)
    {
        return Execute(t);
    }
    
    private static DynValue Execute(double t)
    {
        return Execute(System.Threading.Tasks.Task.Delay((int)(t * 1000f)));
    }
    
    [MoonSharpHidden]
    public static DynValue Execute(Task<DynValue> task)
    {
        return DynValue.NewYieldReq(new[]
        {
            UserData.Create(new Task(task))
        });
    }

    private static DynValue Execute(System.Threading.Tasks.Task task)
    {
        async Task<DynValue> WaitTask()
        {
            await task;
            return DynValue.Void;
        }
        return Execute(WaitTask());
    }
}