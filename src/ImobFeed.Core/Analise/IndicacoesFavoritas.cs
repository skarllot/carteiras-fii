using System.Collections.Immutable;
using System.IO.Abstractions;
using System.Text.Json;
using ImobFeed.Core.Exportadores;
using ImobFeed.Core.Leitores;
using NodaTime;

namespace ImobFeed.Core.Analise;

public class IndicacoesFavoritas
{
    private readonly IFileSystem _fileSystem;
    private readonly AtivosClubeFii _ativosClubeFii;

    public IndicacoesFavoritas(IFileSystem fileSystem)
    {
        _fileSystem = fileSystem;
        _ativosClubeFii = new AtivosClubeFii(fileSystem);
    }

    public void Calcular(IDirectoryInfo baseDirectory, YearMonth data, IProgress<string> progress)
    {
        var dictAtivos = _ativosClubeFii.CarregarAtivos(baseDirectory);

        decimal pesoCorretora = 1m / baseDirectory
            .CreateSubdirectory(data.Year.ToString())
            .CreateSubdirectory(data.Month.ToString("00"))
            .EnumerateDirectories()
            .Select(it => ProvedorLeitorRecomendacao.BuscaReversaNomeArquivo(it.Name))
            .Count();

        var indicacoes = baseDirectory
            .CreateSubdirectory(data.Year.ToString())
            .CreateSubdirectory(data.Month.ToString("00"))
            .EnumerateFiles("*.json", SearchOption.AllDirectories)
            .Where(it => it.Name != "index.json")
            .Select(
                it => (Corretora: ProvedorLeitorRecomendacao.BuscaReversaNomeArquivo(it.Directory.Name),
                    Carteira: SerializadorArquivoCarteira.Ler(it)!))
            .GroupBy(it => it.Corretora)
            .Select(it => (Corretora: it.Key, QtdCarteiras: it.Count(), Carteiras: it.Select(x => x.Carteira)))
            .SelectMany(it => it.Carteiras.Select(x => (it.Corretora, PesoCarteira: 1m / it.QtdCarteiras, Carteira: x)))
            .SelectMany(
                it => it.Carteira.Ativos.Select(
                    x => (it.Corretora,
                        Ativo: dictAtivos[x.Codigo],
                        Peso: x.Peso.Valor * it.PesoCarteira * pesoCorretora)))
            .GroupBy(it => it.Ativo)
            .Select(
                it => new IndicacaoAtivoFavorito(
                    it.Key.Codigo,
                    it.Key.Nome,
                    it.Key.Segmento,
                    it.Key.Administrador,
                    it.Key.PVpa,
                    it.Key.Yield1Mes,
                    it.Key.Yield12Meses,
                    Math.Round(it.Sum(x => x.Peso), 4),
                    it.Select(x => x.Corretora).Distinct().ToImmutableArray()))
            .OrderByDescending(it => it.Peso)
            .ToImmutableArray();

        var lista = new ListaIndicacoesFavoritas(data.Year, data.Month, indicacoes);

        string path = _fileSystem.Path.Combine(baseDirectory.FullName, $"{data.Year}{data.Month:00}-favoritos.json");
        using var stream = _fileSystem.File.Open(path, FileMode.Create, FileAccess.Write);
        JsonSerializer.Serialize(stream, lista, SourceGenerationContext.Default.Options);
        stream.Flush();

        progress.Report(path);
    }
}

public sealed record ListaIndicacoesFavoritas(int Ano, int Mes, ImmutableArray<IndicacaoAtivoFavorito> Indicacoes);

public sealed record IndicacaoAtivoFavorito(
    string Codigo,
    string Nome,
    string Segmento,
    string Administrador,
    decimal? PVpa,
    decimal? Yield1Mes,
    decimal? Yield12Meses,
    decimal Peso,
    ImmutableArray<string> Corretoras);