namespace ImobFeed.Html.Leitores.Modelos;

public sealed record FundsExplorerIndicadorAtivo(
    string Codigo,
    string Setor,
    decimal? PrecoAtual,
    decimal? LiquidezDiaAnterior,
    decimal UltimoDividendo,
    decimal? DY1Mes,
    decimal? DY3Meses,
    decimal? DY6Meses,
    decimal? DY12Meses,
    decimal? PatrimonioLiquido,
    decimal? Vpa,
    decimal? PVpa,
    decimal? VacanciaFisica,
    decimal? VacanciaFinanceira,
    int QuantidadeAtivos)
{
    public int? TotalCotas => PatrimonioLiquido is not null && Vpa is not null
        ? (int)Math.Round(PatrimonioLiquido.Value / Vpa.Value, 0)
        : null;
}