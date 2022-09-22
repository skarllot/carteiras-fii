using System.Collections.Immutable;

namespace ImobFeed.Core.Analise;

public sealed record IndicacaoFavorita(
    string Codigo,
    string Nome,
    string Segmento,
    string Administrador,
    decimal? Vpa,
    decimal? PVpa,
    decimal? Yield1Mes,
    decimal? Yield12Meses,
    decimal Peso,
    ImmutableArray<string> Corretoras);