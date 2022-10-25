using GameEngineDemo2.Core;
using SFML.System;
// using Window = GameEngineDemo2.Core.Graphics;

// if (args.Length == 0)
//     return;

// Game.Path = args[1];

LuaScript.Init();


Window.load?.Call();

Window.Init(200,100,"Test Game");

Window.Run();
