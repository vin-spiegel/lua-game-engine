using MoonSharp.Interpreter;

namespace GameEngineDemo2.Core;

[MoonSharpUserData]
public class LuaAwait
{
    public Task<DynValue> Task;
    public LuaAwait(Task<DynValue> task)
    {
        Task = task;
    }
}

public static class LuaAPI
{
    private static readonly string ScriptDirectory = Path.GetFullPath(@"..\..\..\Sample\Scripts\");
    private static Script _script = new Script();
    
    public static async Task<DynValue> CallAsync(DynValue func, params object[] args)
    {
        try
        {
            var coroutine = func.Function.OwnerScript.CreateCoroutine(func);
            var result = coroutine.Coroutine.Resume(args);
            
            while (result.Type == DataType.UserData && result.UserData.Object is LuaAwait wait)
            {
                var ret = await wait.Task;
                result = coroutine.Coroutine.Resume(ret);
            }
            return result;
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex);
            throw;
        }
    }
    
    public static void LoadInitScript()
    {
        Script.GlobalOptions.CustomConverters.SetClrToScriptCustomConversion<Task<DynValue>>(
            task => Await(task)
        );
        RegisterType();
        LoadApiFunction();
        var res = _script.LoadFile(ScriptDirectory + "main.lua");

        CallAsync(res);
    }
    
    private static void RegisterType()
    {
        UserData.RegisterType<GameWindow>();
        UserData.RegisterType<LuaAwait>();
        UserData.RegisterType<Point>();
    }
    
    static void LoadApiFunction()
    {
        _script.Globals["wait"] = (Func<double, DynValue>)Wait;
        _script.Globals["window"] = typeof(GameWindow);
        _script.Globals["point"] = (Func<float,float,Point>)Point.New;
    }
    
    public static DynValue Await(Task<DynValue> task)
    {
        return DynValue.NewYieldReq(
            new[] { UserData.Create(new LuaAwait(task)) }
        );
    }

    public static DynValue Await(Task task)
    {
        async Task<DynValue> WaitTask()
        {
            await task;
            return DynValue.Void;
        }
        return Await(WaitTask());
    }
    
    private static DynValue Wait(double t)
    {
        return Await(Task.Delay((int)(t * 1000.0f)));
    }
}