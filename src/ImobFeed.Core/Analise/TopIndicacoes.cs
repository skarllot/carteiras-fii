using System.Collections.Immutable;
using System.IO.Abstractions;
using System.Text.Json;
using ImobFeed.Core.Exportadores;
using ImobFeed.Core.Leitores;
using NodaTime;

namespace ImobFeed.Core.Analise;

public class TopIndicacoes
{
    private readonly IFileSystem _fileSystem;

    public TopIndicacoes(IFileSystem fileSystem)
    {
        _fileSystem = fileSystem;
    }

    public void Calcular(IDirectoryInfo baseDirectory, YearMonth data, IProgress<string> progress)
    {
        var indicacoes = baseDirectory
            .CreateSubdirectory(data.Year.ToString())
            .CreateSubdirectory(data.Month.ToString("00"))
            .EnumerateFiles("*.json", SearchOption.AllDirectories)
            .Where(it => it.Name != "index.json")
            .Select(
                it => (Corretora: ProvedorLeitorRecomendacao.BuscaReversaNomeArquivo(it.Directory.Name),
                    Carteira: SerializadorArquivoCarteira.Ler(it)!))
            .SelectMany(it => it.Carteira.Ativos.Select(x => (it.Corretora, x.Codigo)))
            .GroupBy(it => it.Codigo)
            .Select(it => new IndicacaoTopAtivo(it.Key, it.Count(), it.Select(x => x.Corretora).ToImmutableArray()))
            .OrderByDescending(it => it.Quantidade);

        var lista = new ListaTopIndicacoes(0, 0, indicacoes.ToImmutableArray());

        string path = _fileSystem.Path.Combine(baseDirectory.FullName, $"{data.Year}{data.Month:00}-top.json");
        using var stream = _fileSystem.File.Open(path, FileMode.Create, FileAccess.Write);
        JsonSerializer.Serialize(stream, lista, SourceGenerationContext.Default.Options);
        stream.Flush();
        
        progress.Report(path);
    }
}

public sealed record ListaTopIndicacoes(int Ano, int Mes, ImmutableArray<IndicacaoTopAtivo> Indicacoes);

public sealed record IndicacaoTopAtivo(string Codigo, int Quantidade, ImmutableArray<string> Corretoras);