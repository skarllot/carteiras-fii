using ImobFeed.Api.Analise;
using ImobFeed.Api.Indexacao;
using ImobFeed.Api.Recomendacoes;
using ImobFeed.Api.Referencia;
using ImobFeed.Core.Referencia;
using Jab;

namespace ImobFeed.Api;

[ServiceProviderModule]

// Analise
[Singleton(typeof(EscritorIndicacoesFavoritas))]

// Indexacao
[Singleton(typeof(Indices))]
[Singleton(typeof(IndicesRaiz))]
[Singleton(typeof(IndicesAno))]
[Singleton(typeof(IndicesMes))]
[Singleton(typeof(IndicesCorretora))]

// Recomendacoes
[Singleton(typeof(ExportadorRecomendacao))]

// Referencia
[Singleton(typeof(EscritorListaAtivosIndicadores))]
[Singleton(typeof(IReferenciaAtivos), typeof(LeitorArquivosReferencia))]
public interface IApiContainerModule
{
}