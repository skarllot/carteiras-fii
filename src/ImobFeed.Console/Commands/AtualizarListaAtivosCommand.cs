using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.IO.Abstractions;
using ImobFeed.Api.Referencia;
using ImobFeed.Core;
using Spectre.Console;
using Spectre.Console.Cli;

namespace ImobFeed.Console.Commands;

public class AtualizarListaAtivosCommand : Command<AtualizarListaAtivosCommand.Settings>
{
    private readonly IFileSystem _fileSystem;
    private readonly IAppConfigurationManager _appConfig;
    private readonly EscritorListaAtivosIndicadores _escritor;

    public AtualizarListaAtivosCommand(
        IFileSystem fileSystem,
        IAppConfigurationManager appConfig,
        EscritorListaAtivosIndicadores escritor)
    {
        _fileSystem = fileSystem;
        _appConfig = appConfig;
        _escritor = escritor;
    }

    public sealed class Settings : CommandSettings
    {
        [Description("Pasta raíz para criar a lista de ativos")]
        [CommandArgument(0, "<raiz>")]
        public string PastaRaiz { get; init; } = null!;
    }

    public override int Execute([NotNull] CommandContext context, [NotNull] Settings settings)
    {
        var raizDirInfo = _fileSystem.DirectoryInfo.New(settings.PastaRaiz);
        if (!raizDirInfo.Exists)
        {
            AnsiConsole.MarkupLine($"[red]A pasta raíz '{settings.PastaRaiz}' não foi encontrada[/]");
            return 1;
        }

        _appConfig.SetBaseDirectory(raizDirInfo);

        _escritor.Explorar(ArquivoCriadoProgress.Default);

        return 0;
    }
}