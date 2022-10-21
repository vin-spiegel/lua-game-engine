using System.Diagnostics.CodeAnalysis;
using GameEngineDemo2.Core.Lua;
using MoonSharp.Interpreter;
using Task = GameEngineDemo2.Core.Lua.Task;

namespace GameEngineDemo2.Core;

[SuppressMessage("ReSharper", "FieldCanBeMadeReadOnly.Local")]
public static class LuaScript
{
    private static readonly string ScriptDirectory = Path.GetFullPath(@"..\..\..\Sample\Scripts\");
    private static Script _script = new Script();

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
        
        var res = _script.LoadFile(ScriptDirectory + "main.lua");
        res?.CallAsync();
    }
    
    private static void RegisterType()
    {
        UserData.RegisterType<GameWindow>();
        UserData.RegisterType<Task>();
        UserData.RegisterType<Point>();
        UserData.RegisterType<Wait>();
    }

    private static void LoadApiFunction()
    {
        _script.Globals["wait"] = typeof(Wait);
        _script.Globals["window"] = typeof(GameWindow);
        _script.Globals["point"] = typeof(Point);
    }
}