using ImobFeed.Core.Analise;
using Jab;

namespace ImobFeed.Core;

[ServiceProviderModule]

// Raiz
[Singleton(typeof(DefaultAppConfiguration))]
[Transient(typeof(IAppConfigurationManager), Factory = nameof(CreateAppConfigurationManager))]
[Transient(typeof(IAppConfiguration), Factory = nameof(CreateAppConfiguration))]

// Analise
[Singleton(typeof(CalculadoraIndicacoesFavoritas))]
public interface ICoreContainerModule
{
    public static IAppConfigurationManager CreateAppConfigurationManager(DefaultAppConfiguration configuration) =>
        configuration;

    public static IAppConfiguration CreateAppConfiguration(DefaultAppConfiguration configuration) =>
        configuration;
}