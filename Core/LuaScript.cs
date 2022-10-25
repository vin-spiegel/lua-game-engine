using GameEngineDemo2.Core.Graphics;
using GameEngineDemo2.Core.Lua;
using GameEngineDemo2.Core.System;
using MoonSharp.Interpreter;
using MoonSharp.Interpreter.Loaders;
using Task = GameEngineDemo2.Core.Lua.Task;
// ReSharper disable InconsistentNaming
#pragma warning disable CS0618

namespace GameEngineDemo2.Core;

public static class LuaScript
{
    private static readonly string ScriptDirectory = Path.GetFullPath(@"..\..\..\Sample\Scripts\");
    public static readonly Script script = new Script();

    private static void SetCustomOptions()
    {
        // conversion task to wait model
        Script.GlobalOptions.CustomConverters.SetClrToScriptCustomConversion<Task<DynValue>>(
            Wait.Execute
        );

        // conversion hash set to table
        // Script.GlobalOptions.CustomConverters.SetClrToScriptCustomConversion<HashSet<Entity>>(set =>
        // {
        //     var t = new Table(script);
        //     foreach (var entity in set)
        //     {
        //     }
        //     return DynValue.NewTable(t);
        // });
        
        // set require loader
        ((ScriptLoaderBase)script.Options.ScriptLoader).ModulePaths = new string[]
        {
            @"C:/Projects/lua-game-engine/Sample/Scripts/?",
            @"C:/Projects/lua-game-engine/Sample/Scripts/?.lua" 
        };
    }
    
    public static void Init()
    {
        SetCustomOptions();
        Registration();
        
        var res = script.LoadFile(ScriptDirectory + "main.lua");
        res?.CallAsync();
    }

    private static void Registration()
    {
        // register assembly
        UserData.RegisterAssembly(typeof(Window).Assembly);
        
        // lua global functions
        script.Globals["wait"] = (Func<double, DynValue>)Globals.Wait;
        script.Globals["typeof"] = (Func<object, string?>)Globals.Typeof;
        
        // core game
        script.Globals["entity"] = typeof(Entity);
        
        // graphics
        script.Globals["window"] = typeof(Window);
        script.Globals["point"] = typeof(Vector);
        script.Globals["rect"] = typeof(Rect);
        script.Globals["color"] = typeof(Color);
    }
}