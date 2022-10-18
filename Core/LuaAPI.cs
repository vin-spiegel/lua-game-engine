using MoonSharp.Interpreter;

namespace GameEngineDemo2.Core;

public static class LuaAPI
{
    private const string ScriptDirectory = @"C:\Projects\GameEngineDemo2\Example\Scripts\";
    private static Script _script = new Script();

    public static void LoadInitScript()
    {
        LoadApiFunction();
        _script.DoFile(ScriptDirectory + "main.lua");
    }
    
    public static void LoadScript(string fileName)
    {
        _script.DoFile(fileName);
    }
    
    static void LoadApiFunction()
    {
        UserData.RegisterType<GameWindow>();
        UserData.RegisterType<GameClosure>();
        UserData.RegisterType<Point>();
        
        _script.Globals["window"] = typeof(GameWindow);
        _script.Globals["loadScript"] = (Action<string>)LoadScript;
        _script.Globals["point"] = (Func<float,float,Point>)Point.New;
    }

}