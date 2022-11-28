using System.Collections.Immutable;
using ImobFeed.Core.CarteiraMensal;

namespace ImobFeed.Core.Referencia.Modelos;

public sealed record ListaIndicadores(DateTimeOffset UltimaAtualizacao, ImmutableArray<IndicadorAtivo> Indicadores)
{
    public IReadOnlyDictionary<string, IndicadorAtivo> ToDictionary()
    {
        return Indicadores.IsDefaultOrEmpty is false
            ? Indicadores.ToDictionary(it => it.Codigo, StringComparer.OrdinalIgnoreCase)
            : new Dictionary<string, IndicadorAtivo>();
    }
}