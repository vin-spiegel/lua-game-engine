using MoonSharp.Interpreter;

namespace GameEngineDemo2.Core.Lua;

public static class ClosureExtensions
{
    /// <summary>
    /// Call Script as Closure Asynchronous
    /// </summary>
    public static async Task<DynValue> CallAsync(this DynValue func, params object[] args)
    {
        try
        {
            var coroutine = func.Function.OwnerScript.CreateCoroutine(func);
            var result = coroutine.Coroutine.Resume(args);
            
            while (result.Type == DataType.UserData && result.UserData.Object is Task wait)
            {
                var ret = await wait.luaTask;
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
}