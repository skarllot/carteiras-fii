using System.Text.Json.Serialization;
using ImobFeed.Core.Analise;
using ImobFeed.Core.Exportadores;

namespace ImobFeed.Core;

[JsonSourceGenerationOptions(PropertyNamingPolicy = JsonKnownNamingPolicy.CamelCase)]
[JsonSerializable(typeof(ArquivoCarteira))]
[JsonSerializable(typeof(IndiceRaiz))]
[JsonSerializable(typeof(IndiceAno))]
[JsonSerializable(typeof(IndiceMes))]
[JsonSerializable(typeof(IndiceCorretora))]
[JsonSerializable(typeof(ListaTopIndicacoes))]
[JsonSerializable(typeof(ListaIndicacoesFavoritas))]
internal partial class SourceGenerationContext : JsonSerializerContext
{
}