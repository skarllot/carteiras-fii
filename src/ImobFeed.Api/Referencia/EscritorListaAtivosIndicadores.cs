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
        var now = DateTimeOffset.UtcNow;

        var refDirectory = _appConfig.GetApiDirectory()
            .CreateSubdirectory("referencia");

        var indDirectory = refDirectory
            .CreateSubdirectory(now.Year.ToString());

        var (listaAtivos, listaIndicadores) = _fonteReferenciaAtivos.BuscarEAgregar();

        string path = _fileSystem.Path.Combine(refDirectory.FullName, "lista-ativos.json");
        using (var stream = _fileSystem.File.Open(path, FileMode.Create, FileAccess.Write))
        {
            JsonSerializer.Serialize(stream, listaAtivos, SourceGenerationContext.Default.Options);
            stream.Flush();
            progress.Report(new ArquivoCriado(path));
        }

        path = _fileSystem.Path.Combine(indDirectory.FullName, $"{now.Month:00}-lista-indicadores.json");
        using (var stream = _fileSystem.File.Open(path, FileMode.Create, FileAccess.Write))
        {
            JsonSerializer.Serialize(stream, listaIndicadores, SourceGenerationContext.Default.Options);
            stream.Flush();
            progress.Report(new ArquivoCriado(path));
        }
    }
}