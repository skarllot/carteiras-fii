using System.Globalization;
using HtmlAgilityPack;
using ImobFeed.Core.Common;
using ImobFeed.Html.Leitores.Modelos;

namespace ImobFeed.Html.Leitores;

public static class LeitorFundsExplorer
{
    public const string ListaUrl = "https://www.fundsexplorer.com.br/funds";
    public const string RankingUrl = "https://www.fundsexplorer.com.br/ranking";

    public static IEnumerable<FundsExplorerAtivo> LerListaAtivos()
    {
        var web = new HtmlWeb();
        var doc = web.Load(ListaUrl);

        var containerCards = doc.DocumentNode
            .SelectNodes("//section[@id=\"fiis-list\"]//div[@id=\"fiis-list-container\"]//div[@class=\"fund-card\"]");

        foreach (var card in containerCards)
        {
            string codigo = card.Descendants("span").First(it => it.HasClass("symbol")).InnerText.Trim();
            string nome = card.Descendants("span").First(it => it.HasClass("name")).InnerText.Trim();
            string? administrador =
                card.Descendants("span").FirstOrDefault(it => it.HasClass("admin"))?.InnerText.Trim();

            yield return new FundsExplorerAtivo(
                codigo,
                nome,
                administrador);
        }
    }

    public static IEnumerable<FundsExplorerIndicadorAtivo> LerRanking()
    {
        var web = new HtmlWeb();
        var doc = web.Load(RankingUrl);

        var tableRows = doc.DocumentNode
            .SelectNodes("//table[@id=\"table-ranking\"]//tbody/tr");

        foreach (var row in tableRows)
        {
            var cells = row.Descendants("td").ToList();
            string codigo = cells[0].ChildNodes["a"].InnerText.Trim();
            string setor = cells[1].InnerText.Trim();

            bool temPrecoAtual = decimal.TryParse(
                cells[2].InnerText.AsSpan().Trim().Slice(2),
                NumberStyles.Float,
                CultureCache.PortuguesBrasil,
                out decimal precoAtual);

            bool temLiquidez = decimal.TryParse(
                cells[3].InnerText.AsSpan().Trim(),
                NumberStyles.Float,
                CultureInfo.InvariantCulture,
                out decimal liquidez);

            decimal dividendo = decimal.Parse(
                cells[4].InnerText.AsSpan().Trim().Slice(2),
                provider: CultureCache.PortuguesBrasil);

            bool temDY1Mes = decimal.TryParse(
                cells[5].InnerText.AsSpan().Trim()[..^1],
                NumberStyles.Float,
                CultureCache.PortuguesBrasil,
                out decimal dy1Mes);

            bool temDY3Meses = decimal.TryParse(
                cells[6].InnerText.AsSpan().Trim()[..^1],
                NumberStyles.Float,
                CultureCache.PortuguesBrasil,
                out decimal dy3Meses);

            bool temDY6Meses = decimal.TryParse(
                cells[7].InnerText.AsSpan().Trim()[..^1],
                NumberStyles.Float,
                CultureCache.PortuguesBrasil,
                out decimal dy6Meses);

            bool temDY12Meses = decimal.TryParse(
                cells[8].InnerText.AsSpan().Trim()[..^1],
                NumberStyles.Float,
                CultureCache.PortuguesBrasil,
                out decimal dy12Meses);

            decimal patrimonio = decimal.Parse(
                cells[16].InnerText.AsSpan().Trim().Slice(2),
                provider: CultureCache.PortuguesBrasil);

            decimal vpa = decimal.Parse(
                cells[17].InnerText.AsSpan().Trim().Slice(2),
                provider: CultureCache.PortuguesBrasil);

            bool temPVpa = decimal.TryParse(
                cells[18].InnerText.AsSpan().Trim(),
                NumberStyles.Float,
                CultureCache.PortuguesBrasil,
                out decimal pVpa);

            bool temVacanciaFisica = decimal.TryParse(
                cells[23].InnerText.AsSpan().Trim()[..^1],
                NumberStyles.Float,
                CultureCache.PortuguesBrasil,
                out decimal vacanciaFisica);

            bool temVacanciaFinanceira = decimal.TryParse(
                cells[24].InnerText.AsSpan().Trim()[..^1],
                NumberStyles.Float,
                CultureCache.PortuguesBrasil,
                out decimal vacanciaFinanceira);

            int qtdAtivos = int.Parse(
                cells[25].InnerText.AsSpan().Trim(),
                provider: CultureCache.PortuguesBrasil);

            yield return new FundsExplorerIndicadorAtivo(
                codigo,
                setor,
                temPrecoAtual ? precoAtual : null,
                temLiquidez ? liquidez : null,
                dividendo,
                temDY1Mes ? dy1Mes / 100m : null,
                temDY3Meses ? dy3Meses / 100m : null,
                temDY6Meses ? dy6Meses / 100m : null,
                temDY12Meses ? dy12Meses / 100m : null,
                patrimonio,
                vpa,
                temPVpa ? pVpa : null,
                temVacanciaFisica ? vacanciaFisica / 100m : null,
                temVacanciaFinanceira ? vacanciaFinanceira / 100m : null,
                qtdAtivos);
        }
    }
}