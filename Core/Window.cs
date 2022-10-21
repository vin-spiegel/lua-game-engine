using MoonSharp.Interpreter;
using SFML.Graphics;
using SFML.Graphics.Glsl;
using SFML.System;
using SFML.Window;
// ReSharper disable All
#pragma warning disable CS8618

namespace GameEngineDemo2.Core;

[MoonSharpUserData]
public class Window 
{
    private static RenderWindow? _window;
    private static string _title = "My Game";

    #region Ctor

    public static void Init(uint width, uint height, string title)
    {
        _window = new RenderWindow(new VideoMode(width, height), title);
        _window.Closed += (sender, args) =>
        {
            _window.Close();
        };
        _window.SetVerticalSyncEnabled(true);
    }

    #endregion
    
    
    #region Cycle
    
    public static Closure load { get; set; }
    public static Closure update { get; set; }

    #endregion

    
    #region Props

    public static uint width
    {
        get => _window!.Size.X;
        set => _window!.Size = new Vector2u(value, height);
    }
    
    public static uint height
    {
        get => _window!.Size.X;
        set => _window!.Size = new Vector2u(width, value);
    }
    
    public static Vector size
    {
        get => _window!.Size;
        set => _window!.Size = value;
    }

    public static string title
    {
        get => _title;
        set
        {
            _title = value;
            _window!.SetTitle(value);
        }
    }

    #endregion


    #region Hidden Props

    [MoonSharpHidden]
    public static bool IsClosed => _window is { IsOpen: true };

    [MoonSharpHidden]
    public static bool IsOpen => _window is { IsOpen: true };

    #endregion


    #region Methods

    public static void close()
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

    #endregion
    
}
