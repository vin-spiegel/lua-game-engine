using MoonSharp.Interpreter;
// ReSharper disable ClassNeverInstantiated.Global

namespace GameEngineDemo2.Core.Lua;

[MoonSharpUserData]
public class Wait
{
    public static DynValue Execute(double t)
    {
        return Execute(global::System.Threading.Tasks.Task.Delay((int)(t * 1000f)));
    }
    
    [MoonSharpHidden]
    public static DynValue Execute(global::System.Threading.Tasks.Task<DynValue> task)
    {
        return DynValue.NewYieldReq(new[]
        {
            UserData.Create(new Task(task))
        });
    }

    private static DynValue Execute(global::System.Threading.Tasks.Task task)
    {
        async global::System.Threading.Tasks.Task<DynValue> WaitTask()
        {
            await task;
            return DynValue.Void;
        }
        return Execute(WaitTask());
    }
}