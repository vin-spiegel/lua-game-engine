using GameEngineDemo2.Core;
using MoonSharp.Interpreter;
using SFML.Graphics;
using SFML.System;
using SFML.Window;

// if (args.Length == 0)
//     return;

// Game.Path = args[1];

LuaScript.Init();

var clock = new Clock();

GameWindow.load?.Call();

// GameWindow.Init(GameWindow.height,GameWindow.width, GameWindow.title);
GameWindow.Init(800,480,"Test Game");

while (GameWindow.IsOpen)
{
    // update
    var dt = clock.Restart();
    GameWindow.update?.Call(dt.AsSeconds());
    
    // handle events
    GameWindow.HandleEvents();
    GameWindow.Clear();
    
    // draw
    
    // display
    GameWindow.Display();
}
