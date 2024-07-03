using System.Text.Json;
using System.Text.Json.Serialization;

namespace Thanos.Frame.Serialization;

public class DateTimeConverter : JsonConverter<DateTime>
{
    public override DateTime Read (
        ref Utf8JsonReader reader,
        Type typeConverter,
        JsonSerializerOptions options
    ){
        return DateTime.Parse(reader.GetString(), null, System.Globalization.DateTimeStyles.AssumeUniversal);
    }

    public override void Write (
        Utf8JsonWriter writer,
        DateTime value,
        JsonSerializerOptions options
    ){
        writer.WriteStringValue(value.ToString("yyyy-MM-ddTHH:mm:ssZ"));
    }
}
