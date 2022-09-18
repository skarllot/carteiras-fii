using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.IO.Abstractions;
using ImobFeed.Core.Common;
using ImobFeed.Core.Exportadores;
using ImobFeed.Core.Leitores;
using ImobFeed.Core.Referencia;
using NodaTime;
using Spectre.Console;
using Spectre.Console.Cli;

namespace ImobFeed.Reader;

public class TextFileCommand : Command<TextFileCommand.Settings>
{
    private readonly IFileSystem _fileSystem;

    public TextFileCommand(IFileSystem fileSystem)
    {
        _fileSystem = fileSystem;
    }

    public sealed class Settings : CommandSettings
    {
        [Description("Arquivo de entrada com as recomendações brutas do mês")]
        [CommandArgument(0, "<arquivo>")]
        public string Arquivo { get; init; } = null!;

        [Description("Pasta de saída para exportar as recomendações num formato padronizado")]
        [CommandArgument(1, "<saida>")]
        public string Saida { get; init; } = null!;

        [Description("Data no formato \"2022-01\" (padrão mês atual)")]
        [CommandOption("-d|--data")]
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
        var data = settings.ResolveData();
        if (data is null)
        {
            AnsiConsole.MarkupLine($"[red]O formato da data é inválido: {settings.Data}[/]");
            return 1;
        }

        var arquivoFileInfo = _fileSystem.FileInfo.FromFileName(settings.Arquivo);
        if (!arquivoFileInfo.Exists)
        {
            AnsiConsole.MarkupLine($"[red]O arquivo '{settings.Arquivo}' não foi encontrado[/]");
            return 2;
        }

        var saidaDirInfo = _fileSystem.DirectoryInfo.FromDirectoryName(settings.Saida);
        if (!saidaDirInfo.Exists)
        {
            AnsiConsole.MarkupLine($"[red]A pasta de saída '{settings.Saida}' não foi encontrada[/]");
            return 3;
        }

        var leitor = new LeitorListaRecomendacao(data.Value);
        var recomendacoes = leitor.LerTudo(
            arquivoFileInfo,
            new ReferenciaAtivos(_fileSystem).CarregarAtivos(saidaDirInfo));

        var exportador = new ExportadorRecomendacao(_fileSystem, saidaDirInfo);
        foreach (var recomendacao in recomendacoes)
        {
            exportador.Salvar(
                recomendacao,
                new InlineProgress<RecomendacaoSalva>(
                    static it => AnsiConsole.MarkupLine($"Arquivo gerado: [green]{it.FilePath}[/].")));
        }

        return 0;
    }
}