using GameEngineDemo2.Core;
using SFML.System;

// if (args.Length == 0)
//     return;

// Game.Path = args[1];

LuaScript.Init();

Game.Init(200,100,"Test Game");

Game.Run();
