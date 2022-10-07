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

    public IReadOnlyDictionary<string, Ativo> CarregarAtivos()
    {
        var arqAtivos = _appConfig.GetApiDirectory()
            .IrParaApiReferencia()
            .IrParaArquivoReferenciaAtivos();

        using var stream = arqAtivos.OpenRead();
        var listaAtivos = JsonSerializer.Deserialize<ListaAtivos>(stream, SourceGenerationContext.Default.Options);

        return listaAtivos?.Ativos.ToDictionary(it => it.Codigo, StringComparer.OrdinalIgnoreCase)
               ?? new Dictionary<string, Ativo>();
    }

    public IReadOnlyDictionary<string, IndicadorAtivo> CarregarIndicadores(YearMonth data)
    {
        var arqIndicadores = _appConfig.GetApiDirectory()
            .IrParaApiReferencia(data.Year)
            .IrParaArquivoReferenciaIndicadores(data);

        using var stream = arqIndicadores.OpenRead();
        var listaAtivos = JsonSerializer.Deserialize<ListaIndicadores>(stream, SourceGenerationContext.Default.Options);

        return listaAtivos?.Indicadores.ToDictionary(it => it.Codigo, StringComparer.OrdinalIgnoreCase)
               ?? new Dictionary<string, IndicadorAtivo>();
    }
}