using System.Text.Json;

namespace Thanos.Frame.Serialization.Extensions;

public static class Extensions
{
    public static T Deserialize<T> (
        this string json,
        JsonSerializerOptions options = null
    ){
        return JsonSerializer.Deserialize<T>(json, options ?? DefaultOptions.DEFINITION);
    }

    public static string Serialize<T> (
        this T poco,
        JsonSerializerOptions options = null
    ){
        return JsonSerializer.Serialize(poco, options ?? DefaultOptions.DEFINITION);
    }
}
