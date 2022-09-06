using System.Text.Json.Serialization;
using ImobFeed.Core.CarteiraMensal;

namespace ImobFeed.Core;

[JsonSourceGenerationOptions(PropertyNamingPolicy = JsonKnownNamingPolicy.CamelCase)]
[JsonSerializable(typeof(Percentual))]
internal partial class SourceGenerationContext : JsonSerializerContext
{
}