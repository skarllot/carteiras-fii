using ImobFeed.Core.Recomendacoes;
using ImobFeed.Leitores.Texto;
using Microsoft.Extensions.DependencyInjection;

namespace ImobFeed.Leitores;

public static class DependencyInjectionExtensions
{
    public static IServiceCollection AdicionarImobFeedLeitores(this IServiceCollection services)
    {
        // Texto
        services
            .AddSingleton<INomeArquivoCorretora, NomeArquivoCorretora>();

        return services;
    }
}