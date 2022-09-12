using System.Collections.Immutable;
using System.IO.Abstractions;
using System.Text;
using System.Text.Json;
using Stubble.Core;
using Stubble.Core.Builders;

namespace ImobFeed.Core.Analise;

public class IndicacoesFavoritasAsciidoc
{
    private readonly IFileSystem _fileSystem;
    private readonly StubbleVisitorRenderer _stubble;

    public IndicacoesFavoritasAsciidoc(IFileSystem fileSystem)
    {
        _fileSystem = fileSystem;
        _stubble = new StubbleBuilder().Build();
    }

    private const string Template =
        @"= Indicações Favoritas em {{Mes}}/{{Ano}}

[cols=""1,2,2,1,4"", options=""header""]
|===
|Código |Nome |Segmento |Peso |Corretoras

{{#Indicacoes}}
|{{Codigo}}
|{{Nome}}
|{{Segmento}}
|{{Peso}}%
|{{#Corretoras}}{{.}}, {{/Corretoras}}

{{/Indicacoes}}";

    public void Criar(IDirectoryInfo baseDirectory, IProgress<string> progress)
    {
        foreach (var file in baseDirectory.EnumerateFiles("??????-favoritos.json", SearchOption.TopDirectoryOnly))
        {
            Criar(file, progress);
        }
    }

    private void Criar(IFileInfo source, IProgress<string> progress)
    {
        var destination = _fileSystem.FileInfo.FromFileName(source.FullName.Replace(".json", ".adoc"));
        if (destination.Exists && destination.LastWriteTimeUtc > source.LastWriteTimeUtc)
            return;

        using var stream = source.OpenRead();
        var indicacoesFavoritas = JsonSerializer.Deserialize<ListaIndicacoesFavoritas>(
            stream,
            SourceGenerationContext.Default.Options)!;

        string result = _stubble.Render(
            Template,
            indicacoesFavoritas with
            {
                Indicacoes = indicacoesFavoritas.Indicacoes
                    .Select(it => it with { Peso = Math.Round(it.Peso * 100m, 2) })
                    .ToImmutableArray()
            });

        _fileSystem.File.WriteAllText(destination.FullName, result, Encoding.UTF8);

        progress.Report(destination.FullName);
    }
}