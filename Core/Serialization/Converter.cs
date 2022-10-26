using MoonSharp.Interpreter;
using MoonSharp.Interpreter.Serialization;
using Newtonsoft.Json;

namespace GameEngineDemo2.Core.Serialization;

public static class Converter
{
    public static T? JsonDeserialize<T>(string filename)
    {
        return JsonConvert.DeserializeObject<T>(File.ReadAllText(filename), new JsonSerializerSettings()
        {
            Formatting = Formatting.Indented
        });
    }
    
    public static string JsonSerialize(object obj)
    {
        return JsonConvert.SerializeObject(obj, Formatting.Indented);
    }

    public static DynValue DynValueSerialize(object obj)
    {
        return ObjectValueConverter.SerializeObjectToDynValue(LuaScript.script, obj);
    }
}