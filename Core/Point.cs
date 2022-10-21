using System.Diagnostics.CodeAnalysis;
using MoonSharp.Interpreter;
using SFML.Graphics.Glsl;
using SFML.System;

namespace GameEngineDemo2.Core;

[MoonSharpUserData]
[SuppressMessage("ReSharper", "InconsistentNaming")]
[SuppressMessage("ReSharper", "MemberCanBePrivate.Global")]
[SuppressMessage("ReSharper", "CompareOfFloatsByEqualityOperator")]
public struct Point
{
    #region Ctor

    /// <summary xml:lang="en">
    /// Make Vector2 Struct
    /// </summary>
    public static Point New(float x, float y) => new Point(x, y);

    [MoonSharpHidden]
    private Point(float x, float y)
    {
        this.x = x;
        this.y = y;
    }

    #endregion
    
    
    #region Props
    
    public float x { get; set; }
    
    public float y { get; set; }
    
    #endregion
    
    
    #region Static Props

    public static Point one => new Point(1, 1); 
    public static Point right => new Point(1, 0); 
    public static Point up => new Point(0, 1); 
    public static Point left => new Point(-1, 0); 
    public static Point zero => new Point(0, 0);
    
    #endregion

    #region Static Methods

    /// <summary>
    /// Returns the distance between `a` and `b`.
    /// </summary>
    /// <param name="a">Point 1</param>
    /// <param name="b">Point 2</param>
    public static float distance(Point a, Point b)
    {
        var x = b.x - a.x;
        var y = b.y - a.y;
        return (float)Math.Sqrt(x * x + y * y);
    }

    #endregion

    
    #region Operaters
    
    public static Point operator +(Point a, Point b) => new Point(a.x + b.x, a.y + b.y);
    public static Point operator -(Point a, Point b) => new Point(a.x - b.x, a.y - b.y);
    public static Point operator *(Point a, Point b) => new Point(a.x * b.x, a.y * b.y);
    public static Point operator /(Point a, Point b) => new Point(a.x / b.x, a.y / b.y);
    public static bool operator ==(Point a, Point b) => a.x == b.x && a.y == b.y;
    public static bool operator !=(Point a, Point b) => a.x != b.x || a.y != b.y;
    
    #endregion


    #region Implicit Operator

    [MoonSharpHidden]
    public static implicit operator Point(Vector2u vec) => new Point(vec.X, vec.Y);

    [MoonSharpHidden]
    public static implicit operator Vector2u(Point point) => new Vector2u((uint)point.x, (uint)point.y);

    [MoonSharpHidden]
    public static implicit operator Point(Vec2 vec) => new Point(vec.X, vec.Y);

    [MoonSharpHidden]
    public static implicit operator Vec2(Point point) => new Vec2(point.x, point.y);

    #endregion
}