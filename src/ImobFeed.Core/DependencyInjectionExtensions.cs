using ImobFeed.Core.Analise;
using Microsoft.Extensions.DependencyInjection;

namespace ImobFeed.Core;

public static class DependencyInjectionExtensions
{
    public static IServiceCollection AdicionarImobFeedCore(this IServiceCollection services)
    {
        // Raiz
        services
            .AddSingleton<DefaultAppConfiguration>()
            .AddSingletonFromExisting<IAppConfiguration, DefaultAppConfiguration>();

        // Analise
        services
            .AddSingleton<CalculadoraIndicacoesFavoritas>();

        return services;
    }

    public static IServiceCollection AddSingletonFromExisting<TService, TImplementation>(this IServiceCollection services)
        where TService : class
        where TImplementation : class, TService
    {
        return services.AddSingleton<TService>(static provider => provider.GetRequiredService<TImplementation>());
    }
}