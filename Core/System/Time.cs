using MoonSharp.Interpreter;
using SFML.System;
// ReSharper disable All

namespace GameEngineDemo2.Core.System;

[MoonSharpUserData]
public static class Time
{
    private static Clock clock = new Clock();
    
    public static float deltaTime
    {
        get
        {
            var dt = clock.Restart().AsSeconds();
            return dt;
        }
    }
    
}