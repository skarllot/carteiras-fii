using System.IO.Abstractions;
using System.Text.Json;
using ImobFeed.Api.Recomendacoes;
using ImobFeed.Core;
using ImobFeed.Core.Analise;
using ImobFeed.Core.Recomendacoes;
using ImobFeed.Core.Referencia;
using NodaTime;

namespace ImobFeed.Api.Analise;

public class EscritorIndicacoesFavoritas
{
    private readonly IAppConfiguration _appConfig;
    private readonly IFileSystem _fileSystem;
    private readonly INomeArquivoCorretora _nomeArquivoCorretora;
    private readonly ReferenciaAtivos _referenciaAtivos;
    private readonly CalculadoraIndicacoesFavoritas _calculadora;

    public EscritorIndicacoesFavoritas(
        IAppConfiguration appConfig,
        IFileSystem fileSystem,
        ReferenciaAtivos referenciaAtivos,
        CalculadoraIndicacoesFavoritas calculadora,
        INomeArquivoCorretora nomeArquivoCorretora)
    {
        _appConfig = appConfig;
        _fileSystem = fileSystem;
        _nomeArquivoCorretora = nomeArquivoCorretora;
        _referenciaAtivos = referenciaAtivos;
        _calculadora = calculadora;
    }

    public void Calcular(YearMonth data, IProgress<ArquivoCriado> progress)
    {
        var dictAtivos = _referenciaAtivos.CarregarAtivos();
        var dictIndicadores = _referenciaAtivos.CarregarIndicadores();

        var apiDirectory = _appConfig.GetApiDirectory();

        var indicacoes = apiDirectory
            .IrPara(data)
            .EnumerateFiles("*.json", SearchOption.AllDirectories)
            .Where(it => it.Name != "index.json")
            .Select(
                it => new CarteiraCorretora(
                    Corretora: _nomeArquivoCorretora.BuscaReversaNomeArquivo(it.Directory.Name),
                    Carteira: SerializadorArquivoCarteira.Ler(it)!));

        var lista = _calculadora.Calcular(dictAtivos, dictIndicadores, data, indicacoes);

        string path = _fileSystem.Path.Combine(apiDirectory.FullName, $"{data.Year}{data.Month:00}-favoritos.json");
        using var stream = _fileSystem.File.Open(path, FileMode.Create, FileAccess.Write);
        JsonSerializer.Serialize(stream, lista, SourceGenerationContext.Default.Options);
        stream.Flush();

        progress.Report(new ArquivoCriado(path));
    }
}