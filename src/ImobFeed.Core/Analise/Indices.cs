using System.Collections.Immutable;
using System.IO.Abstractions;
using System.Text.Json;
using ImobFeed.Core.Exportadores;
using ImobFeed.Core.Leitores;

namespace ImobFeed.Core.Analise;

public class Indices
{
    private readonly IFileSystem _fileSystem;
    private readonly IDirectoryInfo _baseDirectory;

    public Indices(IFileSystem fileSystem, IDirectoryInfo baseDirectory)
    {
        _fileSystem = fileSystem;
        _baseDirectory = baseDirectory;
    }

    public void Criar(IProgress<IndiceCriado> progress)
    {
        CriarIndiceRaiz(progress);

        foreach (var directory in _baseDirectory.EnumerateDirectories())
        {
            CriarIndiceAno(directory, progress);
        }
    }

    private void CriarIndiceRaiz(IProgress<IndiceCriado> progress)
    {
        var indiceRaiz = new IndiceRaiz(
            Anos: _baseDirectory.EnumerateDirectories().Select(it => it.Name).ToImmutableArray());

        string filePath = _fileSystem.Path.Join(_baseDirectory.FullName, "index.json");
        using var fileStream = _fileSystem.File.Open(filePath, FileMode.Create, FileAccess.ReadWrite);
        JsonSerializer.Serialize(fileStream, indiceRaiz, SourceGenerationContext.Default.Options);
        fileStream.Flush();

        progress.Report(new IndiceCriado(filePath));
    }

    private void CriarIndiceAno(IDirectoryInfo directoryInfo, IProgress<IndiceCriado> progress)
    {
        foreach (var directory in directoryInfo.EnumerateDirectories())
        {
            CriarIndiceMes(directory, progress);
        }

        var indiceAno = new IndiceAno(
            Meses: directoryInfo.EnumerateDirectories().Select(it => it.Name).ToImmutableArray());

        string filePath = _fileSystem.Path.Join(directoryInfo.FullName, "index.json");
        using var fileStream = _fileSystem.File.Open(filePath, FileMode.Create, FileAccess.ReadWrite);
        JsonSerializer.Serialize(fileStream, indiceAno, SourceGenerationContext.Default.Options);
        fileStream.Flush();

        progress.Report(new IndiceCriado(filePath));
    }

    private void CriarIndiceMes(IDirectoryInfo directoryInfo, IProgress<IndiceCriado> progress)
    {
        foreach (var directory in directoryInfo.EnumerateDirectories())
        {
            CriarIndiceCorretora(directory, progress);
        }

        var indiceAno = new IndiceMes(
            Corretoras: directoryInfo.EnumerateDirectories()
                .Select(it => new InfoCorretora(ProvedorLeitorRecomendacao.BuscaReversaNomeArquivo(it.Name), it.Name))
                .ToImmutableArray());

        string filePath = _fileSystem.Path.Join(directoryInfo.FullName, "index.json");
        using var fileStream = _fileSystem.File.Open(filePath, FileMode.Create, FileAccess.ReadWrite);
        JsonSerializer.Serialize(fileStream, indiceAno, SourceGenerationContext.Default.Options);
        fileStream.Flush();

        progress.Report(new IndiceCriado(filePath));
    }

    private void CriarIndiceCorretora(IDirectoryInfo directoryInfo, IProgress<IndiceCriado> progress)
    {
        var indiceAno = new IndiceCorretora(
            Carteiras: directoryInfo.EnumerateFiles("*.json", SearchOption.TopDirectoryOnly)
                .Where(it => it.Name != "index.json")
                .Select(it => new InfoCarteira(ObterNomeCarteira(it), it.Name))
                .ToImmutableArray());

        string filePath = _fileSystem.Path.Join(directoryInfo.FullName, "index.json");
        using var fileStream = _fileSystem.File.Open(filePath, FileMode.Create, FileAccess.ReadWrite);
        JsonSerializer.Serialize(fileStream, indiceAno, SourceGenerationContext.Default.Options);
        fileStream.Flush();

        progress.Report(new IndiceCriado(filePath));
    }

    private static string? ObterNomeCarteira(IFileInfo fileInfo)
    {
        using var stream = fileInfo.OpenRead();
        var arquivoCarteira =
            JsonSerializer.Deserialize<ArquivoCarteira>(stream, SourceGenerationContext.Default.Options);

        return arquivoCarteira?.Nome;
    }
}

public sealed record IndiceRaiz(ImmutableArray<string> Anos);

public sealed record IndiceAno(ImmutableArray<string> Meses);

public sealed record IndiceMes(ImmutableArray<InfoCorretora> Corretoras);

public sealed record InfoCorretora(string Nome, string Caminho);

public sealed record IndiceCorretora(ImmutableArray<InfoCarteira> Carteiras);

public sealed record InfoCarteira(string? Nome, string Caminho);