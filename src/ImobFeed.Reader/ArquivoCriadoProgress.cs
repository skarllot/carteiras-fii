using ImobFeed.Api;
using Spectre.Console;

namespace ImobFeed.Reader;

public sealed class ArquivoCriadoProgress : IProgress<ArquivoCriado>
{
    public static readonly ArquivoCriadoProgress Default = new();

    public void Report(ArquivoCriado value) => AnsiConsole.MarkupLine($"Arquivo gerado: [green]{value.FilePath}[/].");
}