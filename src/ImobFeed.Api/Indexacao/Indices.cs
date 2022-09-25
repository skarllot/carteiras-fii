using ImobFeed.Core;

namespace ImobFeed.Api.Indexacao;

public class Indices
{
    private readonly IndicesRaiz _indicesRaiz;
    private readonly IAppConfiguration _appConfig;

    public Indices(IndicesRaiz indicesRaiz, IAppConfiguration appConfig)
    {
        _indicesRaiz = indicesRaiz;
        _appConfig = appConfig;
    }

    public void Criar(IProgress<ArquivoCriado> progress)
    {
        _indicesRaiz.Criar(_appConfig.GetApiDirectory(), progress);
    }
}