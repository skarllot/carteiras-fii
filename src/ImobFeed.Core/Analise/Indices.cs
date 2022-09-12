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

        foreach (var directory in _baseDirectory.EnumerateDirectories()
                     .Where(it => int.TryParse(it.Name, out int r) && r > 2000))
        {
            CriarIndiceAno(directory, progress);
        }
    }

    private void CriarIndiceRaiz(IProgress<IndiceCriado> progress)
    {
        var indiceRaiz = new IndiceRaiz(
            Anos: _baseDirectory.EnumerateDirectories()
                .Where(it => int.TryParse(it.Name, out int r) && r > 2000)
                .Select(it => it.Name)
                .ToImmutableArray(),
            Tops: _baseDirectory.EnumerateFiles("??????-top.json", SearchOption.TopDirectoryOnly)
                .Select(it => new InfoTop(int.Parse(it.Name.AsSpan(0, 4)), int.Parse(it.Name.AsSpan(2, 2)), it.Name))
                .ToImmutableArray());

        string filePath = _fileSystem.Path.Join(_baseDirectory.FullName, "index.json");
        using var fileStream = _fileSystem.File.Open(filePath, FileMode.Create, FileAccess.ReadWrite);
        JsonSerializer.Serialize(fileStream, indiceRaiz, SourceGenerationContext.Default.Options);
        fileStream.Flush();

        progress.Report(new IndiceCriado(filePath));
    }

    private void CriarIndiceAno(IDirectoryInfo directoryInfo, IProgress<IndiceCriado> progress)
    {
        foreach (var directory in directoryInfo.EnumerateDirectories()
                     .Where(it => int.TryParse(it.Name, out int r) && r >= 1 && r <= 12))
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
        foreach (var directory in directoryInfo.EnumerateDirectories()
                     .Where(it => ProvedorLeitorRecomendacao.NomeNormalizadoExiste(it.Name)))
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
                .Select(it => new InfoCarteira(SerializadorArquivoCarteira.Ler(it)?.Nome, it.Name))
                .ToImmutableArray());

        string filePath = _fileSystem.Path.Join(directoryInfo.FullName, "index.json");
        using var fileStream = _fileSystem.File.Open(filePath, FileMode.Create, FileAccess.ReadWrite);
        JsonSerializer.Serialize(fileStream, indiceAno, SourceGenerationContext.Default.Options);
        fileStream.Flush();

        progress.Report(new IndiceCriado(filePath));
    }
}

public sealed record IndiceRaiz(ImmutableArray<string> Anos, ImmutableArray<InfoTop> Tops);

public sealed record IndiceAno(ImmutableArray<string> Meses);

public sealed record IndiceMes(ImmutableArray<InfoCorretora> Corretoras);

public sealed record InfoCorretora(string Nome, string Caminho);

public sealed record IndiceCorretora(ImmutableArray<InfoCarteira> Carteiras);

public sealed record InfoCarteira(string? Nome, string Caminho);

public sealed record InfoTop(int Ano, int Mes, string Caminho);