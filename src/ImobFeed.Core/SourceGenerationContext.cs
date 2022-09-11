using System.Text.Json.Serialization;
using ImobFeed.Core.Analise;
using ImobFeed.Core.CarteiraMensal;
using ImobFeed.Core.Exportadores;

namespace ImobFeed.Core;

[JsonSourceGenerationOptions(PropertyNamingPolicy = JsonKnownNamingPolicy.CamelCase)]
[JsonSerializable(typeof(ArquivoCarteira))]
[JsonSerializable(typeof(IndiceRaiz))]
[JsonSerializable(typeof(IndiceAno))]
[JsonSerializable(typeof(IndiceMes))]
[JsonSerializable(typeof(IndiceCorretora))]
internal partial class SourceGenerationContext : JsonSerializerContext
{
}