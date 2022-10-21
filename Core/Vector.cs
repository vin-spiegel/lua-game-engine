using System.Data;
using System.Diagnostics.CodeAnalysis;
using MoonSharp.Interpreter;
using SFML.Graphics.Glsl;
using SFML.System;
// ReSharper disable MemberCanBePrivate.Global
// ReSharper disable InconsistentNaming
#pragma warning disable CS0660, CS0661

namespace GameEngineDemo2.Core;

[MoonSharpUserData]
public class Vector
{
    #region Ctor

    /// <summary xml:lang="en">
    /// Make Vector2 Struct
    /// </summary>
    public Vector(float x, float y)
    {
        this.x = x;
        this.y = y;
    }

    #endregion
    
    
    #region MetaMethods

    /// <exclude/>
    [MoonSharpUserDataMetamethod("__call")]
    public static Vector __call(object self, float x, float y)
    {
        return new Vector(x, y);
    }
    
    /// <exclude/>
    [MoonSharpUserDataMetamethod("__tostring")]
    public static string __tostring(Vector self)
    {
        return $"{self!.x}\t{self.y}";
    }

    #endregion
    
    
    #region Props
    
    public float x { get; set; }
    public float y { get; set; }
    
    #endregion
    
    
    #region Static Props

    public static Vector one => new Vector(1, 1); 
    public static Vector right => new Vector(1, 0); 
    public static Vector up => new Vector(0, 1); 
    public static Vector left => new Vector(-1, 0); 
    public static Vector zero => new Vector(0, 0);
    
    #endregion

    
    #region Static Methods

    /// <summary>
    /// Returns the distance between `a` and `b`.
    /// </summary>
    /// <param name="a">Point 1</param>
    /// <param name="b">Point 2</param>
    public static float distance(Vector a, Vector b)
    {
        var x = b.x - a.x;
        var y = b.y - a.y;
        return (float)Math.Sqrt(x * x + y * y);
    }

    #endregion

    
    #region Operaters
    
    public static Vector operator +(Vector a, Vector b) => new Vector(a.x + b.x, a.y + b.y);
    public static Vector operator -(Vector a, Vector b) => new Vector(a.x - b.x, a.y - b.y);
    public static Vector operator *(Vector a, Vector b) => new Vector(a.x * b.x, a.y * b.y);
    public static Vector operator /(Vector a, Vector b) => new Vector(a.x / b.x, a.y / b.y);
    public static bool operator ==(Vector a, Vector b) => a.x == b.x && a.y == b.y;
    public static bool operator !=(Vector a, Vector b) => a.x != b.x || a.y != b.y;
    
    #endregion

    
    #region Caster

    [MoonSharpHidden]
    public static implicit operator Vector(Vector2u vec) => new Vector(vec.X, vec.Y);
    [MoonSharpHidden]
    public static implicit operator Vector2u(Vector vector) => new Vector2u((uint)vector.x, (uint)vector.y);
    [MoonSharpHidden]
    public static implicit operator Vector(Vec2 vec) => new Vector(vec.X, vec.Y);
    [MoonSharpHidden]
    public static implicit operator Vec2(Vector vector) => new Vec2(vector.x, vector.y);

    #endregion
}