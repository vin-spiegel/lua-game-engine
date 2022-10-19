using MoonSharp.Interpreter;

namespace GameEngineDemo2.Core;

public static class LuaAPI
{
    private static readonly string ScriptDirectory = Path.GetFullPath(@"..\..\..\Sample\Scripts\");
    private static Script _script = new Script();

    public static void LoadInitScript()
    {
        RegisterType();
        LoadApiFunction();
        _script.DoFile(ScriptDirectory + "main.lua");
    }

    private static void RegisterType()
    {
        UserData.RegisterType<GameWindow>();
        UserData.RegisterType<Point>();
    }

    static void LoadApiFunction()
    {
        _script.Globals["window"] = typeof(GameWindow);
        _script.Globals["loadScript"] = (Action<string>)LoadScript;
        _script.Globals["point"] = (Func<float,float,Point>)Point.New;
    }
    
    public static void LoadScript(string fileName)
    {
        _script.DoFile(fileName);
    }

}