using System.Collections.Immutable;
using System.IO.Abstractions;
using System.Text.Json;
using ImobFeed.Core.CarteiraMensal;

namespace ImobFeed.Core.Exportadores;

public class ExportadorRecomendacao
{
    private readonly IFileSystem _fileSystem;
    private readonly IDirectoryInfo _baseDirectory;

    public ExportadorRecomendacao(IFileSystem fileSystem, IDirectoryInfo baseDirectory)
    {
        _fileSystem = fileSystem;
        _baseDirectory = baseDirectory;
    }

    public void Salvar(Recomendacao recomendacao, IProgress<RecomendacaoSalva> progress)
    {
        var dirRecomendacao = _baseDirectory
            .CreateSubdirectory(recomendacao.Data.Year.ToString())
            .CreateSubdirectory(recomendacao.Data.Month.ToString("00"))
            .CreateSubdirectory(SistemaArquivos.NormalizarNome(recomendacao.Corretora));

        string filePath = _fileSystem.Path.Join(
            dirRecomendacao.FullName,
            (SistemaArquivos.NormalizarNome(recomendacao.NomeCarteira) ?? "default") + ".json");

        using var fileStream = _fileSystem.File.Open(filePath, FileMode.Create, FileAccess.ReadWrite);
        JsonSerializer.Serialize(
            fileStream,
            new ArquivoCarteira(recomendacao.NomeCarteira, recomendacao.Carteira),
            SourceGenerationContext.Default.Options);

        fileStream.Flush();

        progress.Report(new RecomendacaoSalva(filePath));
    }
}

public sealed record ArquivoCarteira(string? Nome, ImmutableArray<AtivoRecomendado> Ativos);