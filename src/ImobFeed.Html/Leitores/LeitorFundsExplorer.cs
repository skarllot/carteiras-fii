using HtmlAgilityPack;
using ImobFeed.Core.Common;
using ImobFeed.Html.Leitores.Modelos;

namespace ImobFeed.Html.Leitores;

public static class LeitorFundsExplorer
{
    public static IEnumerable<FundsExplorerAtivo> LerListaAtivos()
    {
        var web = new HtmlWeb();
        var doc = web.Load(UrlReferencia.FundsExplorerListaUrl);

        var containerCards = doc.DocumentNode
            .SelectNodes("//div[@class=\"tickerFilter__results\"]//div[@data-element=\"content-list-ticker\"]");

        foreach (var card in containerCards)
        {
            string codigo = card.Descendants("div").First(it => it.HasClass("tickerBox__title")).InnerText.Trim();
            string nome = card.Descendants("div").First(it => it.HasClass("tickerBox__desc")).InnerText.Trim();
            string? administrador =
                card.Descendants("div").FirstOrDefault(it => it.HasClass("tickerBox__admin"))?.InnerText.Trim();

            yield return new FundsExplorerAtivo(
                codigo,
                nome,
                administrador);
        }
    }

    public static IEnumerable<FundsExplorerIndicadorAtivo> LerRanking()
    {
        var web = new HtmlWeb();
        var doc = web.Load(UrlReferencia.FundsExplorerRankingUrl);

        var tableRows = doc.DocumentNode
            .SelectNodes("//table[@id=\"table-ranking\"]//tbody/tr");

        foreach (var row in tableRows)
        {
            var cells = row.Descendants("td").ToList();
            string codigo = cells[0].ChildNodes["a"].InnerText.Trim();
            string setor = cells[1].InnerText.Trim();

            decimal? precoAtual = PtBrNumberParser.TryDecimal(cells[2].InnerText.AsSpan().Trim().Slice(2));
            decimal? liquidez = PtBrNumberParser.TryDecimal(cells[3].InnerText.AsSpan().Trim());
            decimal dividendo = PtBrNumberParser.Decimal(cells[4].InnerText.AsSpan().Trim().Slice(2));
            decimal? dy1Mes = PtBrNumberParser.TryDecimal(cells[5].InnerText.AsSpan().Trim()[..^1]);
            decimal? dy3Meses = PtBrNumberParser.TryDecimal(cells[6].InnerText.AsSpan().Trim()[..^1]);
            decimal? dy6Meses = PtBrNumberParser.TryDecimal(cells[7].InnerText.AsSpan().Trim()[..^1]);
            decimal? dy12Meses = PtBrNumberParser.TryDecimal(cells[8].InnerText.AsSpan().Trim()[..^1]);
            decimal? patrimonio = PtBrNumberParser.TryDecimal(cells[16].InnerText.AsSpan().Trim().Slice(2));
            decimal? vpa = PtBrNumberParser.TryDecimal(cells[17].InnerText.AsSpan().Trim().Slice(2));
            decimal? pVpa = PtBrNumberParser.TryDecimal(cells[18].InnerText.AsSpan().Trim());
            decimal? vacanciaFisica = PtBrNumberParser.TryDecimal(cells[23].InnerText.AsSpan().Trim()[..^1]);
            decimal? vacanciaFinanceira = PtBrNumberParser.TryDecimal(cells[24].InnerText.AsSpan().Trim()[..^1]);
            int qtdAtivos = PtBrNumberParser.Int32(cells[25].InnerText.AsSpan().Trim());

            yield return new FundsExplorerIndicadorAtivo(
                codigo,
                setor,
                precoAtual,
                liquidez,
                dividendo,
                dy1Mes / 100m,
                dy3Meses / 100m,
                dy6Meses / 100m,
                dy12Meses / 100m,
                patrimonio,
                vpa,
                pVpa,
                vacanciaFisica / 100m,
                vacanciaFinanceira / 100m,
                qtdAtivos);
        }
    }
}