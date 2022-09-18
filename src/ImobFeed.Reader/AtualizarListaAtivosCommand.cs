using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.IO.Abstractions;
using ImobFeed.Core.Common;
using ImobFeed.Core.Referencia;
using Spectre.Console;
using Spectre.Console.Cli;

namespace ImobFeed.Reader;

public class AtualizarListaAtivosCommand : Command<AtualizarListaAtivosCommand.Settings>
{
    private readonly IFileSystem _fileSystem;

    public AtualizarListaAtivosCommand(IFileSystem fileSystem)
    {
        _fileSystem = fileSystem;
    }

    public sealed class Settings : CommandSettings
    {
        [Description("Pasta raíz para criar a lista de ativos")]
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

        new ReferenciaAtivos(_fileSystem)
            .Atualizar(
                raizDirInfo,
                new InlineProgress<string>(static it => AnsiConsole.MarkupLine($"Arquivo gerado: [green]{it}[/].")));

        return 0;
    }
}