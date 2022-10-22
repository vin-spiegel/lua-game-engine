using System.Diagnostics.CodeAnalysis;
using GameEngineDemo2.Core.Graphics;
using GameEngineDemo2.Core.Lua;
using MoonSharp.Interpreter;
using Task = GameEngineDemo2.Core.Lua.Task;

namespace GameEngineDemo2.Core;

public static class LuaScript
{
    private static readonly string ScriptDirectory = Path.GetFullPath(@"..\..\..\Sample\Scripts\");
    private static readonly Script Script = new Script();

    private static void SetCustomOptions()
    {
#pragma warning disable CS0618
        Script.GlobalOptions.CustomConverters.SetClrToScriptCustomConversion<Task<DynValue>>(
#pragma warning restore CS0618
            Wait.Execute
        );
    }

    public static void Init()
    {
        SetCustomOptions();
        RegisterType();
        LoadApiFunction();
        
        var res = Script.LoadFile(ScriptDirectory + "main.lua");
        res?.CallAsync();
    }
    
    private static void RegisterType()
    {
        //Core Module
        UserData.RegisterType<Window>();
        UserData.RegisterType<Task>();
        UserData.RegisterType<Vector>();
        UserData.RegisterType<Wait>();
        UserData.RegisterType<Rect>();
        UserData.RegisterType<Color>();
    }

    private static void LoadApiFunction()
    {
        Script.Globals["wait"] = typeof(Wait);
        Script.Globals["window"] = typeof(Window);
        Script.Globals["point"] = typeof(Vector);
        Script.Globals["rect"] = typeof(Rect);
        Script.Globals["color"] = typeof(Color);
    }
}