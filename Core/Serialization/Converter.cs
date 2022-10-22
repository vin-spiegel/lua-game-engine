using Newtonsoft.Json;

namespace GameEngineDemo2.Core.Serialization;

public static class Converter
{
    public static T? Deserialize<T>(string filename)
    {
        return JsonConvert.DeserializeObject<T>(File.ReadAllText(filename), new JsonSerializerSettings()
        {
            Formatting = Formatting.Indented
        });
    }
    
    public static string Serialize(object obj)
    {
        return JsonConvert.SerializeObject(obj, Formatting.Indented);
    }
}