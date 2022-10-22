using GameEngineDemo2.Core;
using GameEngineDemo2.Core.IO;
using GameEngineDemo2.Core.Serialization;
using SFML.Graphics;
using SFML.System;
using Color = GameEngineDemo2.Core.Graphics.Color;
using File = GameEngineDemo2.Core.IO.File;
using Window = GameEngineDemo2.Core.Graphics.Window;

// if (args.Length == 0)
//     return;

// Game.Path = args[1];

LuaScript.Init();

var clock = new Clock();

Window.load?.Call();

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
