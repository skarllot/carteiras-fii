using System.IO.Abstractions;
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

        SerializadorArquivoCarteira.Salvar(
            _fileSystem.FileInfo.FromFileName(filePath),
            new ArquivoCarteira(recomendacao.NomeCarteira, recomendacao.Carteira));

        progress.Report(new RecomendacaoSalva(filePath));
    }
}