using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.IO.Abstractions;
using ImobFeed.Api.Recomendacoes;
using ImobFeed.Core.Referencia;
using ImobFeed.Leitores.Imagem;
using ImobFeed.Leitores.Texto;
using NodaTime;
using Spectre.Console;
using Spectre.Console.Cli;

namespace ImobFeed.Reader;

public sealed class ImageFileCommand : Command<ImageFileCommand.Settings>
{
    private readonly IFileSystem _fileSystem;

    public ImageFileCommand(IFileSystem fileSystem)
    {
        _fileSystem = fileSystem;
    }

    public sealed class Settings : CommandSettings
    {
        [Description("O nome da corretora da recomendação")]
        [CommandArgument(0, "<corretora>")]
        public string Corretora { get; init; } = null!;

        [Description("Imagem de entrada com a recomendação do mês")]
        [CommandArgument(1, "<imagem>")]
        public string Imagem { get; init; } = null!;

        [Description("Pasta de saída para exportar a recomendação num formato padronizado")]
        [CommandArgument(2, "<saida>")]
        public string Saida { get; init; } = null!;

        [Description("Data no formato \"2022-01\" (padrão mês atual)")]
        [CommandOption("-d|--data")]
        public string? Data { get; init; }

        [Description("Nome da carteira (default)")]
        [CommandOption("-n|--nome")]
        public string NomeCarteira { get; init; } = "default";

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

        var leitorRecomendacao = ProvedorLeitorRecomendacao.Buscar(settings.Corretora);
        if (leitorRecomendacao is null)
        {
            AnsiConsole.MarkupLine($"[red]Corretora não encontrada: {settings.Corretora}[/]");
            return 2;
        }

        var imagemFileInfo = _fileSystem.FileInfo.FromFileName(settings.Imagem);
        if (!imagemFileInfo.Exists)
        {
            AnsiConsole.MarkupLine($"[red]O arquivo '{settings.Imagem}' não foi encontrado[/]");
            return 3;
        }

        var saidaDirInfo = _fileSystem.DirectoryInfo.FromDirectoryName(settings.Saida);
        if (!saidaDirInfo.Exists)
        {
            AnsiConsole.MarkupLine($"[red]A pasta de saída '{settings.Saida}' não foi encontrada[/]");
            return 4;
        }

        var leitorImagem = new LeitorImagem();
        string textoImagem = leitorImagem.LerTextoImagem(imagemFileInfo);

        using var reader = new StringReader(textoImagem);
        var recomendacao = leitorRecomendacao.Ler(
            new ReferenciaAtivos(_fileSystem).CarregarAtivos(saidaDirInfo),
            reader,
            settings.NomeCarteira,
            data.Value);

        var exportador = new ExportadorRecomendacao(_fileSystem, saidaDirInfo);
        exportador.Salvar(recomendacao, ArquivoCriadoProgress.Default);

        return 0;
    }
}