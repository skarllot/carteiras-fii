using System.Collections.Immutable;

namespace ImobFeed.Core.Analise;

public sealed record ListaIndicacoesFavoritas(int Ano, int Mes, ImmutableArray<IndicacaoFavorita> Indicacoes);