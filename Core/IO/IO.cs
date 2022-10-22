// ReSharper disable InconsistentNaming
using Newtonsoft.Json;

namespace GameEngineDemo2.Core.IO;

/// <summary>
/// Contains types that allow reading and writing to files.
/// Serialize, Deserialize Game Objects support
/// </summary>
public static class IO
{
    #region Methods
    
    public static void Serialize(object obj, string filename)
    {
        var output = JsonConvert.SerializeObject(obj, Formatting.Indented);
        WriteAllText(output, filename);
    }

    public static T? Deserialize<T>(string filename)
    {
        return JsonConvert.DeserializeObject<T>(ReadAllText(filename), new JsonSerializerSettings()
        {
            Formatting = Formatting.Indented
        });
    }
    
    #endregion
    
    
    #region Private Methods & System.IO Wrapper

    private static void WriteAllText(string text, string filename)
    {
        var file = File.CreateText(filename);
        file.WriteLine(text);
        file.Close();
    }

    private static string ReadAllText(string filename)
    {
        return File.ReadAllText(filename);
    }

    #endregion
}