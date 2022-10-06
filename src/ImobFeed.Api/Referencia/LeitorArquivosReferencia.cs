using System.IO.Abstractions;
using System.Text.Json;
using ImobFeed.Core;
using ImobFeed.Core.CarteiraMensal;
using ImobFeed.Core.Referencia;
using ImobFeed.Core.Referencia.Modelos;

namespace ImobFeed.Api.Referencia;

public class LeitorArquivosReferencia : IReferenciaAtivos
{
    private readonly IFileSystem _fileSystem;
    private readonly IAppConfiguration _appConfig;

    public LeitorArquivosReferencia(IFileSystem fileSystem, IAppConfiguration appConfig)
    {
        _fileSystem = fileSystem;
        _appConfig = appConfig;
    }

    public IReadOnlyDictionary<string, Ativo> CarregarAtivos()
    {
        var apiDirectory = _appConfig.GetApiDirectory();
        string path = _fileSystem.Path.Combine(apiDirectory.FullName, "lista-ativos.json");
        using var stream = _fileSystem.File.OpenRead(path);
        var listaAtivos = JsonSerializer.Deserialize<ListaAtivos>(stream, SourceGenerationContext.Default.Options);

        return listaAtivos?.Ativos.ToDictionary(it => it.Codigo, StringComparer.OrdinalIgnoreCase)
               ?? new Dictionary<string, Ativo>();
    }

    public IReadOnlyDictionary<string, IndicadorAtivo> CarregarIndicadores()
    {
        var apiDirectory = _appConfig.GetApiDirectory();
        string path = _fileSystem.Path.Combine(apiDirectory.FullName, "lista-indicadores.json");
        using var stream = _fileSystem.File.OpenRead(path);
        var listaAtivos = JsonSerializer.Deserialize<ListaIndicadores>(stream, SourceGenerationContext.Default.Options);

        return listaAtivos?.Indicadores.ToDictionary(it => it.Codigo, StringComparer.OrdinalIgnoreCase)
               ?? new Dictionary<string, IndicadorAtivo>();
    }
}