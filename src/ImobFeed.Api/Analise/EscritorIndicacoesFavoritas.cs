using System.IO.Abstractions;
using System.Text.Json;
using ImobFeed.Api.Recomendacoes;
using ImobFeed.Core;
using ImobFeed.Core.Analise;
using ImobFeed.Core.Analise.Modelos;
using ImobFeed.Core.Recomendacoes;
using ImobFeed.Core.Referencia;
using NodaTime;

namespace ImobFeed.Api.Analise;

public class EscritorIndicacoesFavoritas
{
    private readonly IAppConfiguration _appConfig;
    private readonly IFileSystem _fileSystem;
    private readonly INomeArquivoCorretora _nomeArquivoCorretora;
    private readonly IReferenciaAtivos _referenciaAtivos;
    private readonly CalculadoraIndicacoesFavoritas _calculadora;

    public EscritorIndicacoesFavoritas(
        IAppConfiguration appConfig,
        IFileSystem fileSystem,
        IReferenciaAtivos referenciaAtivos,
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
        var dictAtivos = _referenciaAtivos.CarregarAtivos().ToDictionary();
        var dictIndicadores = _referenciaAtivos.CarregarIndicadores(data).ToDictionary();

        var apiDirectory = _appConfig.GetApiDirectory();

        var arquivosCarteira = apiDirectory
            .IrPara(data)
            .EnumerateFiles(FiltrosArquivos.ArquivosJson, SearchOption.AllDirectories)
            .Where(it => _nomeArquivoCorretora.NomeNormalizadoExiste(it.Directory.Name))
            .Where(FiltrosArquivos.ArquivosCarteira)
            .ToList();

        var dataCarteiraMaisNova = arquivosCarteira
            .Select(it => it.LastWriteTimeUtc)
            .MaxBy(it => it);

        string path = _fileSystem.Path.Combine(apiDirectory.FullName, $"{data.Year}{data.Month:00}-favoritos.json");
        var destination = _fileSystem.FileInfo.FromFileName(path);
        if (destination.Exists && destination.LastWriteTimeUtc > dataCarteiraMaisNova)
            return;

        var indicacoes = arquivosCarteira.Select(
            it => new CarteiraCorretora(
                Corretora: _nomeArquivoCorretora.BuscaReversaNomeArquivo(it.Directory.Name),
                Carteira: SerializadorArquivoCarteira.Ler(it)!));

        var lista = _calculadora.Calcular(dictAtivos, dictIndicadores, data, indicacoes);

        using var stream = destination.Open(FileMode.Create, FileAccess.Write);
        JsonSerializer.Serialize(stream, lista, SourceGenerationContext.DefaultWithConverters.Options);
        stream.Flush();

        progress.Report(new ArquivoCriado(path));
    }
}