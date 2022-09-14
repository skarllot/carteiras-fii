using System.Text.Json;
using System.Text.Json.Serialization;

namespace ImobFeed.Core.CarteiraMensal;

public sealed class DateOnlyConverter : JsonConverter<DateOnly?>
{
    private const string DefaultFormat = "yyyy-MM-dd";

    public override DateOnly? Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options)
    {
        string? value = reader.GetString();
        return value is not null ? DateOnly.ParseExact(value, DefaultFormat) : null;
    }

    public override void Write(
        Utf8JsonWriter writer,
        DateOnly? value,
        JsonSerializerOptions options)
    {
        writer.WriteStringValue(value?.ToString(DefaultFormat));
    }
}