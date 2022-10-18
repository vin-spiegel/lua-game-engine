using MoonSharp.Interpreter;
using SFML.Graphics;
using SFML.Graphics.Glsl;
using SFML.System;
using SFML.Window;

namespace GameEngineDemo2.Core;

[MoonSharpUserData]
public class GameWindow 
{
    private static RenderWindow? _window;

    public static bool IsClosed => _window is { IsOpen: true };

    public static bool IsOpen => _window is { IsOpen: true };
    
    public static Closure Update { get; set; }
    
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
    
    public static void Clear()
    {
        _window?.Clear();
    }

    public static void Draw() 
    {
        // window.Draw();
    }
}
