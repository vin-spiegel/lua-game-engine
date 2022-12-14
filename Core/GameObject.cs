// ReSharper disable ClassNeverInstantiated.Global

using GameEngineDemo2.Core.Serialization;
using MoonSharp.Interpreter;
// ReSharper disable All
#pragma warning disable CS0649
#pragma warning disable CS8618

namespace GameEngineDemo2.Core;

/// <summary>
/// A game entity is an object that interacts with the game and responds to player input or other entities.
/// Other terms for entity are actor, or game object.
/// </summary>
[MoonSharpUserData]
public class GameObject
{
    #region Ctor

    private GameObject(string name) : this()
    {
        this.name = name;
    }

    private GameObject()
    {
        Game.Add(this);
    }

    #endregion
    
    [MoonSharpUserDataMetamethod("__call")]
    public static GameObject __call(object self)
    {
        return new GameObject();
    }
    
    [MoonSharpUserDataMetamethod("__pairs")]
    public static DynValue __pairs(object self)
    {
        var table = Converter.DynValueSerialize(self);

        var next = Utility.GetGlobal("next") as CallbackFunction;

        return DynValue.NewTuple(DynValue.NewCallback(next), table);
    }

    #region Props

    public EventPublisher start = new EventPublisher();
    
    public EventPublisher update = new EventPublisher();

    public string tag { get; set; } = "test1";
    
    public string name { get; set; }

    #endregion
}