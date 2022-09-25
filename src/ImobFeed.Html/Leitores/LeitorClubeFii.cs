using System.Globalization;
using HtmlAgilityPack;
using ImobFeed.Core.Common;
using ImobFeed.Html.Leitores.Modelos;

namespace ImobFeed.Html.Leitores;

public static class LeitorClubeFii
{
    public const string ListaUrl = "https://clubefii.com.br/fundo_imobiliario_lista#";
    public const string RankingUrl = "https://clubefii.com.br/fundos_imobiliarios_ranking";

    public static IEnumerable<ClubeFiiAtivo> LerListaAtivos()
    {
        var web = new HtmlWeb();
        var doc = web.Load(ListaUrl);

        var tableRows = doc.DocumentNode
            .SelectNodes("//div[@id=\"fundos_listados\"]//table//tr[@class=\"tabela_principal\"]");

        foreach (var row in tableRows.Skip(1))
        {
            var cells = row.Descendants("td").ToList();
            string codigo = cells[0].ChildNodes["a"].InnerText.Trim();
            string nome = cells[1].ChildNodes["a"].InnerText.Trim();

            var valorCotaNode = cells[2].Descendants("span").FirstOrDefault(it => it.Id == "valor_atual_cota");
            decimal? valorCota = valorCotaNode is not null
                ? decimal.Parse(valorCotaNode.InnerText, CultureCache.PortuguesBrasil)
                : null;

            DateTimeOffset? dataCotacao = valorCota.HasValue
                ? DateTimeOffset.ParseExact(
                    cells[2].Descendants("span").First(it => it.Id == "data_cotacao").InnerText.AsSpan().Trim(),
                    "dd/MM/yyyy HH:mm:ss",
                    CultureCache.PortuguesBrasil)
                : null;

            bool temDataIpo = DateOnly.TryParseExact(
                cells[3].ChildNodes["a"].InnerText.AsSpan().Trim(),
                "dd/MM/yyyy",
                out var dataIpo);

            decimal? valorIpo = temDataIpo
                ? decimal.Parse(
                    cells[4].ChildNodes["a"].InnerText.AsSpan().Trim().Slice(2),
                    provider: CultureCache.PortuguesBrasil)
                : null;

            string segmento = cells[5].ChildNodes["a"].InnerText.Trim();
            string administrador = cells[6].ChildNodes["a"].InnerText.Trim();

            yield return new ClubeFiiAtivo(
                codigo,
                nome,
                valorCota,
                dataCotacao,
                temDataIpo ? dataIpo : null,
                valorIpo,
                segmento,
                administrador);
        }
    }

    public static IEnumerable<ClubeFiiIndicadorAtivo> LerRanking()
    {
        var web = new HtmlWeb();
        var doc = web.Load(RankingUrl);

        var tableRows = doc.DocumentNode
            .SelectNodes("//div[@id=\"fundos_listados\"]//table//tr[@class=\"tabela_principal\"]");

        foreach (var row in tableRows.Skip(1))
        {
            var cells = row.Descendants("td").ToList();
            string codigo = cells[0].ChildNodes["a"].InnerText.Trim();

            decimal pVpa = decimal.Parse(
                cells[4].ChildNodes["a"].InnerText.AsSpan().Trim(),
                provider: CultureCache.PortuguesBrasil);

            decimal yield1Mes = decimal.Parse(
                cells[5].ChildNodes["a"].InnerText.AsSpan().Trim()[..^1],
                provider: CultureCache.PortuguesBrasil);

            bool temYield12Mes = decimal.TryParse(
                cells[6].ChildNodes["a"].InnerText.AsSpan().Trim()[..^1],
                NumberStyles.Float,
                CultureCache.PortuguesBrasil,
                out decimal yield12Mes);

            yield return new ClubeFiiIndicadorAtivo(
                codigo,
                pVpa,
                yield1Mes / 100m,
                temYield12Mes ? yield12Mes / 100m : null);
        }
    }
}