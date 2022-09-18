using System.Collections.Immutable;
using System.IO.Abstractions;
using System.Text;
using System.Text.Json;
using ImobFeed.Core.Common;
using Stubble.Core;
using Stubble.Core.Builders;
using Stubble.Core.Settings;

namespace ImobFeed.Core.Analise;

public class IndicacoesFavoritasHtml
{
    private readonly IFileSystem _fileSystem;
    private readonly StubbleVisitorRenderer _stubble;
    private readonly RenderSettings _renderSettings;

    public IndicacoesFavoritasHtml(IFileSystem fileSystem)
    {
        _fileSystem = fileSystem;
        _stubble = new StubbleBuilder().Build();
        _renderSettings = RenderSettings.GetDefaultRenderSettings();
        _renderSettings.CultureInfo = CultureCache.PortuguesBrasil;
    }

    public void Criar(IDirectoryInfo baseDirectory, IProgress<string> progress)
    {
        foreach (var file in baseDirectory.EnumerateFiles("??????-favoritos.json", SearchOption.TopDirectoryOnly))
        {
            Criar(file, progress);
        }
    }

    private void Criar(IFileInfo source, IProgress<string> progress)
    {
        var destination = _fileSystem.FileInfo.FromFileName(source.FullName.Replace(".json", ".html"));
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