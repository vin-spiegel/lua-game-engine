// ReSharper disable ClassNeverInstantiated.Global

using GameEngineDemo2.Core.System;
using MoonSharp.Interpreter;
// ReSharper disable All
#pragma warning disable CS8618

namespace GameEngineDemo2.Core;

/// <summary>
/// A game entity is an object that interacts with the game and responds to player input or other entities.
/// Other terms for entity are actor, or game object.
/// </summary>
[MoonSharpUserData]
public class Entity
{
    #region Ctor

    private Entity(string name) : this()
    {
        this.name = name;
    }

    private Entity()
    {
        Game.Add(this);
    }

    #endregion
    
    [MoonSharpUserDataMetamethod("__call")]
    public static Entity __call(object self)
    {
        return new Entity();
    }

    #region Props

    public EventPublisher start = new EventPublisher();
    
    public EventPublisher update = new EventPublisher();

    public Vector2 position { get; set; }
    
    public string name { get; set; }

    public string tag { get; set; }

    #endregion
}