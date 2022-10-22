using MoonSharp.Interpreter;
// ReSharper disable InconsistentNaming
// ReSharper disable MemberCanBePrivate.Global
// ReSharper disable UnusedAutoPropertyAccessor.Global
// ReSharper disable IntroduceOptionalParameters.Local
#pragma warning disable CS0660, CS0661

namespace GameEngineDemo2.Core.Graphics;

/// <summary>
/// 
/// </summary>
public struct Color
{
    #region Ctor

    private Color(byte r, byte g, byte b) : this(r, g, b, 255) { }
    
    private Color(byte r, byte g, byte b, byte a)
    {
        this.r = r;
        this.g = g;
        this.b = b;
        this.a = a;
    }
    
    private Color(uint color)
    {
        unchecked
        {
            this.r = (byte)( color >> 24 );
            this.g = (byte)( color >> 16 );
            this.b = (byte)( color >> 8 );
            this.a = (byte)color;
        }
    }

    #endregion
    
    
    #region Meta Methods

    /// <exclude/>
    [MoonSharpUserDataMetamethod("__call")]
    public static Color __call(Color self, byte r, byte g, byte b, byte a)
    {
        return new Color(r, g, b, a);
    }
    
    /// <exclude/>
    [MoonSharpUserDataMetamethod("__call")]
    public static Color __call(Color self, byte r, byte g, byte b)
    {
        return new Color(r, g, b);
    }

    /// <exclude/>
    [MoonSharpUserDataMetamethod("__tostring")]
    public static string __tostring(Color self)
    {
        return $"[Color] R({self.r}) G({self.g}) B({self.b}) A({self.a})";
    }

    #endregion
    
    
    #region Props
    
    public byte r { get; set; }
    public byte g { get; set; }
    public byte b { get; set; }
    public byte a { get; set; }
    
    #endregion

    
    #region Static Props

    /// <summary>Predefined black color</summary>
    public static readonly Color black = new Color(0, 0, 0);

    /// <summary>Predefined white color</summary>
    public static readonly Color white = new Color(255, 255, 255);

    /// <summary>Predefined red color</summary>
    public static readonly Color red = new Color(255, 0, 0);

    /// <summary>Predefined green color</summary>
    public static readonly Color green = new Color(0, 255, 0);

    /// <summary>Predefined blue color</summary>
    public static readonly Color blue = new Color(0, 0, 255);

    /// <summary>Predefined yellow color</summary>
    public static readonly Color yellow = new Color(255, 255, 0);

    /// <summary>Predefined magenta color</summary>
    public static readonly Color magenta = new Color(255, 0, 255);

    /// <summary>Predefined cyan color</summary>
    public static readonly Color cyan = new Color(0, 255, 255);

    /// <summary>Predefined (black) transparent color</summary>
    public static readonly Color transparent = new Color(0, 0, 0, 0);

    #endregion

    
    #region Private Methods

    private bool Equals(Color other) => ( r == other.r ) && ( g == other.g ) && ( b == other.b ) && ( a == other.a );

    #endregion
    
    
    #region Operator Overloads

    public static bool operator ==(Color left, Color right) => left.Equals(right);
    
    public static bool operator !=(Color left, Color right) => !left.Equals(right);

    public static Color operator +(Color left, Color right)
    {
        return new Color((byte)Math.Min(left.r + right.r, 255),
            (byte)Math.Min(left.g + right.g, 255),
            (byte)Math.Min(left.b + right.b, 255),
            (byte)Math.Min(left.a + right.a, 255));
    }
    
    public static Color operator *(Color left, Color right)
    {
        return new Color((byte)( left.r * right.r / 255 ),
            (byte)( left.g * right.g / 255 ),
            (byte)( left.b * right.b / 255 ),
            (byte)( left.a * right.a / 255 ));
    }
    
    #endregion

    #region Caster

    public static implicit operator Color(SFML.Graphics.Color other)
    {
        return new Color(other.R, other.G, other.B, other.A);
    }
    
    public static implicit operator SFML.Graphics.Color(Color self)
    {
        return new SFML.Graphics.Color(self.r, self.g,self.b,self.a);
    }

    #endregion
}