// ReSharper disable ClassNeverInstantiated.Global
using MoonSharp.Interpreter;

namespace GameEngineDemo2.Core;

/// <summary>
/// A game entity is an object that interacts with the game and responds to player input or other entities.
/// Other terms for entity are actor, or game object.
/// </summary>
[MoonSharpUserData]
public class Entity
{
    public string test = "Test Entity";

    private Entity()
    {
        Window.Add(this);
    }
    
    /// <exclude/>
    [MoonSharpUserDataMetamethod("__call")]
    public static Entity __call(object self)
    {
        return new Entity();
    }
}