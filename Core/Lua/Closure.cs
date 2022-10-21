﻿using MoonSharp.Interpreter;

namespace GameEngineDemo2.Core.Lua;

public static class ClosureExtensions
{
    public static async Task<DynValue> CallAsync(this DynValue func, params object[] args)
    {
        try
        {
            var coroutine = func.Function.OwnerScript.CreateCoroutine(func);
            var result = coroutine.Coroutine.Resume(args);
            
            while (result.Type == DataType.UserData && result.UserData.Object is Task wait)
            {
                var ret = await wait.task;
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
}