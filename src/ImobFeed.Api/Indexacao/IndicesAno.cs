using System.Collections.Immutable;
using System.IO.Abstractions;
using System.Text.Json;
using ImobFeed.Api.Indexacao.Modelos;
using ImobFeed.Core;

namespace ImobFeed.Api.Indexacao;

public sealed class IndicesAno
{
    private readonly IFileSystem _fileSystem;
    private readonly IndicesMes _indicesMes;

    public IndicesAno(IFileSystem fileSystem, IndicesMes indicesMes)
    {
        _fileSystem = fileSystem;
        _indicesMes = indicesMes;
    }

    public void Criar(IDirectoryInfo directoryInfo, IProgress<ArquivoCriado> progress)
    {
        directoryInfo.EnumerateDirectories()
            .Where(FiltrosIndexacao.DiretoriosMes)
            .Pipe(
                it => CriarIndicesMes(it, progress),
                it => CriarIndiceAno(it, directoryInfo, progress));
    }

    private void CriarIndicesMes(IEnumerable<IDirectoryInfo> directories, IProgress<ArquivoCriado> progress)
    {
        foreach (var directory in directories)
        {
            _indicesMes.Criar(directory, progress);
        }
    }

    private void CriarIndiceAno(
        IEnumerable<IDirectoryInfo> directories,
        IDirectoryInfo baseDirectory,
        IProgress<ArquivoCriado> progress)
    {
        var indiceAno = new IndiceAno(
            Meses: directories.Select(it => it.Name).ToImmutableArray());

        string filePath = _fileSystem.Path.Join(baseDirectory.FullName, "index.json");
        using var fileStream = _fileSystem.File.Open(filePath, FileMode.Create, FileAccess.ReadWrite);
        JsonSerializer.Serialize(fileStream, indiceAno, SourceGenerationContext.Default.Options);
        fileStream.Flush();

        progress.Report(new ArquivoCriado(filePath));
    }
}