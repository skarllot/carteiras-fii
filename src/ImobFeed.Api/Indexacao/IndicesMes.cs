using System.Collections.Immutable;
using System.IO.Abstractions;
using System.Text.Json;
using ImobFeed.Api.Indexacao.Modelos;
using ImobFeed.Core;
using ImobFeed.Core.Recomendacoes;

namespace ImobFeed.Api.Indexacao;

public sealed class IndicesMes
{
    private readonly IFileSystem _fileSystem;
    private readonly INomeArquivoCorretora _nomeArquivoCorretora;
    private readonly IndicesCorretora _indicesCorretora;

    public IndicesMes(
        IFileSystem fileSystem,
        INomeArquivoCorretora nomeArquivoCorretora,
        IndicesCorretora indicesCorretora)
    {
        _fileSystem = fileSystem;
        _nomeArquivoCorretora = nomeArquivoCorretora;
        _indicesCorretora = indicesCorretora;
    }

    public void Criar(IDirectoryInfo directoryInfo, IProgress<ArquivoCriado> progress)
    {
        directoryInfo.EnumerateDirectories()
            .Where(FiltrosArquivos.DiretoriosCorretora(_nomeArquivoCorretora))
            .Pipe(
                it => CriarIndicesCorretora(it, progress),
                it => CriarIndiceMes(it, directoryInfo, progress));
    }

    private void CriarIndicesCorretora(IEnumerable<IDirectoryInfo> directories, IProgress<ArquivoCriado> progress)
    {
        foreach (var directory in directories)
        {
            _indicesCorretora.Criar(directory, progress);
        }
    }

    private void CriarIndiceMes(
        IEnumerable<IDirectoryInfo> directories,
        IDirectoryInfo baseDirectory,
        IProgress<ArquivoCriado> progress)
    {
        var indiceMes = new IndiceMes(
            Corretoras: directories
                .Select(it => new InfoCorretora(_nomeArquivoCorretora.BuscaReversaNomeArquivo(it.Name), it.Name))
                .ToImmutableArray());

        string filePath = _fileSystem.Path.Join(baseDirectory.FullName, "index.json");
        using var fileStream = _fileSystem.File.Open(filePath, FileMode.Create, FileAccess.ReadWrite);
        JsonSerializer.Serialize(fileStream, indiceMes, JsonSerializerOptionsProvider.Default);
        fileStream.Flush();

        progress.Report(new ArquivoCriado(filePath));
    }
}