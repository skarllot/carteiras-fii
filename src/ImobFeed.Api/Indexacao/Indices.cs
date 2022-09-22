using System.IO.Abstractions;

namespace ImobFeed.Api.Indexacao;

public class Indices
{
    private readonly IDirectoryInfo _baseDirectory;
    private readonly IndicesRaiz _indicesRaiz;

    public Indices(IFileSystem fileSystem, IDirectoryInfo baseDirectory)
    {
        _baseDirectory = baseDirectory;
        _indicesRaiz = new IndicesRaiz(fileSystem);
    }

    public void Criar(IProgress<ArquivoCriado> progress)
    {
        _indicesRaiz.Criar(_baseDirectory, progress);
    }
}