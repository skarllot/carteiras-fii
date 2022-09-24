using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.IO.Abstractions;
using ImobFeed.Api.Analise;
using ImobFeed.Core;
using ImobFeed.Html.Analise;
using NodaTime;
using Spectre.Console;
using Spectre.Console.Cli;

namespace ImobFeed.Console;

public class FavoritosCommand : Command<FavoritosCommand.Settings>
{
    private readonly IFileSystem _fileSystem;
    private readonly DefaultAppConfiguration _appConfig;
    private readonly EscritorIndicacoesFavoritas _escritorJson;
    private readonly IndicacoesFavoritasHtml _escritorHtml;

    public FavoritosCommand(
        IFileSystem fileSystem,
        DefaultAppConfiguration appConfig,
        EscritorIndicacoesFavoritas escritorJson,
        IndicacoesFavoritasHtml escritorHtml)
    {
        _fileSystem = fileSystem;
        _appConfig = appConfig;
        _escritorJson = escritorJson;
        _escritorHtml = escritorHtml;
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

        _appConfig.BaseDirectory = raizDirInfo;

        _escritorJson.Calcular(data.Value, ArquivoCriadoProgress.Default);
        _escritorHtml.Criar(ArquivoCriadoProgress.Default);

        return 0;
    }
}