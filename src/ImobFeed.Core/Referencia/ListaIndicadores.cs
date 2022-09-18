using System.Collections.Immutable;
using ImobFeed.Core.CarteiraMensal;

namespace ImobFeed.Core.Referencia;

public sealed record ListaIndicadores(DateTimeOffset UltimaAtualizacao, ImmutableArray<IndicadorAtivo> Indicadores);