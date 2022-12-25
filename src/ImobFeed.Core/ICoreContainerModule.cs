using ImobFeed.Core.Analise;
using Jab;

namespace ImobFeed.Core;

[ServiceProviderModule]

// Raiz
[Singleton(typeof(DefaultAppConfiguration))]

// Analise
[Singleton(typeof(CalculadoraIndicacoesFavoritas))]
public interface ICoreContainerModule
{
}