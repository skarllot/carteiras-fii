using ImobFeed.Api.Analise;
using ImobFeed.Api.Indexacao;
using ImobFeed.Api.Recomendacoes;
using ImobFeed.Api.Referencia;
using ImobFeed.Core.Referencia;
using Microsoft.Extensions.DependencyInjection;

namespace ImobFeed.Api;

public static class DependencyInjectionExtensions
{
    public static IServiceCollection AdicionarImobFeedApi(this IServiceCollection services)
    {
        // Analise
        services
            .AddSingleton<EscritorIndicacoesFavoritas>();

        // Indexacao
        services
            .AddSingleton<Indices>()
            .AddSingleton<IndicesRaiz>()
            .AddSingleton<IndicesAno>()
            .AddSingleton<IndicesMes>()
            .AddSingleton<IndicesCorretora>();

        // Recomendacoes
        services
            .AddSingleton<ExportadorRecomendacao>();

        // Referencia
        services
            .AddSingleton<EscritorListaAtivosIndicadores>()
            .AddSingleton<IReferenciaAtivos, LeitorArquivosReferencia>();

        return services;
    }
}