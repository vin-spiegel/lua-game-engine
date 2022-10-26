namespace GameEngineDemo2.Core;

public static class Utility
{
    public static object GetGlobal(string key)
    {
        var script = LuaScript.script;
        return script.Globals[key];
    }
}