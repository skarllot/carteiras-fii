using System.IO.Abstractions;
using System.Text.Json;
using ImobFeed.Core;
using ImobFeed.Core.Analise;
using ImobFeed.Core.Exportadores;
using ImobFeed.Core.Leitores;
using ImobFeed.Core.Referencia;
using NodaTime;

namespace ImobFeed.Api.Analise;

public class EscritorIndicacoesFavoritas
{
    private readonly IFileSystem _fileSystem;
    private readonly ReferenciaAtivos _referenciaAtivos;
    private readonly CalculadoraIndicacoesFavoritas _calculadora;

    public EscritorIndicacoesFavoritas(IFileSystem fileSystem)
    {
        _fileSystem = fileSystem;
        _referenciaAtivos = new ReferenciaAtivos(fileSystem);
        _calculadora = new CalculadoraIndicacoesFavoritas();
    }

    public void Calcular(IDirectoryInfo baseDirectory, YearMonth data, IProgress<string> progress)
    {
        var dictAtivos = _referenciaAtivos.CarregarAtivos(baseDirectory);
        var dictIndicadores = _referenciaAtivos.CarregarIndicadores(baseDirectory);

        var indicacoes = baseDirectory
            .IrPara(data)
            .EnumerateFiles("*.json", SearchOption.AllDirectories)
            .Where(it => it.Name != "index.json")
            .Select(
                it => new CarteiraCorretora(
                    Corretora: ProvedorLeitorRecomendacao.BuscaReversaNomeArquivo(it.Directory.Name),
                    Carteira: SerializadorArquivoCarteira.Ler(it)!));

        var lista = _calculadora.Calcular(dictAtivos, dictIndicadores, data, indicacoes);

        string path = _fileSystem.Path.Combine(baseDirectory.FullName, $"{data.Year}{data.Month:00}-favoritos.json");
        using var stream = _fileSystem.File.Open(path, FileMode.Create, FileAccess.Write);
        JsonSerializer.Serialize(stream, lista, SourceGenerationContext.Default.Options);
        stream.Flush();

        progress.Report(path);
    }
}