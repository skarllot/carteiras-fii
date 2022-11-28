using System.Collections.Immutable;
using System.Text.Json;
using ImobFeed.Core;
using ImobFeed.Core.CarteiraMensal;
using ImobFeed.Core.Referencia;
using ImobFeed.Core.Referencia.Modelos;
using NodaTime;

namespace ImobFeed.Api.Referencia;

public class LeitorArquivosReferencia : IReferenciaAtivos
{
    private readonly IAppConfiguration _appConfig;

    public LeitorArquivosReferencia(IAppConfiguration appConfig)
    {
        _appConfig = appConfig;
    }

    public ListaAtivos CarregarAtivos()
    {
        var arqAtivos = _appConfig.GetApiDirectory()
            .IrParaApiReferencia()
            .IrParaArquivoReferenciaAtivos();

        using var stream = arqAtivos.OpenRead();
        return JsonSerializer.Deserialize<ListaAtivos>(stream, SourceGenerationContext.Default.Options) ??
               new ListaAtivos(DateTimeOffset.MinValue, ImmutableArray<Ativo>.Empty);
    }

    public ListaIndicadores CarregarIndicadores(YearMonth data)
    {
        var arqIndicadores = _appConfig.GetApiDirectory()
            .IrParaApiReferencia(data.Year)
            .IrParaArquivoReferenciaIndicadores(data);

        using var stream = arqIndicadores.OpenRead();
        return JsonSerializer.Deserialize<ListaIndicadores>(stream, SourceGenerationContext.Default.Options) ??
               new ListaIndicadores(DateTimeOffset.MinValue, ImmutableArray<IndicadorAtivo>.Empty);
    }
}