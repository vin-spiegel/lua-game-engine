using GameEngineDemo2.Core.Graphics;
using GameEngineDemo2.Core.Lua;
using GameEngineDemo2.Core.System;
using MoonSharp.Interpreter;
using MoonSharp.Interpreter.Loaders;
using Task = GameEngineDemo2.Core.Lua.Task;
// ReSharper disable InconsistentNaming

namespace GameEngineDemo2.Core;

public static class LuaScript
{
    private static readonly string ScriptDirectory = Path.GetFullPath(@"..\..\..\Sample\Scripts\");
    private static readonly Script script = new Script();

    private static void SetCustomOptions()
    {
        // conversion task to wait model
#pragma warning disable CS0618
        Script.GlobalOptions.CustomConverters.SetClrToScriptCustomConversion<Task<DynValue>>(
#pragma warning restore CS0618
            Wait.Execute
        );
        
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
        RegisterType();
        LoadApiFunction();
        
        var res = script.LoadFile(ScriptDirectory + "main.lua");
        res?.CallAsync();
    }
    
    private static void RegisterType()
    {
        // lua core module
        UserData.RegisterType<Task>();
        UserData.RegisterType<Wait>();
        
        // core module
        UserData.RegisterType<Window>();
        UserData.RegisterType<Vector>();
        UserData.RegisterType<Rect>();
        UserData.RegisterType<Color>();
    }

    private static void LoadApiFunction()
    {
        // lua core module
        script.Globals["wait"] = typeof(Wait);
        
        // core module
        script.Globals["window"] = typeof(Window);
        script.Globals["point"] = typeof(Vector);
        script.Globals["rect"] = typeof(Rect);
        script.Globals["color"] = typeof(Color);
    }
}