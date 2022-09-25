using System.Collections.Immutable;

namespace ImobFeed.Core.Analise.Modelos;

public sealed record ListaIndicacoesFavoritas(int Ano, int Mes, ImmutableArray<IndicacaoFavorita> Indicacoes);