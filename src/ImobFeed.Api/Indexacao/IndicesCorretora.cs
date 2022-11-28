using System.Collections.Immutable;
using System.IO.Abstractions;
using System.Text.Json;
using ImobFeed.Api.Indexacao.Modelos;
using ImobFeed.Api.Recomendacoes;
using ImobFeed.Core;

namespace ImobFeed.Api.Indexacao;

public sealed class IndicesCorretora
{
    private readonly IFileSystem _fileSystem;

    public IndicesCorretora(IFileSystem fileSystem)
    {
        _fileSystem = fileSystem;
    }

    public void Criar(IDirectoryInfo directoryInfo, IProgress<ArquivoCriado> progress)
    {
        var indiceAno = new IndiceCorretora(
            Carteiras: directoryInfo.EnumerateFiles(FiltrosArquivos.ArquivosJson, SearchOption.TopDirectoryOnly)
                .Where(FiltrosArquivos.ArquivosCarteira)
                .Select(it => new InfoCarteira(SerializadorArquivoCarteira.Ler(it)?.Nome, it.Name))
                .ToImmutableArray());

        string filePath = _fileSystem.Path.Join(directoryInfo.FullName, "index.json");
        using var fileStream = _fileSystem.File.Open(filePath, FileMode.Create, FileAccess.ReadWrite);
        JsonSerializer.Serialize(fileStream, indiceAno, SourceGenerationContext.DefaultWithConverters.Options);
        fileStream.Flush();

        progress.Report(new ArquivoCriado(filePath));
    }
}