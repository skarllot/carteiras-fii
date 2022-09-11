using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.IO.Abstractions;
using ImobFeed.Core.Analise;
using ImobFeed.Core.Common;
using Spectre.Console;
using Spectre.Console.Cli;

namespace ImobFeed.Reader;

public class IndexCommand : Command<IndexCommand.Settings>
{
    private readonly IFileSystem _fileSystem;

    public IndexCommand(IFileSystem fileSystem)
    {
        _fileSystem = fileSystem;
    }

    public sealed class Settings : CommandSettings
    {
        [Description("Pasta raíz para criar índices")]
        [CommandArgument(0, "<raiz>")]
        public string PastaRaiz { get; init; } = null!;
    }

    public override int Execute([NotNull] CommandContext context, [NotNull] Settings settings)
    {
        var raizDirInfo = _fileSystem.DirectoryInfo.FromDirectoryName(settings.PastaRaiz);
        if (!raizDirInfo.Exists)
        {
            AnsiConsole.MarkupLine($"[red]A pasta raíz '{settings.PastaRaiz}' não foi encontrada[/]");
            return 1;
        }

        new Indices(_fileSystem, raizDirInfo)
            .Criar(
                new InlineProgress<IndiceCriado>(
                    static it => AnsiConsole.MarkupLine($"Arquivo gerado: [green]{it.FilePath}[/].")));

        return 0;
    }
}