using System.Collections.Immutable;
using System.IO.Abstractions;
using System.Text;
using System.Text.Json;
using ImobFeed.Api;
using ImobFeed.Core;
using ImobFeed.Core.Analise.Modelos;
using ImobFeed.Core.Common;
using Stubble.Core;
using Stubble.Core.Builders;
using Stubble.Core.Settings;

namespace ImobFeed.Html.Analise;

public class IndicacoesFavoritasHtml
{
    private readonly IFileSystem _fileSystem;
    private readonly IAppConfiguration _appConfig;
    private readonly StubbleVisitorRenderer _stubble;
    private readonly RenderSettings _renderSettings;

    public IndicacoesFavoritasHtml(IFileSystem fileSystem, IAppConfiguration appConfig)
    {
        _fileSystem = fileSystem;
        _appConfig = appConfig;
        _stubble = new StubbleBuilder().Build();
        _renderSettings = RenderSettings.GetDefaultRenderSettings();
        _renderSettings.CultureInfo = CultureCache.PortuguesBrasil;
    }

    public void Criar(IProgress<string> progress)
    {
        var apiDirectory = _appConfig.GetApiDirectory();
        foreach (var file in apiDirectory.EnumerateFiles("??????-favoritos.json", SearchOption.TopDirectoryOnly))
        {
            CriarArquivo(file, progress);
        }
    }

    private void CriarArquivo(IFileInfo source, IProgress<string> progress)
    {
        string destinationFileName = _fileSystem.Path.Combine(
            _appConfig.BaseDirectory.FullName,
            source.Name.Replace(".json", ".html"));

        var destination = _fileSystem.FileInfo.New(destinationFileName);
        if (destination.Exists && destination.LastWriteTimeUtc > source.LastWriteTimeUtc)
            return;

        using var stream = source.OpenRead();
        var indicacoesFavoritas = JsonSerializer.Deserialize<ListaIndicacoesFavoritas>(
            stream,
            SourceGenerationContext.Default.Options)!;

        string result = _stubble.Render(
            Templates.IndicacoesFavoritas(),
            indicacoesFavoritas with
            {
                Indicacoes = indicacoesFavoritas.Indicacoes
                    .Select(
                        it => it with
                        {
                            Peso = Math.Round(it.Peso * 100m, 2),
                            Yield1Mes = it.Yield1Mes is not null
                                ? Math.Round(it.Yield1Mes.Value * 100m, 2)
                                : null,
                            Yield12Meses = it.Yield12Meses is not null
                                ? Math.Round(it.Yield12Meses.Value * 100m, 2)
                                : null,
                            Corretoras = ImmutableArray.Create(string.Join(", ", it.Corretoras))
                        })
                    .ToImmutableArray()
            },
            _renderSettings);

        _fileSystem.File.WriteAllText(destination.FullName, result, Encoding.UTF8);

        progress.Report(destination.FullName);
    }
}