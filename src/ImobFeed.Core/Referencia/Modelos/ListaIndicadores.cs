using System.Collections.Immutable;
using ImobFeed.Core.CarteiraMensal;

namespace ImobFeed.Core.Referencia.Modelos;

public sealed record ListaIndicadores(DateTimeOffset UltimaAtualizacao, ImmutableArray<IndicadorAtivo> Indicadores);