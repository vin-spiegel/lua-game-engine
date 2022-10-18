using GameEngineDemo2.Core;
using MoonSharp.Interpreter;
using SFML.Graphics;
using SFML.System;
using SFML.Window;

// if (args.Length == 0)
//     return;

// Game.Path = args[1];


LuaAPI.LoadInitScript();

var clock = new Clock();
GameWindow.Init(800,600,"ddd");
while (GameWindow.IsOpen)
{
    var dt = clock.Restart();
    GameWindow.Update?.Call(dt.AsSeconds());
    
    GameWindow.HandleEvents();
    GameWindow.Clear();
    
    GameWindow.Display();
}
