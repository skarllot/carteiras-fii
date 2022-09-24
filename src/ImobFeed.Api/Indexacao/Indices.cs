using System.IO.Abstractions;

namespace ImobFeed.Api.Indexacao;

public class Indices
{
    private readonly IndicesRaiz _indicesRaiz;

    public Indices(IndicesRaiz indicesRaiz)
    {
        _indicesRaiz = indicesRaiz;
    }

    public void Criar(IDirectoryInfo baseDirectory, IProgress<ArquivoCriado> progress)
    {
        _indicesRaiz.Criar(baseDirectory, progress);
    }
}