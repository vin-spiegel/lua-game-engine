// ReSharper disable ClassNeverInstantiated.Global
using MoonSharp.Interpreter;
// ReSharper disable All

namespace GameEngineDemo2.Core;

/// <summary>
/// A game entity is an object that interacts with the game and responds to player input or other entities.
/// Other terms for entity are actor, or game object.
/// </summary>
[MoonSharpUserData]
public class Entity
{
    private Entity()
    {
        Game.Add(this);
    }
    
    [MoonSharpUserDataMetamethod("__call")]
    public static Entity __call(object self)
    {
        return new Entity();
    }

    #region Props

    public EventPublisher start = new EventPublisher();
    
    public EventPublisher update = new EventPublisher();

    #endregion
}