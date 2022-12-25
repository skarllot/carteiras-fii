using ImobFeed.Core.Referencia;
using ImobFeed.Html.Analise;
using ImobFeed.Html.Referencia;
using Jab;

namespace ImobFeed.Html;

[ServiceProviderModule]

// Analise
[Singleton(typeof(IndicacoesFavoritasHtml))]

// Referencia
[Singleton(typeof(IFonteReferenciaAtivos), typeof(BuscadorFonteReferenciaAtivos))]
public interface IHtmlContainerModule
{
}