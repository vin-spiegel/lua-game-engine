using MoonSharp.Interpreter;
using SFML.Graphics.Glsl;
using SFML.System;
// ReSharper disable MemberCanBePrivate.Global
// ReSharper disable InconsistentNaming
#pragma warning disable CS0660, CS0661

namespace GameEngineDemo2.Core.System;

[MoonSharpUserData]
public class Vector2
{
    #region Ctor

    /// <summary xml:lang="en">
    /// Make Vector2 Struct
    /// </summary>
    public Vector2(float x, float y)
    {
        this.x = x;
        this.y = y;
    }

    #endregion
    
    
    #region MetaMethods

    /// <exclude/>
    [MoonSharpUserDataMetamethod("__call")]
    public static Vector2 __call(object self, float x, float y)
    {
        return new Vector2(x, y);
    }
    
    /// <exclude/>
    [MoonSharpUserDataMetamethod("__tostring")]
    public static string __tostring(Vector2 self)
    {
        return $"{self!.x}\t{self.y}";
    }

    #endregion
    
    
    #region Props
    
    public float x { get; set; }
    public float y { get; set; }
    
    #endregion
    
    
    #region Static Props

    public static Vector2 one => new Vector2(1, 1); 
    public static Vector2 right => new Vector2(1, 0); 
    public static Vector2 up => new Vector2(0, 1); 
    public static Vector2 left => new Vector2(-1, 0); 
    public static Vector2 zero => new Vector2(0, 0);
    
    #endregion

    
    #region Static Methods

    /// <summary>
    /// Returns the distance between `a` and `b`.
    /// </summary>
    /// <param name="a">Point 1</param>
    /// <param name="b">Point 2</param>
    public static float distance(Vector2 a, Vector2 b)
    {
        var x = b.x - a.x;
        var y = b.y - a.y;
        return (float)Math.Sqrt(x * x + y * y);
    }

    #endregion

    
    #region Operaters
    
    public static Vector2 operator +(Vector2 a, Vector2 b) => new Vector2(a.x + b.x, a.y + b.y);
    public static Vector2 operator -(Vector2 a, Vector2 b) => new Vector2(a.x - b.x, a.y - b.y);
    public static Vector2 operator *(Vector2 a, Vector2 b) => new Vector2(a.x * b.x, a.y * b.y);
    public static Vector2 operator /(Vector2 a, Vector2 b) => new Vector2(a.x / b.x, a.y / b.y);
    public static bool operator ==(Vector2 a, Vector2 b) => a.x == b.x && a.y == b.y;
    public static bool operator !=(Vector2 a, Vector2 b) => a.x != b.x || a.y != b.y;
    
    #endregion

    
    #region Caster

    [MoonSharpHidden]
    public static implicit operator Vector2(Vector2u vec) => new Vector2(vec.X, vec.Y);
    [MoonSharpHidden]
    public static implicit operator Vector2u(Vector2 vector2) => new Vector2u((uint)vector2.x, (uint)vector2.y);
    [MoonSharpHidden]
    public static implicit operator Vector2(Vec2 vec) => new Vector2(vec.X, vec.Y);
    [MoonSharpHidden]
    public static implicit operator Vec2(Vector2 vector2) => new Vec2(vector2.x, vector2.y);

    #endregion
}