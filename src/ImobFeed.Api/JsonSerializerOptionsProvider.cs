using System.Text.Json;
using System.Text.Json.Serialization;
using ImobFeed.Core.CarteiraMensal;

namespace ImobFeed.Api;

public static class JsonSerializerOptionsProvider
{
    public static JsonSerializerOptions Default { get; } = Create();

    private static JsonSerializerOptions Create()
    {
        return new JsonSerializerOptions(JsonSerializerDefaults.Web)
        {
            Converters = { new JsonStringEnumConverter(), new DateOnlyConverter(), new PercentualJsonConverter() }
        };
    }
}