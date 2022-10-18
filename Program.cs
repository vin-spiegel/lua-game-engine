using GameEngineDemo2.Core;
using SFML.Graphics;
using SFML.Window;

// if (args.Length == 0)
//     return;

// Game.Path = args[1];

LuaAPI.LoadInitScript();

while (GameWindow.IsOpen)
{
    GameWindow.HandleEvents();
    GameWindow.Clear();
    // GameWindow.Update();
    GameWindow.Display();
}
