using MoonSharp.Interpreter;

namespace GameEngineDemo2.Core;

[MoonSharpUserData]
public class LuaTask
{
    [MoonSharpHidden]
    public readonly Task<DynValue> Task;
    
    [MoonSharpHidden]
    public LuaTask(Task<DynValue> task)
    {
        Task = task;
    }
}

public static class LuaWaitModel
{
    public static DynValue Wait(double t)
    {
        return _Await(Task.Delay((int)(t * 1000f)));
    }
    
    public static async Task<DynValue> CallAsync(this DynValue func, params object[] args)
    {
        try
        {
            var coroutine = func.Function.OwnerScript.CreateCoroutine(func);
            var result = coroutine.Coroutine.Resume(args);
            
            while (result.Type == DataType.UserData && result.UserData.Object is LuaTask wait)
            {
                var ret = await wait.Task;
                result = coroutine.Coroutine.Resume(ret);
            }
            return result;
        }
        catch (InterpreterException ex)
        {
            Console.WriteLine(ex.DecoratedMessage);
            throw;
        }
    }
    
    public static DynValue Await(Task<DynValue> task)
    {
        return DynValue.NewYieldReq(new[]
        {
            UserData.Create(new LuaTask(task))
        });
    }

    private static DynValue _Await(Task task)
    {
        async Task<DynValue> WaitTask()
        {
            await task;
            return DynValue.Void;
        }
        return Await(WaitTask());
    }
}

public static class LuaScript
{
    private static readonly string ScriptDirectory = Path.GetFullPath(@"..\..\..\Sample\Scripts\");
    private static Script _script = new Script();
    
    public static void Init()
    {
        Script.GlobalOptions.CustomConverters.SetClrToScriptCustomConversion<Task<DynValue>>(
            LuaWaitModel.Await
        );
        
        RegisterType();
        LoadApiFunction();
        
        var res = _script.LoadFile(ScriptDirectory + "main.lua");
        res?.CallAsync();
    }
    
    private static void RegisterType()
    {
        UserData.RegisterType<GameWindow>();
        UserData.RegisterType<LuaTask>();
        UserData.RegisterType<Point>();
    }
    
    private static void LoadApiFunction()
    {
        _script.Globals["wait"] = (Func<double, DynValue>)LuaWaitModel.Wait;
        _script.Globals["window"] = typeof(GameWindow);
        _script.Globals["point"] = (Func<float,float,Point>)Point.New;
    }
}