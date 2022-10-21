using System.Diagnostics.CodeAnalysis;
using MoonSharp.Interpreter;
// ReSharper disable UnusedAutoPropertyAccessor.Global

namespace GameEngineDemo2.Core;

[SuppressMessage("ReSharper", "InconsistentNaming")]
[SuppressMessage("ReSharper", "MemberCanBePrivate.Global")]
public struct Rect
{
    public float x { get; set; }
    public float y { get; set; }
    public float width { get; set; }
    public float height { get; set; }
    public float max { get; set; }
    public float min { get; set; }

    private Rect(float x, float y, float width, float height)
    {
        this.x = x;
        this.y = y;
        this.width = width;
        this.height = height;
        this.max = 1;
        this.min = 0;
    }
    
    /// <exclude/>
    [MoonSharpUserDataMetamethod("__call")]
    public static Rect __call(object self, float x, float y, float width, float height)
    {
        return new Rect(x, y, width, height);
    }
}