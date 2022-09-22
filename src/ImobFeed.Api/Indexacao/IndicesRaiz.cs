using System.Collections.Immutable;
using System.IO.Abstractions;
using System.Text.Json;
using ImobFeed.Api.Indexacao.Modelos;
using ImobFeed.Core;

namespace ImobFeed.Api.Indexacao;

internal sealed class IndicesRaiz
{
    private readonly IFileSystem _fileSystem;
    private readonly IndicesAno _indicesAno;

    public IndicesRaiz(IFileSystem fileSystem)
    {
        _fileSystem = fileSystem;
        _indicesAno = new IndicesAno(fileSystem);
    }

    public void Criar(IDirectoryInfo baseDirectory, IProgress<ArquivoCriado> progress)
    {
        baseDirectory.EnumerateDirectories()
            .Where(FiltrosIndexacao.DiretoriosAno)
            .Pipe(
                it => CriarIndicesAno(it, progress),
                it => CriarIndiceRaiz(it, baseDirectory, progress));
    }

    private void CriarIndicesAno(IEnumerable<IDirectoryInfo> directories, IProgress<ArquivoCriado> progress)
    {
        foreach (var directory in directories)
        {
            _indicesAno.Criar(directory, progress);
        }
    }

    private void CriarIndiceRaiz(
        IEnumerable<IDirectoryInfo> directories,
        IDirectoryInfo baseDirectory,
        IProgress<ArquivoCriado> progress)
    {
        var indiceRaiz = new IndiceRaiz(
            Anos: directories
                .Select(it => it.Name)
                .ToImmutableArray(),
            Tops: baseDirectory.EnumerateFiles(FiltrosIndexacao.ArquivosAtivosTop, SearchOption.TopDirectoryOnly)
                .Select(it => new InfoTop(int.Parse(it.Name.AsSpan(0, 4)), int.Parse(it.Name.AsSpan(2, 2)), it.Name))
                .ToImmutableArray());

        string filePath = _fileSystem.Path.Join(baseDirectory.FullName, "index.json");
        using var fileStream = _fileSystem.File.Open(filePath, FileMode.Create, FileAccess.ReadWrite);
        JsonSerializer.Serialize(fileStream, indiceRaiz, SourceGenerationContext.Default.Options);
        fileStream.Flush();

        progress.Report(new ArquivoCriado(filePath));
    }
}