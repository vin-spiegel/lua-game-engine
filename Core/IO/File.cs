// ReSharper disable InconsistentNaming

namespace GameEngineDemo2.Core.IO;

/// <summary>
/// Contains types that allow reading and writing to files.
/// Serialize, Deserialize Game Objects support
/// </summary>
public static class File
{
    
    #region System.IO Wrapper

    public static void WriteAllText(string text, string filename)
    {
        var file = global::System.IO.File.CreateText(Project.Root + filename);
        file.WriteLine(text);
        file.Close();
    }

    public static string ReadAllText(string filename)
    {
        return global::System.IO.File.ReadAllText(filename);
    }

    #endregion
}