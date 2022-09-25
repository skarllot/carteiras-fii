using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.IO.Abstractions;
using ImobFeed.Api.Indexacao;
using Spectre.Console;
using Spectre.Console.Cli;

namespace ImobFeed.Console.Commands;

public class IndexCommand : Command<IndexCommand.Settings>
{
    private readonly IFileSystem _fileSystem;
    private readonly Indices _indices;

    public IndexCommand(IFileSystem fileSystem, Indices indices)
    {
        _fileSystem = fileSystem;
        _indices = indices;
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

        _indices.Criar(raizDirInfo, ArquivoCriadoProgress.Default);

        return 0;
    }
}