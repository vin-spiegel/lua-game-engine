using MoonSharp.Interpreter;
using SFML.Graphics.Glsl;
using SFML.System;

namespace GameEngineDemo2.Core;

[MoonSharpUserData]
public struct Point
{
    // ReSharper disable once MemberCanBePrivate.Global
    // ReSharper disable once InconsistentNaming
    public float x { get; set; }
    
    // ReSharper disable once MemberCanBePrivate.Global
    // ReSharper disable once InconsistentNaming
    public float y { get; set; }

    /// <summary>
    /// Vector2 Constructor
    /// </summary>
    public static Point New(float x, float y)
    {
        return new Point(x, y);
    }

    public static Point Zero => new Point(0, 0);

    [MoonSharpHidden]
    private Point(float x, float y)
    {
        this.x = x;
        this.y = y;
    }

    [MoonSharpHidden]
    public static implicit operator Point(Vector2u vec)
    {
        return new Point(vec.X, vec.Y);
    }
    
    [MoonSharpHidden]
    public static implicit operator Vector2u(Point point)
    {
        return new Vector2u((uint)point.x, (uint)point.y);
    }
    
    [MoonSharpHidden]
    public static implicit operator Point(Vec2 vec)
    {
        return new Point(vec.X, vec.Y);
    }
    
    [MoonSharpHidden]
    public static implicit operator Vec2(Point point)
    {
        return new Vec2(point.x, point.y);
    }
}