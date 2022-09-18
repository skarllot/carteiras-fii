namespace ImobFeed.Core.Referencia.LeitoresHtml;

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
    decimal PatrimonioLiquido,
    decimal Vpa,
    decimal? PVpa,
    decimal? VacanciaFisica,
    decimal? VacanciaFinanceira,
    int QuantidadeAtivos)
{
    public int TotalCotas => (int) Math.Round(PatrimonioLiquido / Vpa, 0);
}