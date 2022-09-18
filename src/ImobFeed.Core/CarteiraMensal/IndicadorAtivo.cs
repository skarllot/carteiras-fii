namespace ImobFeed.Core.CarteiraMensal;

public sealed record IndicadorAtivo(
    string Codigo,
    decimal? PatrimonioLiquido,
    int? TotalCotas,
    decimal? Vpa,
    decimal? PrecoAtual,
    decimal? PVpa,
    decimal? Yield1Mes,
    decimal? Yield3Mes,
    decimal? Yield6Mes,
    decimal? Yield12Meses,
    decimal? LiquidezDiaAnterior,
    decimal? UltimoDividendo,
    decimal? VacanciaFisica,
    decimal? VacanciaFinanceira,
    int? QuantidadeAtivos);