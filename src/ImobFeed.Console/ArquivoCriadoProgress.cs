using ImobFeed.Api;
using Spectre.Console;

namespace ImobFeed.Console;

public sealed class ArquivoCriadoProgress : IProgress<ArquivoCriado>, IProgress<string>
{
    public static readonly ArquivoCriadoProgress Default = new();

    public void Report(ArquivoCriado value) => AnsiConsole.MarkupLine($"Arquivo gerado: [green]{value.FilePath}[/].");
    public void Report(string value) => AnsiConsole.MarkupLine($"Arquivo gerado: [green]{value}[/].");
}