using ImobFeed.Core.Referencia;
using ImobFeed.Html.Analise;
using ImobFeed.Html.Referencia;
using Microsoft.Extensions.DependencyInjection;

namespace ImobFeed.Html;

public static class DependencyInjectionExtensions
{
    public static IServiceCollection AdicionarImobFeedHtml(this IServiceCollection services)
    {
        // Analise
        services
            .AddSingleton<IndicacoesFavoritasHtml>();

        // Referencia
        services
            .AddSingleton<IFonteReferenciaAtivos, BuscadorFonteReferenciaAtivos>();

        return services;
    }
}