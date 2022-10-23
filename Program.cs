using GameEngineDemo2.Core;
using SFML.System;
using Window = GameEngineDemo2.Core.Graphics.Window;

// if (args.Length == 0)
//     return;

// Game.Path = args[1];

LuaScript.Init();


Window.load?.Call();

Window.Init(100,100,"Test Game");

var clock = new Clock();

while (Window.IsOpen)
{
    // update
    var dt = clock.Restart().AsSeconds();
    Window.update?.Call(dt);
    
    // handle events
    Window.HandleEvents();
    Window.Clear();
    
    // draw
    
    // display
    Window.Display();
}
