using System.Text.Json;
using System.Text.Json.Serialization;
using ImobFeed.Api.Indexacao.Modelos;
using ImobFeed.Core.Analise.Modelos;
using ImobFeed.Core.CarteiraMensal;
using ImobFeed.Core.Recomendacoes.Modelos;
using ImobFeed.Core.Referencia.Modelos;

namespace ImobFeed.Api;

[JsonSourceGenerationOptions(PropertyNamingPolicy = JsonKnownNamingPolicy.CamelCase)]
[JsonSerializable(typeof(ArquivoCarteira))]
[JsonSerializable(typeof(IndiceRaiz))]
[JsonSerializable(typeof(IndiceAno))]
[JsonSerializable(typeof(IndiceMes))]
[JsonSerializable(typeof(IndiceCorretora))]
[JsonSerializable(typeof(ListaIndicacoesFavoritas))]
[JsonSerializable(typeof(ListaAtivos))]
[JsonSerializable(typeof(ListaIndicadores))]
[JsonSerializable(typeof(ListaAtivosDiff))]
public partial class SourceGenerationContext : JsonSerializerContext
{
    private static SourceGenerationContext? defaultContextWithConverters;

    public static SourceGenerationContext DefaultWithConverters =>
        defaultContextWithConverters ??= CreateContextWithConverters();

    private static SourceGenerationContext CreateContextWithConverters()
    {
        return new SourceGenerationContext(
            new JsonSerializerOptions(s_defaultOptions)
            {
                Converters = { new JsonStringEnumConverter(), new DateOnlyConverter(), new PercentualJsonConverter() }
            });
    }
}