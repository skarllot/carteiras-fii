using System.Text.Json;
using System.Text.Json.Serialization;

namespace ImobFeed.Core.CarteiraMensal;

public sealed class PercentualJsonConverter : JsonConverter<Percentual>
{
    public override Percentual Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options) =>
        new(reader.GetDecimal());

    public override void Write(
        Utf8JsonWriter writer,
        Percentual value,
        JsonSerializerOptions options) =>
        writer.WriteNumberValue(value.Valor);
}