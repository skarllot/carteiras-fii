using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.IO.Abstractions;
using ImobFeed.Core.Analise;
using ImobFeed.Core.Common;
using NodaTime;
using Spectre.Console;
using Spectre.Console.Cli;

namespace ImobFeed.Reader;

public class FavoritosCommand : Command<FavoritosCommand.Settings>
{
    private readonly IFileSystem _fileSystem;

    public FavoritosCommand(IFileSystem fileSystem)
    {
        _fileSystem = fileSystem;
    }

    public sealed class Settings : CommandSettings
    {
        [Description("Pasta raíz para criar análise")]
        [CommandArgument(0, "<raiz>")]
        public string PastaRaiz { get; init; } = null!;

        [Description("Data no formato \"2022-01\" (padrão mês atual)")]
        [CommandArgument(1, "[data]")]
        public string? Data { get; init; }

        public YearMonth? ResolveData()
        {
            return string.IsNullOrWhiteSpace(Data)
                ? YearMonthProvider.ThisMonth()
                : YearMonthProvider.TryParse(Data);
        }
    }

    public override int Execute([NotNull] CommandContext context, [NotNull] Settings settings)
    {
        var raizDirInfo = _fileSystem.DirectoryInfo.FromDirectoryName(settings.PastaRaiz);
        if (!raizDirInfo.Exists)
        {
            AnsiConsole.MarkupLine($"[red]A pasta raíz '{settings.PastaRaiz}' não foi encontrada[/]");
            return 1;
        }

        var data = settings.ResolveData();
        if (data is null)
        {
            AnsiConsole.MarkupLine($"[red]O formato da data é inválido: {settings.Data}[/]");
            return 2;
        }

        new IndicacoesFavoritas(_fileSystem)
            .Calcular(
                raizDirInfo,
                data.Value,
                new InlineProgress<string>(static it => AnsiConsole.MarkupLine($"Arquivo gerado: [green]{it}[/].")));

        new IndicacoesFavoritasHtml(_fileSystem)
            .Criar(
                raizDirInfo,
                new InlineProgress<string>(static it => AnsiConsole.MarkupLine($"Arquivo gerado: [green]{it}[/].")));

        return 0;
    }
}