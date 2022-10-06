using System.IO.Abstractions;
using System.Text.Json;
using ImobFeed.Core;
using ImobFeed.Core.Referencia;

namespace ImobFeed.Api.Referencia;

public class EscritorListaAtivosIndicadores
{
    private readonly IAppConfiguration _appConfig;
    private readonly IFileSystem _fileSystem;
    private readonly IFonteReferenciaAtivos _fonteReferenciaAtivos;

    public EscritorListaAtivosIndicadores(
        IAppConfiguration appConfig,
        IFileSystem fileSystem,
        IFonteReferenciaAtivos fonteReferenciaAtivos)
    {
        _appConfig = appConfig;
        _fileSystem = fileSystem;
        _fonteReferenciaAtivos = fonteReferenciaAtivos;
    }

    public void Explorar(IProgress<ArquivoCriado> progress)
    {
        var apiDirectory = _appConfig.GetApiDirectory();

        var (listaAtivos, listaIndicadores) = _fonteReferenciaAtivos.BuscarEAgregar();

        string path = _fileSystem.Path.Combine(apiDirectory.FullName, "lista-ativos.json");
        using (var stream = _fileSystem.File.Open(path, FileMode.Create, FileAccess.Write))
        {
            JsonSerializer.Serialize(stream, listaAtivos, SourceGenerationContext.Default.Options);
            stream.Flush();
            progress.Report(new ArquivoCriado(path));
        }

        path = _fileSystem.Path.Combine(apiDirectory.FullName, "lista-indicadores.json");
        using (var stream = _fileSystem.File.Open(path, FileMode.Create, FileAccess.Write))
        {
            JsonSerializer.Serialize(stream, listaIndicadores, SourceGenerationContext.Default.Options);
            stream.Flush();
            progress.Report(new ArquivoCriado(path));
        }
    }
}