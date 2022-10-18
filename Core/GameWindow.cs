using MoonSharp.Interpreter;
using SFML.Graphics;
using SFML.Graphics.Glsl;
using SFML.System;
using SFML.Window;

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

[MoonSharpUserData]
public class GameClosure
{
    private Action _closure;

    public GameClosure()
    {
        
    }
}

[MoonSharpUserData]
public class GameWindow
{
    private static RenderWindow? _window;
    
    public static bool IsClosed => _window is { IsOpen: true };

    public static bool IsOpen => _window is { IsOpen: true };
    
    public static void Init(uint width, uint height, string title)
    {
        _window = new RenderWindow(new VideoMode(width, height), title);
        _window.Closed += (sender, args) =>
        {
            _window.Close();
        };
        _window.SetVerticalSyncEnabled(true);
    }

    // ReSharper disable once InconsistentNaming
    public static Point size
    {
        get => _window!.Size;
        set => _window!.Size = value;
    }

    public static void Close()
    {
        _window?.Close();
    }

    public static void SetFrameLimit(uint fps)
    {
        _window?.SetFramerateLimit(fps);
    }

    public static void Display()
    {
        _window?.Display();
    }

    public static void HandleEvents()
    {
        _window?.DispatchEvents();
    }

    public static GameClosure update { get; set; }

    public static void Clear()
    {
        _window?.Clear();
    }

    public static void Draw() 
    {
        // window.Draw();
    }

}
