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
    
    public static void LoadInitScript()
    {
        Script.GlobalOptions.CustomConverters.SetClrToScriptCustomConversion<Task<DynValue>>(
            task => Await(task)
        );
        RegisterType();
        LoadApiFunction();
        _script.DoFile(ScriptDirectory + "main.lua");
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
    public static DynValue Await(Task<DynValue> task) => 
        DynValue.NewYieldReq(new[] { UserData.Create(new LuaAwait(task)) });

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
    
    private static DynValue Wait(double t)
    {
        return Await(Task.Delay((int)(t * 1000.0f)) as Task<DynValue>);
    }
}