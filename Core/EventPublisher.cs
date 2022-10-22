using MoonSharp.Interpreter;
// ReSharper disable UnusedMember.Global
// ReSharper disable InconsistentNaming

namespace GameEngineDemo2.Core;

[MoonSharpUserData]
public class EventPublisher
{
    private readonly HashSet<Closure> _hashSet = new HashSet<Closure>();

    #region Metamethods

    [MoonSharpUserDataMetamethod("__len")]
    public static int __len(EventPublisher self)
    {
        return self.count();
    }

    #endregion

    #region Methods

    public void add(Closure c)
    {
        _hashSet.Add(c);
    }

    public void remove(Closure c)
    {
        _hashSet.Remove(c);
    }
    
    public void call(params object[] args)
    {
        foreach(var c in _hashSet)
        {
            c.Call(args);
        }
    }
    
    public void clear() => _hashSet.Clear();

    private int count() => _hashSet.Count;

    #endregion
    
}