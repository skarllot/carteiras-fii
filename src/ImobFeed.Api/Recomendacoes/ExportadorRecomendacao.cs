using System.IO.Abstractions;
using ImobFeed.Core;
using ImobFeed.Core.CarteiraMensal;
using ImobFeed.Core.Recomendacoes.Modelos;

namespace ImobFeed.Api.Recomendacoes;

public class ExportadorRecomendacao
{
    private readonly IFileSystem _fileSystem;
    private readonly IDirectoryInfo _baseDirectory;

    public ExportadorRecomendacao(IFileSystem fileSystem, IDirectoryInfo baseDirectory)
    {
        _fileSystem = fileSystem;
        _baseDirectory = baseDirectory;
    }

    public void Salvar(Recomendacao recomendacao, IProgress<ArquivoCriado> progress)
    {
        var dirRecomendacao = _baseDirectory
            .IrPara(recomendacao.Data)
            .CreateSubdirectory(SistemaArquivos.NormalizarNome(recomendacao.Corretora));

        string filePath = _fileSystem.Path.Join(
            dirRecomendacao.FullName,
            (SistemaArquivos.NormalizarNome(recomendacao.NomeCarteira) ?? "default") + ".json");

        SerializadorArquivoCarteira.Salvar(
            _fileSystem.FileInfo.FromFileName(filePath),
            new ArquivoCarteira(recomendacao.NomeCarteira, recomendacao.Carteira));

        progress.Report(new ArquivoCriado(filePath));
    }
}