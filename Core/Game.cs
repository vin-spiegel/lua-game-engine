using GameEngineDemo2.Core.Serialization;
using GameEngineDemo2.Core.System;
using MoonSharp.Interpreter;
using SFML.Graphics;
using SFML.System;
using SFML.Window;
// ReSharper disable All
#pragma warning disable CS8618

namespace GameEngineDemo2.Core;

[MoonSharpUserData]
public class Game 
{
    private static RenderWindow? _window;
    private static string _title = "My Game";
    private static HashSet<GameObject> _entities = new HashSet<GameObject>();
    
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
    
    private static void Start()
    {
        foreach (var entity in _entities)
        {
            start.call();
            entity.start.call();
        }
    }
    
    private static void Update(double dt)
    {
        foreach (var entity in _entities)
        {
            update.call(dt);
            entity.update.call(dt);
        }
    }
    
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

    public static void Draw() 
    {
        // window.Draw();
    }

    public static void Add(GameObject gameObject)
    {
        _entities.Add(gameObject);
    }

    public static void Remove(GameObject gameObject)
    {
        _entities.Remove(gameObject);
    }
    public static void Run()
    {
        var clock = new Clock();
        Start();
        
        while (_window != null && _window.IsOpen)
        {
            // update
            var dt = clock.Restart().AsSeconds();
            Update(dt);

            // handle events
            Game.HandleEvents();
            Game.Clear();
    
            // draw
    
            // display
            Game.Display();
        }
    }
    
    private static void Display()
    {
        _window?.Display();
    }

    private static void HandleEvents()
    {
        _window?.DispatchEvents();
    }
    
    private static void Clear()
    {
        _window?.Clear();
    }

    public static void save()
    {
        foreach (var gameObject in _entities)
        {
            var jsonString = Converter.JsonSerialize(gameObject);
            IO.File.WriteAllText(jsonString, gameObject.name + ".json");
        }
    }

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
    
    public static Vector2 size
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

    public static EventPublisher start { get; set; } =  new EventPublisher();
    
    public static EventPublisher update { get; set; } =  new EventPublisher();

    public static GameObject[] entities => _entities.ToArray();
    
    #endregion
    
}
