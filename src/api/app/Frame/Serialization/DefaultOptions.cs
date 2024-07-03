using System.Text.Json;

namespace Thanos.Frame.Serialization;

public static class DefaultOptions
{
    public readonly static JsonSerializerOptions DEFINITION;

    static DefaultOptions()
    {
        DEFINITION = new JsonSerializerOptions {
            PropertyNameCaseInsensitive = true,
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase
        };

        DEFINITION.Converters.Add(new DateTimeConverter());
    }
}
