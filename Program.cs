using GameEngineDemo2.Core;
using MoonSharp.Interpreter;
using SFML.Graphics;
using SFML.System;
using SFML.Window;
using Window = GameEngineDemo2.Core.Window;

// if (args.Length == 0)
//     return;

// Game.Path = args[1];

LuaScript.Init();

var clock = new Clock();

Window.load?.Call();

// GameWindow.Init(GameWindow.height,GameWindow.width, GameWindow.title);
Window.Init(800,480,"Test Game");

while (Window.IsOpen)
{
    // update
    var dt = clock.Restart();
    Window.update?.Call(dt.AsSeconds());
    
    // handle events
    Window.HandleEvents();
    Window.Clear();
    
    // draw
    
    // display
    Window.Display();
}
