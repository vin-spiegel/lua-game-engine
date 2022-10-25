using GameEngineDemo2.Core.Graphics;
using GameEngineDemo2.Core.Lua;
using GameEngineDemo2.Core.System;
using MoonSharp.Interpreter;
using MoonSharp.Interpreter.Loaders;
// ReSharper disable InconsistentNaming
#pragma warning disable CS0618

namespace GameEngineDemo2.Core;

public static class LuaScript
{
    public static readonly Script script = new Script();

    #region Methods
    
    public static void Init()
    {
        SetCustomOptions();
        Registration();
        
        var res = script.LoadFile(Project.Root + "main.lua");
        res?.CallAsync();
    }
    
    private static void SetCustomOptions()
    {
        // conversion task to wait model
        Script.GlobalOptions.CustomConverters.SetClrToScriptCustomConversion<Task<DynValue>>(
            Wait.Execute
        );
        
        // set require loader
        ((ScriptLoaderBase)script.Options.ScriptLoader).ModulePaths = new[]
        {
            Project.Root + "?.lua"
        };
    }

    private static void Registration()
    {
        // register assembly
        UserData.RegisterAssembly(typeof(Game).Assembly);
        
        // lua global functions
        script.Globals["wait"] = (Func<double, DynValue>)Globals.Wait;
        script.Globals["typeof"] = (Func<object, string?>)Globals.Typeof;
        
        // game core
        script.Globals["gameObject"] = typeof(GameObject);
        script.Globals["time"] = typeof(Time);
        
        // graphics
        script.Globals["game"] = typeof(Game);
        script.Globals["vector2"] = typeof(Vector2);
        script.Globals["rect"] = typeof(Rect);
        script.Globals["color"] = typeof(Color);
    }

    #endregion
}