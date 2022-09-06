using NodaTime;

namespace ImobFeed.Core.CarteiraMensal;

public static class AtivosClubeFii
{
    // 2022-09-04
    private static readonly Dictionary<string, Ativo> DicionarioAtivos = new(StringComparer.OrdinalIgnoreCase)
    {
        {
            "ABCP11",
            new(
                "ABCP11",
                "Grand Plaza Shopping",
                LocalDate.FromDateTime(new DateTime(2004, 3, 12)),
                18.50M,
                Segmentos.BuscaSegmento("Agencias Bancárias"),
                "Rio Bravo")
        },
        {
            "AFHI11",
            new(
                "AFHI11",
                "AF Invest CRI",
                LocalDate.FromDateTime(new DateTime(2021, 4, 5)),
                100.00M,
                Segmentos.BuscaSegmento("Agencias Bancárias"),
                "BTG Pactual")
        },
        {
            "AFOF11",
            new(
                "AFOF11",
                "Alianza FOF",
                LocalDate.FromDateTime(new DateTime(2021, 3, 23)),
                100.00M,
                Segmentos.BuscaSegmento("Agencias Bancárias"),
                "BRL Trust")
        },
        {
            "AGRX11",
            new(
                "AGRX11",
                "Exes Araguaia Fiagro",
                LocalDate.FromDateTime(new DateTime(2022, 8, 4)),
                10.00M,
                Segmentos.BuscaSegmento("Agencias Bancárias"),
                "Banco Genial")
        },
        {
            "AIEC11",
            new(
                "AIEC11",
                "Autonomy Edifícios Corporativos",
                LocalDate.FromDateTime(new DateTime(2020, 9, 2)),
                100.00M,
                Segmentos.BuscaSegmento("Agencias Bancárias"),
                "MAF")
        },
        {
            "ALMI11",
            new(
                "ALMI11",
                "Torre Almirante",
                LocalDate.FromDateTime(new DateTime(2005, 6, 1)),
                1_000.00M,
                Segmentos.BuscaSegmento("Agencias Bancárias"),
                "BTG Pactual")
        },
        {
            "ALZC11",
            new(
                "ALZC11",
                "Alianza Crédito Imobiliário",
                null,
                null,
                Segmentos.BuscaSegmento("Agencias Bancárias"),
                "BTG Pactual")
        },
        {
            "ALZR11",
            new(
                "ALZR11",
                "Alianza Trust Renda Imobiliária",
                LocalDate.FromDateTime(new DateTime(2018, 1, 4)),
                100.00M,
                Segmentos.BuscaSegmento("Agronegócio"),
                "N/D")
        },
        {
            "ANCR11B",
            new(
                "ANCR11B",
                "Ancar IC",
                LocalDate.FromDateTime(new DateTime(2007, 8, 15)),
                600.00M,
                Segmentos.BuscaSegmento("Agronegócio"),
                "Genial Investimentos")
        },
        {
            "APTO11", new("APTO11", "Navi Residencial", null, null, Segmentos.BuscaSegmento("Agronegócio"), "BRL Trust")
        },
        {
            "AQLL11",
            new(
                "AQLL11",
                "Áquilla",
                LocalDate.FromDateTime(new DateTime(2012, 6, 20)),
                1_000.00M,
                Segmentos.BuscaSegmento("Agronegócio"),
                "Índigo Investimentos")
        },
        {
            "ARCT11",
            new(
                "ARCT11",
                "Riza Arctium Real Estate",
                LocalDate.FromDateTime(new DateTime(2019, 9, 9)),
                100.00M,
                Segmentos.BuscaSegmento("Agronegócio"),
                "BTG Pactual")
        },
        {
            "ARFI11B",
            new(
                "ARFI11B",
                "AQ3 Renda",
                LocalDate.FromDateTime(new DateTime(2013, 3, 1)),
                1_000.00M,
                Segmentos.BuscaSegmento("Agronegócio"),
                "Índigo Investimentos")
        },
        {
            "ARRI11",
            new(
                "ARRI11",
                "Átrio Reit Recebíveis Imobiliários",
                LocalDate.FromDateTime(new DateTime(2019, 10, 31)),
                100.00M,
                Segmentos.BuscaSegmento("Agronegócio"),
                "Oliveira Trust")
        },
        {
            "ASMT11",
            new(
                "ASMT11",
                "ASA Metropolis",
                LocalDate.FromDateTime(new DateTime(2021, 2, 26)),
                100.00M,
                Segmentos.BuscaSegmento("Agronegócio"),
                "BTG Pactual")
        },
        {
            "ATCR11",
            new(
                "ATCR11",
                "HAZ FII",
                LocalDate.FromDateTime(new DateTime(2013, 9, 18)),
                100.00M,
                Segmentos.BuscaSegmento("Agronegócio"),
                "RJI")
        },
        {
            "ATSA11",
            new(
                "ATSA11",
                "Hedge Atrium Shopping Santo André",
                LocalDate.FromDateTime(new DateTime(2010, 12, 13)),
                1_000.00M,
                Segmentos.BuscaSegmento("Agronegócio"),
                "Hedge Investments")
        },
        { "ATWN11", new("ATWN11", "Airport Town", null, null, Segmentos.BuscaSegmento("Agronegócio"), "Reag") },
        {
            "AURB11",
            new("AURB11", "Alianza Urban Hub Renda", null, null, Segmentos.BuscaSegmento("Agronegócio"), "BTG Pactual")
        },
        {
            "BARI11",
            new(
                "BARI11",
                "Barigui Rendimentos",
                LocalDate.FromDateTime(new DateTime(2019, 6, 21)),
                100.00M,
                Segmentos.BuscaSegmento("Agronegócio"),
                "Oliveira Trust")
        },
        {
            "BBFI11B",
            new(
                "BBFI11B",
                "BB Progressivo",
                LocalDate.FromDateTime(new DateTime(2004, 12, 1)),
                1_000.00M,
                Segmentos.BuscaSegmento("Agronegócio"),
                "BTG Pactual")
        },
        {
            "BBFO11",
            new(
                "BBFO11",
                "BB Fundo de Fundos",
                LocalDate.FromDateTime(new DateTime(2020, 12, 28)),
                100.00M,
                Segmentos.BuscaSegmento("Agronegócio"),
                "BB Gestao De Recursos")
        },
        {
            "BBGO11",
            new(
                "BBGO11",
                "BB Crédito Fiagro",
                LocalDate.FromDateTime(new DateTime(2022, 2, 1)),
                100.00M,
                Segmentos.BuscaSegmento("Agronegócio"),
                "BB Gestao De Recursos")
        },
        {
            "BBIM11",
            new(
                "BBIM11",
                "BB Recebíveis Imobiliários",
                LocalDate.FromDateTime(new DateTime(2015, 9, 1)),
                100.00M,
                Segmentos.BuscaSegmento("Agronegócio"),
                "BB Gestao De Recursos")
        },
        {
            "BBPO11",
            new(
                "BBPO11",
                "BB Progressivo II",
                LocalDate.FromDateTime(new DateTime(2012, 12, 12)),
                100.00M,
                Segmentos.BuscaSegmento("Agronegócio"),
                "Votorantim Asset")
        },
        {
            "BBRC11",
            new(
                "BBRC11",
                "BB Renda Corporativa",
                LocalDate.FromDateTime(new DateTime(2011, 6, 20)),
                100.00M,
                Segmentos.BuscaSegmento("Agronegócio"),
                "BV DTVM")
        },
        {
            "BCFF11",
            new(
                "BCFF11",
                "BTG Pactual Fundo de Fundos",
                LocalDate.FromDateTime(new DateTime(2010, 6, 17)),
                100.00M,
                Segmentos.BuscaSegmento("Agronegócio"),
                "BTG Pactual")
        },
        {
            "BCIA11",
            new(
                "BCIA11",
                "Bradesco Carteira Imobiliária Ativa",
                LocalDate.FromDateTime(new DateTime(2015, 5, 25)),
                100.00M,
                Segmentos.BuscaSegmento("Agronegócio"),
                "Banco Bradesco")
        },
        {
            "BCRI11",
            new(
                "BCRI11",
                "Banestes Recebíveis Imobiliários",
                LocalDate.FromDateTime(new DateTime(2015, 7, 1)),
                100.00M,
                Segmentos.BuscaSegmento("Agronegócio"),
                "BRL Trust")
        },
        {
            "BDIF11",
            new(
                "BDIF11",
                "BTG Pactual Dívida FI-Infra",
                LocalDate.FromDateTime(new DateTime(2021, 4, 5)),
                100.00M,
                Segmentos.BuscaSegmento("Agronegócio"),
                "BTG Pactual")
        },
        {
            "BICE11",
            new("BICE11", "Brio Crédito Estruturado", null, null, Segmentos.BuscaSegmento("Agronegócio"), "BRL Trust")
        },
        {
            "BICR11",
            new(
                "BICR11",
                "Inter Títulos Imobiliários",
                LocalDate.FromDateTime(new DateTime(2019, 12, 26)),
                100.00M,
                Segmentos.BuscaSegmento("Educacional"),
                "Inter DTVM")
        },
        { "BIDB11", new("BIDB11", "Inter FI-Infra", null, null, Segmentos.BuscaSegmento("Educacional"), "Inter DTVM") },
        {
            "BIME11",
            new(
                "BIME11",
                "Brio Multiestratégia",
                LocalDate.FromDateTime(new DateTime(2021, 11, 1)),
                10.00M,
                Segmentos.BuscaSegmento("Educacional"),
                "BRL Trust")
        },
        {
            "BJRC11",
            new(
                "BJRC11",
                "JS Real Estate Recebíveis Imobiliários",
                LocalDate.FromDateTime(new DateTime(2012, 10, 22)),
                1_000.00M,
                Segmentos.BuscaSegmento("Educacional"),
                "Banco J. Safra")
        },
        {
            "BLCA11",
            new(
                "BLCA11",
                "BlueMacaw Catuaí Triple A",
                null,
                null,
                Segmentos.BuscaSegmento("Fundo de Fundos"),
                "BTG Pactual")
        },
        {
            "BLCP11",
            new(
                "BLCP11",
                "Bluecap Renda Logística",
                LocalDate.FromDateTime(new DateTime(2020, 5, 25)),
                100.00M,
                Segmentos.BuscaSegmento("Fundo de Fundos"),
                "BTG Pactual")
        },
        {
            "BLMC11",
            new(
                "BLMC11",
                "BlueMacaw Crédito Imobiliário",
                LocalDate.FromDateTime(new DateTime(2021, 2, 5)),
                100.00M,
                Segmentos.BuscaSegmento("Fundo de Fundos"),
                "BTG Pactual")
        },
        {
            "BLMG11",
            new(
                "BLMG11",
                "BlueMacaw Logística",
                LocalDate.FromDateTime(new DateTime(2020, 10, 30)),
                100.00M,
                Segmentos.BuscaSegmento("Fundo de Fundos"),
                "Vórtx")
        },
        {
            "BLMO11",
            new(
                "BLMO11",
                "BlueMacaw Office Fund II",
                LocalDate.FromDateTime(new DateTime(2020, 4, 3)),
                25_000.00M,
                Segmentos.BuscaSegmento("Fundo de Fundos"),
                "BRL Trust")
        },
        {
            "BLMR11",
            new(
                "BLMR11",
                "BlueMacaw Renda + FOF",
                LocalDate.FromDateTime(new DateTime(2020, 8, 13)),
                10.00M,
                Segmentos.BuscaSegmento("Fundo de Fundos"),
                "BRL Trust")
        },
        {
            "BLUR11",
            new(
                "BLUR11",
                "Blue Recebíveis Imobiliários",
                LocalDate.FromDateTime(new DateTime(2022, 3, 23)),
                0.00M,
                Segmentos.BuscaSegmento("Fundo de Fundos"),
                "Banco Daycoval")
        },
        {
            "BMII11",
            new(
                "BMII11",
                "Brasílio Machado",
                LocalDate.FromDateTime(new DateTime(2010, 9, 23)),
                1.00M,
                Segmentos.BuscaSegmento("Fundo de Fundos"),
                "Rio Bravo")
        },
        {
            "BMLC11",
            new(
                "BMLC11",
                "BM Brascan Lajes Corporativas",
                LocalDate.FromDateTime(new DateTime(2012, 2, 14)),
                100.00M,
                Segmentos.BuscaSegmento("Fundo de Fundos"),
                "BTG Pactual")
        },
        {
            "BNFS11",
            new(
                "BNFS11",
                "Banrisul Novas Fronteiras",
                LocalDate.FromDateTime(new DateTime(2012, 9, 25)),
                100.00M,
                Segmentos.BuscaSegmento("Fundo de Fundos"),
                "Oliveira Trust")
        },
        {
            "BODB11",
            new(
                "BODB11",
                "Bocaina FI-Infra",
                LocalDate.FromDateTime(new DateTime(2022, 5, 3)),
                10.46M,
                Segmentos.BuscaSegmento("Fundo de Fundos"),
                "BTG Pactual")
        },
        {
            "BPFF11",
            new(
                "BPFF11",
                "Brasil Plural Absoluto Fundo de Fundos",
                LocalDate.FromDateTime(new DateTime(2013, 4, 15)),
                100.00M,
                Segmentos.BuscaSegmento("Fundo de Fundos"),
                "Genial Investimentos")
        },
        {
            "BPMA11",
            new("BPMA11", "Brio Prime Malls", null, null, Segmentos.BuscaSegmento("Fundo de Fundos"), "BRL Trust")
        },
        {
            "BPML11",
            new(
                "BPML11",
                "BTG Pactual Shoppings",
                LocalDate.FromDateTime(new DateTime(2019, 7, 26)),
                100.00M,
                Segmentos.BuscaSegmento("Fundo de Fundos"),
                "BTG Pactual")
        },
        {
            "BPRP11",
            new(
                "BPRP11",
                "BRLPROP",
                LocalDate.FromDateTime(new DateTime(2019, 8, 28)),
                100.00M,
                Segmentos.BuscaSegmento("Fundo de Fundos"),
                "BTG Pactual")
        },
        {
            "BRCO11",
            new(
                "BRCO11",
                "Bresco Logística",
                LocalDate.FromDateTime(new DateTime(2019, 12, 5)),
                100.00M,
                Segmentos.BuscaSegmento("Fundo de Fundos"),
                "Oliveira Trust")
        },
        {
            "BRCR11",
            new(
                "BRCR11",
                "BTG Pactual Corporate Office Fund",
                LocalDate.FromDateTime(new DateTime(2010, 12, 1)),
                100.00M,
                Segmentos.BuscaSegmento("Fundo de Fundos"),
                "BTG Pactual")
        },
        {
            "BREV11",
            new(
                "BREV11",
                "Brazil Real Estate Victory Fund I",
                LocalDate.FromDateTime(new DateTime(2020, 1, 21)),
                100.00M,
                Segmentos.BuscaSegmento("Fundo de Fundos"),
                "Br-Capital")
        },
        {
            "BRHT11B",
            new(
                "BRHT11B",
                "BR Hoteis",
                LocalDate.FromDateTime(new DateTime(2013, 7, 22)),
                100.00M,
                Segmentos.BuscaSegmento("Fundo de Fundos"),
                "Elite CCVM")
        },
        {
            "BRIM11",
            new(
                "BRIM11",
                "Brio Real Estate II",
                LocalDate.FromDateTime(new DateTime(2020, 7, 15)),
                1_000.00M,
                Segmentos.BuscaSegmento("Fundo de Fundos"),
                "BRL Trust")
        },
        {
            "BRIP11",
            new(
                "BRIP11",
                "Brio Real Estate III",
                LocalDate.FromDateTime(new DateTime(2020, 10, 16)),
                1_000.00M,
                Segmentos.BuscaSegmento("Fundo de Fundos"),
                "BRL Trust")
        },
        {
            "BRLA11",
            new(
                "BRLA11",
                "BRL Prop II",
                LocalDate.FromDateTime(new DateTime(2020, 9, 9)),
                100.00M,
                Segmentos.BuscaSegmento("Fundo de Fundos"),
                "BTG Pactual")
        },
        {
            "BTAL11",
            new(
                "BTAL11",
                "BTG Pactual Agro Logística",
                LocalDate.FromDateTime(new DateTime(2021, 1, 29)),
                100.00M,
                Segmentos.BuscaSegmento("Fundo de Fundos"),
                "BTG Pactual")
        },
        {
            "BTCR11",
            new(
                "BTCR11",
                "BTG Pactual Crédito Imobiliário",
                LocalDate.FromDateTime(new DateTime(2018, 5, 31)),
                100.00M,
                Segmentos.BuscaSegmento("Fundo de Fundos"),
                "Null")
        },
        {
            "BTLG11",
            new(
                "BTLG11",
                "BTG Pactual Logística",
                LocalDate.FromDateTime(new DateTime(2010, 8, 12)),
                100.00M,
                Segmentos.BuscaSegmento("Fundo de Fundos"),
                "Null")
        },
        {
            "BTRA11",
            new(
                "BTRA11",
                "BTG Pactual Terras Agrícolas",
                LocalDate.FromDateTime(new DateTime(2021, 7, 30)),
                100.00M,
                Segmentos.BuscaSegmento("Fundo de Fundos"),
                "BTG Pactual")
        },
        { "BTSG11", new("BTSG11", "BTSP I", null, null, Segmentos.BuscaSegmento("Fundo de Fundos"), "Inter DTVM") },
        { "BTSI11", new("BTSI11", "BTSP II", null, null, Segmentos.BuscaSegmento("Fundo de Fundos"), "Inter DTVM") },
        { "BTWR11", new("BTWR11", "BTowers", null, null, Segmentos.BuscaSegmento("Fundo de Fundos"), "BRL Trust") },
        {
            "BVAR11",
            new(
                "BVAR11",
                "Brasil Varejo",
                LocalDate.FromDateTime(new DateTime(2015, 4, 14)),
                100.00M,
                Segmentos.BuscaSegmento("Fundo de Fundos"),
                "Rio Bravo")
        },
        { "BZEL11", new("BZEL11", "Barzel", null, null, Segmentos.BuscaSegmento("Fundo de Fundos"), "BRL Trust") },
        {
            "BZLI11",
            new(
                "BZLI11",
                "Brazil Realty",
                LocalDate.FromDateTime(new DateTime(2017, 11, 30)),
                8.11M,
                Segmentos.BuscaSegmento("Fundo de Fundos"),
                "Planner")
        },
        {
            "CACR11",
            new(
                "CACR11",
                "Cartesia Recebíveis Imobiliários",
                LocalDate.FromDateTime(new DateTime(2020, 1, 24)),
                100.00M,
                Segmentos.BuscaSegmento("Fundo de Fundos"),
                "CM Capital Markets")
        },
        {
            "CARE11",
            new(
                "CARE11",
                "Brazilian GraveyardDeath Care",
                LocalDate.FromDateTime(new DateTime(2013, 3, 1)),
                5.00M,
                Segmentos.BuscaSegmento("Fundo de Fundos"),
                "Planner")
        },
        {
            "CBOP11",
            new(
                "CBOP11",
                "Castello Branco Office Park",
                LocalDate.FromDateTime(new DateTime(2014, 3, 5)),
                100.00M,
                Segmentos.BuscaSegmento("Fundo de Fundos"),
                "Credit Suisse")
        },
        {
            "CCRF11",
            new(
                "CCRF11",
                "RBR CRI",
                LocalDate.FromDateTime(new DateTime(2021, 5, 4)),
                100.00M,
                Segmentos.BuscaSegmento("Fundo de Fundos"),
                "BTG Pactual")
        },
        {
            "CEOC11",
            new(
                "CEOC11",
                "CEO Cyrela Commercial Properties",
                LocalDate.FromDateTime(new DateTime(2012, 10, 4)),
                100.00M,
                Segmentos.BuscaSegmento("Fundo de Fundos"),
                "BTG Pactual")
        },
        { "CFHI11", new("CFHI11", "CF2 FII", null, null, Segmentos.BuscaSegmento("Fundo de Fundos"), "Vórtx") },
        {
            "CJCT11",
            new(
                "CJCT11",
                "Cidade Jardim Continental Tower",
                LocalDate.FromDateTime(new DateTime(2010, 12, 30)),
                100.00M,
                Segmentos.BuscaSegmento("Fundo de Fundos"),
                "Hedge Investments")
        },
        { "CJFI11", new("CJFI11", "CJ FII", null, null, Segmentos.BuscaSegmento("Híbrido"), "BTG Pactual") },
        {
            "CNES11",
            new(
                "CNES11",
                "Cenesp",
                LocalDate.FromDateTime(new DateTime(2011, 8, 4)),
                100.00M,
                Segmentos.BuscaSegmento("Híbrido"),
                "BTG Pactual")
        },
        {
            "CPFF11",
            new(
                "CPFF11",
                "Capitânia REIT FOF",
                LocalDate.FromDateTime(new DateTime(2020, 1, 2)),
                100.00M,
                Segmentos.BuscaSegmento("Híbrido"),
                "BTG Pactual")
        },
        {
            "CPTI11", new("CPTI11", "Capitânia FI-Infra", null, null, Segmentos.BuscaSegmento("Híbrido"), "BTG Pactual")
        },
        {
            "CPTR11",
            new(
                "CPTR11",
                "Capitânia Agro Strategies Fiagro",
                null,
                null,
                Segmentos.BuscaSegmento("Híbrido"),
                "BTG Pactual")
        },
        {
            "CPTS11",
            new(
                "CPTS11",
                "Capitânia Securities II",
                LocalDate.FromDateTime(new DateTime(2014, 8, 28)),
                100.00M,
                Segmentos.BuscaSegmento("Híbrido"),
                "BTG Pactual")
        },
        {
            "CRFF11",
            new(
                "CRFF11",
                "Caixa Rio Bravo Fundo de Fundos II",
                LocalDate.FromDateTime(new DateTime(2019, 5, 17)),
                100.00M,
                Segmentos.BuscaSegmento("Híbrido"),
                "Caixa Economica Federal")
        },
        {
            "CTXT11",
            new(
                "CTXT11",
                "Centro Têxtil Internacional",
                LocalDate.FromDateTime(new DateTime(2012, 12, 12)),
                42.00M,
                Segmentos.BuscaSegmento("Híbrido"),
                "Rio Bravo")
        },
        {
            "CVBI11",
            new(
                "CVBI11",
                "VBI CRI",
                LocalDate.FromDateTime(new DateTime(2019, 9, 26)),
                100.00M,
                Segmentos.BuscaSegmento("Híbrido"),
                "BRL Trust")
        },
        {
            "CXAG11",
            new(
                "CXAG11",
                "Caixa Agencias",
                LocalDate.FromDateTime(new DateTime(2021, 12, 30)),
                103.70M,
                Segmentos.BuscaSegmento("Híbrido"),
                "Oliveira Trust")
        },
        {
            "CXCE11B",
            new(
                "CXCE11B",
                "Caixa Cedae",
                LocalDate.FromDateTime(new DateTime(2010, 3, 4)),
                1_000.00M,
                Segmentos.BuscaSegmento("Híbrido"),
                "Caixa Economica Federal")
        },
        {
            "CXCI11",
            new(
                "CXCI11",
                "Caixa Carteira Imobiliária",
                LocalDate.FromDateTime(new DateTime(2022, 3, 22)),
                100.00M,
                Segmentos.BuscaSegmento("Híbrido"),
                "Caixa Economica Federal")
        },
        {
            "CXCO11",
            new(
                "CXCO11",
                "Caixa Imóveis Corporativos",
                LocalDate.FromDateTime(new DateTime(2021, 3, 31)),
                102.89M,
                Segmentos.BuscaSegmento("Híbrido"),
                "Vórtx")
        },
        {
            "CXRI11",
            new(
                "CXRI11",
                "Caixa Rio Bravo Fundo de Fundos",
                LocalDate.FromDateTime(new DateTime(2013, 12, 12)),
                100.00M,
                Segmentos.BuscaSegmento("Híbrido"),
                "Caixa Economica Federal")
        },
        {
            "CXTL11",
            new(
                "CXTL11",
                "Caixa Seq Logística Renda",
                LocalDate.FromDateTime(new DateTime(2012, 1, 17)),
                1_000.00M,
                Segmentos.BuscaSegmento("Híbrido"),
                "Caixa Economica Federal")
        },
        {
            "CYCR11",
            new(
                "CYCR11",
                "Cyrela Crédito",
                LocalDate.FromDateTime(new DateTime(2021, 11, 23)),
                100.00M,
                Segmentos.BuscaSegmento("Híbrido"),
                "Banco Genial")
        },
        { "DAMT11B", new("DAMT11B", "Diamante", null, null, Segmentos.BuscaSegmento("Híbrido"), "BTG Pactual") },
        {
            "DCRA11",
            new(
                "DCRA11",
                "Devant Fiagro",
                LocalDate.FromDateTime(new DateTime(2022, 2, 8)),
                10.00M,
                Segmentos.BuscaSegmento("Híbrido"),
                "Banco Daycoval")
        },
        {
            "DEVA11",
            new(
                "DEVA11",
                "Devant Recebíveis Imobiliários",
                LocalDate.FromDateTime(new DateTime(2020, 8, 26)),
                100.00M,
                Segmentos.BuscaSegmento("Híbrido"),
                "Vórtx")
        },
        { "DLMT11", new("DLMT11", "Del Monte Ajax", null, null, Segmentos.BuscaSegmento("Híbrido"), "Planner") },
        {
            "DMAC11",
            new(
                "DMAC11",
                "MAC FII",
                LocalDate.FromDateTime(new DateTime(2018, 8, 31)),
                1_000.00M,
                Segmentos.BuscaSegmento("Híbrido"),
                "Oliveira Trust")
        },
        {
            "DOVL11B",
            new(
                "DOVL11B",
                "Dovel",
                LocalDate.FromDateTime(new DateTime(2008, 11, 28)),
                1_000.00M,
                Segmentos.BuscaSegmento("Híbrido"),
                "BRL Trust")
        },
        {
            "DPRO11",
            new("DPRO11", "Devant Properties", null, null, Segmentos.BuscaSegmento("Híbrido"), "Banco Daycoval")
        },
        {
            "DRIT11B",
            new(
                "DRIT11B",
                "Multigestão Renda Comercial",
                LocalDate.FromDateTime(new DateTime(2011, 7, 28)),
                100.00M,
                Segmentos.BuscaSegmento("Híbrido"),
                "Banco Daycoval")
        },
        {
            "DVFF11",
            new(
                "DVFF11",
                "Devant Fundo de Fundos",
                LocalDate.FromDateTime(new DateTime(2021, 7, 23)),
                100.00M,
                Segmentos.BuscaSegmento("Híbrido"),
                "Banco Daycoval")
        },
        {
            "EDFO11B",
            new(
                "EDFO11B",
                "Edifício Ourinvest",
                LocalDate.FromDateTime(new DateTime(2006, 1, 23)),
                100.00M,
                Segmentos.BuscaSegmento("Híbrido"),
                "Oliveira Trust")
        },
        {
            "EDGA11",
            new(
                "EDGA11",
                "Edifício Galeria",
                LocalDate.FromDateTime(new DateTime(2012, 9, 12)),
                100.00M,
                Segmentos.BuscaSegmento("Híbrido"),
                "BTG Pactual")
        },
        {
            "EGAF11",
            new(
                "EGAF11",
                "Ecoagro I Fiagro",
                LocalDate.FromDateTime(new DateTime(2022, 1, 28)),
                100.00M,
                Segmentos.BuscaSegmento("Hospital"),
                "Vórtx")
        },
        { "EGYR11", new("EGYR11", "Energy Resort", null, null, Segmentos.BuscaSegmento("Hospital"), "Reag") },
        {
            "ELDO11B",
            new(
                "ELDO11B",
                "Eldorado",
                LocalDate.FromDateTime(new DateTime(2010, 11, 16)),
                1_000.00M,
                Segmentos.BuscaSegmento("Hospital"),
                "Rio Bravo")
        },
        {
            "EQIR11",
            new(
                "EQIR11",
                "EQI Recebíveis Imobiliários",
                LocalDate.FromDateTime(new DateTime(2021, 11, 22)),
                100.00M,
                Segmentos.BuscaSegmento("Hospital"),
                "N/D")
        },
        {
            "ERCR11",
            new(
                "ERCR11",
                "Estoque Residencial e Comercial Rio de Janeiro",
                LocalDate.FromDateTime(new DateTime(2020, 12, 18)),
                100.00M,
                Segmentos.BuscaSegmento("Hospital"),
                "Oliveira Trust")
        },
        {
            "ERPA11",
            new(
                "ERPA11",
                "Europa 105",
                LocalDate.FromDateTime(new DateTime(2019, 3, 15)),
                100.00M,
                Segmentos.BuscaSegmento("Hospital"),
                "Oliveira Trust")
        },
        { "ESTQ11", new("ESTQ11", "Polo Estoque II", null, null, Segmentos.BuscaSegmento("Hoteis"), "Oliveira Trust") },
        {
            "EURO11",
            new(
                "EURO11",
                "Europar",
                LocalDate.FromDateTime(new DateTime(2003, 1, 17)),
                100.00M,
                Segmentos.BuscaSegmento("Hoteis"),
                "Coinvalores")
        },
        {
            "EVBI11",
            new(
                "EVBI11",
                "VBI Consumo Essencial",
                LocalDate.FromDateTime(new DateTime(2020, 1, 23)),
                100.00M,
                Segmentos.BuscaSegmento("Hoteis"),
                "BRL Trust")
        },
        { "EXES11", new("EXES11", "Exes", null, null, Segmentos.BuscaSegmento("Hoteis"), "N/D") },
        {
            "FAED11",
            new(
                "FAED11",
                "Anhanguera Educacional",
                LocalDate.FromDateTime(new DateTime(2010, 1, 8)),
                100.00M,
                Segmentos.BuscaSegmento("Hoteis"),
                "BTG Pactual")
        },
        {
            "FAMB11B",
            new(
                "FAMB11B",
                "Edifício Almirante Barroso",
                LocalDate.FromDateTime(new DateTime(2003, 4, 1)),
                1_000.00M,
                Segmentos.BuscaSegmento("Hoteis"),
                "BTG Pactual")
        },
        {
            "FATN11",
            new(
                "FATN11",
                "Athena I",
                LocalDate.FromDateTime(new DateTime(2020, 6, 4)),
                100.00M,
                Segmentos.BuscaSegmento("Incorporação"),
                "Br-Capital")
        },
        {
            "FCAS11",
            new(
                "FCAS11",
                "Edifício Castelo",
                LocalDate.FromDateTime(new DateTime(2012, 10, 31)),
                100.00M,
                Segmentos.BuscaSegmento("Incorporação"),
                "BTG Pactual")
        },
        {
            "FCFL11",
            new(
                "FCFL11",
                "Campus Faria Lima",
                LocalDate.FromDateTime(new DateTime(2010, 7, 27)),
                50.00M,
                Segmentos.BuscaSegmento("Incorporação"),
                "BTG Pactual")
        },
        {
            "FEXC11",
            new(
                "FEXC11",
                "BTG Pactual Fundo de CRI",
                LocalDate.FromDateTime(new DateTime(2009, 6, 19)),
                100.00M,
                Segmentos.BuscaSegmento("Incorporação"),
                "Null")
        },
        {
            "FGAA11",
            new(
                "FGAA11",
                "FG/Agro Fiagro",
                LocalDate.FromDateTime(new DateTime(2022, 1, 12)),
                10.00M,
                Segmentos.BuscaSegmento("Incorporação"),
                "BRL Trust")
        },
        {
            "FGPM11",
            new("FGPM11", "Grand Plaza Mall", null, null, Segmentos.BuscaSegmento("Incorporação"), "Rio Bravo")
        },
        {
            "FIGS11",
            new(
                "FIGS11",
                "General Shopping Ativo e Renda",
                LocalDate.FromDateTime(new DateTime(2013, 6, 27)),
                100.00M,
                Segmentos.BuscaSegmento("Incorporação"),
                "Hedge Investments")
        },
        {
            "FIIB11",
            new(
                "FIIB11",
                "Industrial do Brasil",
                LocalDate.FromDateTime(new DateTime(2011, 12, 26)),
                300.00M,
                Segmentos.BuscaSegmento("Incorporação"),
                "Coinvalores")
        },
        {
            "FIIP11B",
            new(
                "FIIP11B",
                "RB Capital Renda I",
                LocalDate.FromDateTime(new DateTime(2009, 12, 30)),
                100.00M,
                Segmentos.BuscaSegmento("Incorporação"),
                "Oliveira Trust")
        },
        {
            "FINF11",
            new(
                "FINF11",
                "Infra Real Estate",
                LocalDate.FromDateTime(new DateTime(2014, 9, 17)),
                150.00M,
                Segmentos.BuscaSegmento("Incorporação"),
                "Planner")
        },
        {
            "FISC11",
            new(
                "FISC11",
                "SC 401",
                LocalDate.FromDateTime(new DateTime(2018, 12, 27)),
                100.00M,
                Segmentos.BuscaSegmento("Incorporação"),
                "Br-Capital")
        },
        {
            "FISD11",
            new(
                "FISD11",
                "São Domingos",
                LocalDate.FromDateTime(new DateTime(2017, 3, 1)),
                100.00M,
                Segmentos.BuscaSegmento("Incorporação"),
                "RJI")
        },
        {
            "FIVN11",
            new(
                "FIVN11",
                "Vida Nova",
                LocalDate.FromDateTime(new DateTime(2014, 7, 1)),
                10.00M,
                Segmentos.BuscaSegmento("Incorporação"),
                "Oliveira Trust")
        },
        {
            "FLCR11",
            new(
                "FLCR11",
                "Faria Lima Capital Recebíveis Imobiliários I",
                LocalDate.FromDateTime(new DateTime(2019, 10, 22)),
                100.00M,
                Segmentos.BuscaSegmento("Incorporação"),
                "BRL Trust")
        },
        {
            "FLMA11",
            new(
                "FLMA11",
                "Continental Square Faria Lima",
                LocalDate.FromDateTime(new DateTime(2000, 11, 9)),
                50.00M,
                Segmentos.BuscaSegmento("Incorporação"),
                "Br-Capital")
        },
        {
            "FLRP11",
            new(
                "FLRP11",
                "Floripa Shopping",
                LocalDate.FromDateTime(new DateTime(2009, 10, 19)),
                1_000.00M,
                Segmentos.BuscaSegmento("Incorporação"),
                "BTG Pactual")
        },
        {
            "FMOF11",
            new(
                "FMOF11",
                "Memorial Office",
                LocalDate.FromDateTime(new DateTime(2008, 8, 11)),
                100.00M,
                Segmentos.BuscaSegmento("Incorporação"),
                "Coinvalores")
        },
        {
            "FOFT11",
            new(
                "FOFT11",
                "Hedge TOP FOFII 2",
                LocalDate.FromDateTime(new DateTime(2013, 5, 14)),
                100.00M,
                Segmentos.BuscaSegmento("Incorporação"),
                "Hedge Investments")
        },
        {
            "FPAB11",
            new(
                "FPAB11",
                "Projeto Água Branca",
                LocalDate.FromDateTime(new DateTime(2006, 8, 15)),
                160.00M,
                Segmentos.BuscaSegmento("Incorporação"),
                "Coinvalores")
        },
        {
            "FPNG11",
            new(
                "FPNG11",
                "Pedra Negra Renda Imobiliária",
                LocalDate.FromDateTime(new DateTime(2016, 4, 4)),
                100.00M,
                Segmentos.BuscaSegmento("Incorporação"),
                "Br-Capital")
        },
        {
            "FTCE11B",
            new(
                "FTCE11B",
                "Opportunity",
                LocalDate.FromDateTime(new DateTime(1996, 10, 7)),
                1_000.00M,
                Segmentos.BuscaSegmento("Incorporação Residencial"),
                "BRL Trust")
        },
        {
            "FTMJ11",
            new(
                "FTMJ11",
                "TMJ FII",
                LocalDate.FromDateTime(new DateTime(2017, 6, 12)),
                800.00M,
                Segmentos.BuscaSegmento("Incorporação Residencial"),
                "Gradual")
        },
        {
            "FVBI11",
            new(
                "FVBI11",
                "VBI FL 4440",
                LocalDate.FromDateTime(new DateTime(2012, 7, 3)),
                100.00M,
                Segmentos.BuscaSegmento("Incorporação Residencial"),
                "BTG Pactual")
        },
        {
            "FVPQ11",
            new(
                "FVPQ11",
                "Via Parque",
                LocalDate.FromDateTime(new DateTime(1995, 11, 6)),
                100.00M,
                Segmentos.BuscaSegmento("Incorporação Residencial"),
                "Rio Bravo")
        },
        {
            "FZDA11",
            new("FZDA11", "051 Agro Fiagro", null, null, Segmentos.BuscaSegmento("Incorporação Residencial"), "N/D")
        },
        {
            "GALG11",
            new(
                "GALG11",
                "Guardian Logística",
                LocalDate.FromDateTime(new DateTime(2021, 1, 6)),
                10.00M,
                Segmentos.BuscaSegmento("Incorporação Residencial"),
                "BRL Trust")
        },
        {
            "GAME11",
            new(
                "GAME11",
                "Guardian Multiestratégia Imobiliária I",
                LocalDate.FromDateTime(new DateTime(2022, 2, 18)),
                10.00M,
                Segmentos.BuscaSegmento("Incorporação Residencial"),
                "Banco Daycoval")
        },
        {
            "GCFF11",
            new(
                "GCFF11",
                "Galapagos Fundo de Fundos",
                LocalDate.FromDateTime(new DateTime(2020, 7, 20)),
                100.00M,
                Segmentos.BuscaSegmento("Incorporação Residencial"),
                "BTG Pactual")
        },
        {
            "GCRA11",
            new(
                "GCRA11",
                "Galapagos Recebíveis do Agronegócio Fiagro",
                LocalDate.FromDateTime(new DateTime(2022, 1, 19)),
                100.00M,
                Segmentos.BuscaSegmento("Incorporação Residencial"),
                "Singulare")
        },
        {
            "GCRI11",
            new(
                "GCRI11",
                "Galapagos Recebíveis Imobiliários",
                LocalDate.FromDateTime(new DateTime(2020, 12, 10)),
                100.00M,
                Segmentos.BuscaSegmento("Incorporação Residencial"),
                "BTG Pactual")
        },
        {
            "GESE11B",
            new(
                "GESE11B",
                "General Severiano",
                LocalDate.FromDateTime(new DateTime(2016, 7, 4)),
                1_000.00M,
                Segmentos.BuscaSegmento("Incorporação Residencial"),
                "BTG Pactual")
        },
        {
            "GGRC11",
            new(
                "GGRC11",
                "GGR Covepi",
                LocalDate.FromDateTime(new DateTime(2017, 5, 3)),
                100.00M,
                Segmentos.BuscaSegmento("Incorporação Residencial"),
                "CM Capital Markets")
        },
        {
            "GRLV11",
            new(
                "GRLV11",
                "GR Louveira",
                LocalDate.FromDateTime(new DateTime(2014, 2, 26)),
                100.00M,
                Segmentos.BuscaSegmento("Incorporação Residencial"),
                "Hedge Investments")
        },
        {
            "GSFI11",
            new(
                "GSFI11",
                "General Shopping e Outlets",
                LocalDate.FromDateTime(new DateTime(2019, 5, 2)),
                10.00M,
                Segmentos.BuscaSegmento("Incorporação Residencial"),
                "Planner")
        },
        {
            "GTLG11",
            new(
                "GTLG11",
                "Gtis Brazil Logistics",
                LocalDate.FromDateTime(new DateTime(2021, 11, 8)),
                100.00M,
                Segmentos.BuscaSegmento("Incorporação Residencial"),
                "BRL Trust")
        },
        {
            "GTWR11",
            new(
                "GTWR11",
                "Green Towers",
                LocalDate.FromDateTime(new DateTime(2019, 6, 19)),
                100.00M,
                Segmentos.BuscaSegmento("Incorporação Residencial"),
                "BV DTVM")
        },
        {
            "GWIC11",
            new(
                "GWIC11",
                "GWI Condomínios Logísticos",
                LocalDate.FromDateTime(new DateTime(2010, 8, 12)),
                100.00M,
                Segmentos.BuscaSegmento("Incorporação Residencial"),
                "BTG Pactual")
        },
        {
            "HAAA11",
            new(
                "HAAA11",
                "Hedge AAA",
                LocalDate.FromDateTime(new DateTime(2020, 12, 28)),
                100.00M,
                Segmentos.BuscaSegmento("Incorporação Residencial"),
                "Hedge Investments")
        },
        {
            "HABT11",
            new(
                "HABT11",
                "Habitat Recebíveis Pulverizados",
                LocalDate.FromDateTime(new DateTime(2019, 7, 29)),
                100.00M,
                Segmentos.BuscaSegmento("Incorporação Residencial"),
                "Vórtx")
        },
        {
            "HBCR11",
            new(
                "HBCR11",
                "HBC Renda Urbana",
                LocalDate.FromDateTime(new DateTime(2022, 9, 1)),
                100.00M,
                Segmentos.BuscaSegmento("Incorporação Residencial"),
                "Banco Genial")
        },
        {
            "HBRH11",
            new(
                "HBRH11",
                "Multi Renda Urbana",
                LocalDate.FromDateTime(new DateTime(2020, 5, 18)),
                100.00M,
                Segmentos.BuscaSegmento("Incorporação Residencial"),
                "BRL Trust")
        },
        {
            "HBTT11",
            new(
                "HBTT11",
                "Habitat I",
                LocalDate.FromDateTime(new DateTime(2017, 5, 17)),
                1_000.00M,
                Segmentos.BuscaSegmento("Incorporação Residencial"),
                "Vórtx")
        },
        {
            "HCHG11",
            new(
                "HCHG11",
                "Hectare Recebíveis High Grade",
                LocalDate.FromDateTime(new DateTime(2021, 7, 12)),
                100.00M,
                Segmentos.BuscaSegmento("Incorporação Residencial"),
                "Vórtx")
        },
        {
            "HCPR11",
            new("HCPR11", "Hectare Properties", null, null, Segmentos.BuscaSegmento("Lajes Comerciais"), "N/D")
        },
        {
            "HCRI11",
            new(
                "HCRI11",
                "Hospital da Criança",
                LocalDate.FromDateTime(new DateTime(2005, 6, 1)),
                100.00M,
                Segmentos.BuscaSegmento("Lajes Comerciais"),
                "BTG Pactual")
        },
        {
            "HCST11",
            new(
                "HCST11",
                "Hectare Desenvolvimento Student Housing",
                null,
                null,
                Segmentos.BuscaSegmento("Lajes Comerciais"),
                "Vórtx")
        },
        {
            "HCTR11",
            new(
                "HCTR11",
                "Hectare CE",
                LocalDate.FromDateTime(new DateTime(2019, 7, 11)),
                100.00M,
                Segmentos.BuscaSegmento("Lajes Comerciais"),
                "Vórtx")
        },
        {
            "HDOF11",
            new(
                "HDOF11",
                "Hedge Paladin Design Offices",
                null,
                null,
                Segmentos.BuscaSegmento("Lajes Comerciais"),
                "Hedge Investments")
        },
        {
            "HFOF11",
            new(
                "HFOF11",
                "Hedge TOP FOFII 3",
                LocalDate.FromDateTime(new DateTime(2018, 2, 28)),
                100.00M,
                Segmentos.BuscaSegmento("Lajes Comerciais"),
                "Hedge Investments")
        },
        { "HGAG11", new("HGAG11", "High Fiagro", null, null, Segmentos.BuscaSegmento("Lajes Comerciais"), "Vórtx") },
        {
            "HGBS11",
            new(
                "HGBS11",
                "Hedge Brasil Shopping",
                LocalDate.FromDateTime(new DateTime(2007, 12, 11)),
                100.00M,
                Segmentos.BuscaSegmento("Lajes Comerciais"),
                "Hedge Investments")
        },
        {
            "HGCR11",
            new(
                "HGCR11",
                "CSHG Recebíveis Imobiliários",
                LocalDate.FromDateTime(new DateTime(2010, 1, 13)),
                100.00M,
                Segmentos.BuscaSegmento("Lajes Comerciais"),
                "Credit Suisse")
        },
        {
            "HGFF11",
            new(
                "HGFF11",
                "CSHG Imobiliário FOF",
                LocalDate.FromDateTime(new DateTime(2019, 8, 26)),
                100.00M,
                Segmentos.BuscaSegmento("Lajes Comerciais"),
                "Credit Suisse")
        },
        {
            "HGIC11",
            new(
                "HGIC11",
                "HGI Créditos Imobiliários",
                LocalDate.FromDateTime(new DateTime(2021, 4, 12)),
                104.25M,
                Segmentos.BuscaSegmento("Lajes Comerciais"),
                "Vórtx")
        },
        {
            "HGLG11",
            new(
                "HGLG11",
                "CSHG Logística",
                LocalDate.FromDateTime(new DateTime(2010, 6, 25)),
                100.00M,
                Segmentos.BuscaSegmento("Lajes Comerciais"),
                "Credit Suisse")
        },
        {
            "HGPO11",
            new(
                "HGPO11",
                "CSHG Prime Offices",
                LocalDate.FromDateTime(new DateTime(2009, 11, 11)),
                100.00M,
                Segmentos.BuscaSegmento("Lajes Comerciais"),
                "Credit Suisse")
        },
        {
            "HGRE11",
            new(
                "HGRE11",
                "CSHG Real Estate",
                LocalDate.FromDateTime(new DateTime(2008, 5, 6)),
                100.00M,
                Segmentos.BuscaSegmento("Lajes Comerciais"),
                "Credit Suisse")
        },
        {
            "HGRS11",
            new("HGRS11", "CSHG Residencial", null, null, Segmentos.BuscaSegmento("Lajes Comerciais"), "Credit Suisse")
        },
        {
            "HGRU11",
            new(
                "HGRU11",
                "CSHG Renda Urbana",
                LocalDate.FromDateTime(new DateTime(2018, 7, 27)),
                100.00M,
                Segmentos.BuscaSegmento("Lajes Comerciais"),
                "Credit Suisse")
        },
        {
            "HLOG11",
            new(
                "HLOG11",
                "Hedge Logística",
                LocalDate.FromDateTime(new DateTime(2019, 12, 23)),
                100.00M,
                Segmentos.BuscaSegmento("Lajes Comerciais"),
                "Hedge Investments")
        },
        {
            "HMOC11",
            new(
                "HMOC11",
                "Hedge Shopping Praça da Moça",
                LocalDate.FromDateTime(new DateTime(2013, 3, 13)),
                287.00M,
                Segmentos.BuscaSegmento("Lajes Comerciais"),
                "Hedge Investments")
        },
        {
            "HOSI11",
            new(
                "HOSI11",
                "Housi",
                LocalDate.FromDateTime(new DateTime(2020, 2, 21)),
                100.00M,
                Segmentos.BuscaSegmento("Lajes Comerciais"),
                "Vórtx")
        },
        {
            "HPDP11",
            new(
                "HPDP11",
                "Hedge Shopping Parque Dom Pedro",
                LocalDate.FromDateTime(new DateTime(2019, 12, 20)),
                100.00M,
                Segmentos.BuscaSegmento("Lajes Comerciais"),
                "Hedge Investments")
        },
        {
            "HRDF11",
            new(
                "HRDF11",
                "Hedge Realty Development",
                LocalDate.FromDateTime(new DateTime(2019, 10, 4)),
                2.00M,
                Segmentos.BuscaSegmento("Lajes Comerciais"),
                "Hedge Investments")
        },
        {
            "HREC11",
            new(
                "HREC11",
                "Hedge Recebíveis Imobiliários",
                null,
                null,
                Segmentos.BuscaSegmento("Lajes Comerciais"),
                "Hedge Investments")
        },
        {
            "HSAF11",
            new(
                "HSAF11",
                "HSI Ativos Financeiros",
                LocalDate.FromDateTime(new DateTime(2020, 9, 18)),
                100.00M,
                Segmentos.BuscaSegmento("Lajes Comerciais"),
                "BRL Trust")
        },
        {
            "HSLG11",
            new(
                "HSLG11",
                "HSI Logística",
                LocalDate.FromDateTime(new DateTime(2020, 12, 15)),
                100.00M,
                Segmentos.BuscaSegmento("Lajes Comerciais"),
                "BRL Trust")
        },
        {
            "HSML11",
            new(
                "HSML11",
                "HSI Malls",
                LocalDate.FromDateTime(new DateTime(2019, 8, 16)),
                100.00M,
                Segmentos.BuscaSegmento("Lajes Comerciais"),
                "Santander Caceis")
        },
        {
            "HSRE11",
            new(
                "HSRE11",
                "HSI Renda Imobiliária",
                LocalDate.FromDateTime(new DateTime(2006, 6, 8)),
                100.00M,
                Segmentos.BuscaSegmento("Lajes Comerciais"),
                "BRL Trust")
        },
        {
            "HTMX11",
            new(
                "HTMX11",
                "Hotel Maxinvest",
                LocalDate.FromDateTime(new DateTime(2007, 7, 13)),
                100.00M,
                Segmentos.BuscaSegmento("Lajes Comerciais"),
                "Null")
        },
        {
            "HUCG11",
            new(
                "HUCG11",
                "Hospital Unimed Campina Grande",
                LocalDate.FromDateTime(new DateTime(2022, 5, 18)),
                0.00M,
                Segmentos.BuscaSegmento("Lajes Comerciais"),
                "Coinvalores")
        },
        {
            "HUSC11",
            new(
                "HUSC11",
                "Hospital Unimed Sul Capixaba",
                LocalDate.FromDateTime(new DateTime(2018, 4, 30)),
                100.00M,
                Segmentos.BuscaSegmento("Lajes Comerciais"),
                "Rio Bravo")
        },
        {
            "HUSI11",
            new(
                "HUSI11",
                "HUSI",
                LocalDate.FromDateTime(new DateTime(2020, 3, 4)),
                1_000.00M,
                Segmentos.BuscaSegmento("Lajes Comerciais"),
                "Planner")
        },
        {
            "IAGR11",
            new(
                "IAGR11",
                "SFI Investimentos do Agronegócio Fiagro",
                null,
                null,
                Segmentos.BuscaSegmento("Lajes Comerciais"),
                "N/D")
        },
        {
            "IBCR11",
            new(
                "IBCR11",
                "CRI Integral Brei",
                LocalDate.FromDateTime(new DateTime(2021, 8, 11)),
                100.00M,
                Segmentos.BuscaSegmento("Lajes Comerciais"),
                "BTG Pactual")
        },
        {
            "IBFF11",
            new(
                "IBFF11",
                "FOF Integral Brei",
                LocalDate.FromDateTime(new DateTime(2019, 10, 10)),
                100.00M,
                Segmentos.BuscaSegmento("Lajes Comerciais"),
                "BTG Pactual")
        },
        {
            "IDFI11",
            new(
                "IDFI11",
                "Unidades Autônomas",
                LocalDate.FromDateTime(new DateTime(2021, 7, 26)),
                100.00M,
                Segmentos.BuscaSegmento("Lajes Comerciais"),
                "N/D")
        },
        {
            "IDGR11",
            new(
                "IDGR11",
                "Unidades Autônomas II",
                null,
                null,
                Segmentos.BuscaSegmento("Lajes Comerciais"),
                "Id Corretora De Titulos E Valores Mobiliarios S.A.")
        },
        {
            "IFIX",
            new(
                "IFIX",
                "IFIX Índice de Fundos Imobiliários",
                LocalDate.FromDateTime(new DateTime(2010, 12, 30)),
                1_000.00M,
                Segmentos.BuscaSegmento("Lajes Comerciais"),
                "N/D")
        },
        {
            "IFRA11",
            new(
                "IFRA11",
                "Itaú FIC FI-Infra",
                LocalDate.FromDateTime(new DateTime(2020, 1, 20)),
                100.00M,
                Segmentos.BuscaSegmento("Lajes Comerciais"),
                "Intrag")
        },
        {
            "IRDM11",
            new(
                "IRDM11",
                "Iridium Recebíveis Imobiliários",
                LocalDate.FromDateTime(new DateTime(2018, 3, 8)),
                100.00M,
                Segmentos.BuscaSegmento("Lajes Comerciais"),
                "BTG Pactual")
        },
        { "IRIM11", new("IRIM11", "Iridium", null, null, Segmentos.BuscaSegmento("Lajes Comerciais"), "BTG Pactual") },
        {
            "ITIP11",
            new(
                "ITIP11",
                "Inter Teva Índice de Papel",
                LocalDate.FromDateTime(new DateTime(2021, 2, 24)),
                100.00M,
                Segmentos.BuscaSegmento("Lajes Comerciais"),
                "Inter DTVM")
        },
        {
            "ITIT11",
            new(
                "ITIT11",
                "Inter Teva Índice de Tijolo",
                LocalDate.FromDateTime(new DateTime(2020, 9, 4)),
                100.00M,
                Segmentos.BuscaSegmento("Lajes Comerciais"),
                "Inter DTVM")
        },
        { "JBFO11", new("JBFO11", "JBFO FOF", null, null, Segmentos.BuscaSegmento("Lajes Comerciais"), "Bem DTVM") },
        {
            "JFLL11",
            new(
                "JFLL11",
                "JFL Living",
                LocalDate.FromDateTime(new DateTime(2021, 1, 8)),
                100.00M,
                Segmentos.BuscaSegmento("Lajes Comerciais"),
                "Genial Investimentos")
        },
        {
            "JGPX11",
            new(
                "JGPX11",
                "JGP Crédito Fiagro",
                LocalDate.FromDateTime(new DateTime(2021, 11, 29)),
                100.00M,
                Segmentos.BuscaSegmento("Lajes Comerciais"),
                "Banco Daycoval")
        },
        {
            "JPPA11",
            new(
                "JPPA11",
                "JPP Capital Recebíveis Imobiliários",
                LocalDate.FromDateTime(new DateTime(2019, 11, 22)),
                100.00M,
                Segmentos.BuscaSegmento("Lajes Comerciais"),
                "Finaxis Corretora")
        },
        {
            "JPPC11",
            new(
                "JPPC11",
                "JPP Capital",
                LocalDate.FromDateTime(new DateTime(2013, 5, 24)),
                1_000.00M,
                Segmentos.BuscaSegmento("Lajes Comerciais"),
                "Banco Finaxis")
        },
        {
            "JRDM11",
            new(
                "JRDM11",
                "Shopping Jardim Sul",
                LocalDate.FromDateTime(new DateTime(2012, 9, 11)),
                100.00M,
                Segmentos.BuscaSegmento("Lajes Comerciais"),
                "BTG Pactual")
        },
        {
            "JSAF11",
            new(
                "JSAF11",
                "JS Ativos Financeiros",
                LocalDate.FromDateTime(new DateTime(2021, 11, 25)),
                100.00M,
                Segmentos.BuscaSegmento("Lajes Comerciais"),
                "Banco J. Safra")
        },
        {
            "JSIM11",
            new(
                "JSIM11",
                "JS Real Estate Renda Imobiliária",
                LocalDate.FromDateTime(new DateTime(2011, 6, 20)),
                1_000.00M,
                Segmentos.BuscaSegmento("Lajes Comerciais"),
                "Banco J. Safra")
        },
        {
            "JSRE11",
            new(
                "JSRE11",
                "JS Real Estate Multigestão",
                LocalDate.FromDateTime(new DateTime(2011, 6, 10)),
                100.00M,
                Segmentos.BuscaSegmento("Lajes Comerciais"),
                "Banco J. Safra")
        },
        {
            "JTPR11",
            new(
                "JTPR11",
                "JT PREV Desenvolvimento Habitacional",
                LocalDate.FromDateTime(new DateTime(2017, 11, 7)),
                100.00M,
                Segmentos.BuscaSegmento("Lajes Comerciais"),
                "Planner")
        },
        {
            "JURO11",
            new(
                "JURO11",
                "Sparta FI-Infra",
                LocalDate.FromDateTime(new DateTime(2021, 12, 8)),
                100.00M,
                Segmentos.BuscaSegmento("Lajes Comerciais"),
                "BTG Pactual")
        },
        {
            "KCRE11", new("KCRE11", "Kinea Creditas", null, null, Segmentos.BuscaSegmento("Lajes Comerciais"), "Intrag")
        },
        {
            "KDIF11",
            new(
                "KDIF11",
                "Kinea FI-Infra",
                LocalDate.FromDateTime(new DateTime(2017, 4, 27)),
                100.00M,
                Segmentos.BuscaSegmento("Lajes Comerciais"),
                "Intrag")
        },
        { "KEVE11", new("KEVE11", "Even II", null, null, Segmentos.BuscaSegmento("Lajes Comerciais"), "Intrag") },
        {
            "KFOF11",
            new(
                "KFOF11",
                "Kinea Fundo de Fundos",
                LocalDate.FromDateTime(new DateTime(2019, 1, 22)),
                100.00M,
                Segmentos.BuscaSegmento("Lajes Comerciais"),
                "Intrag")
        },
        {
            "KINP11",
            new(
                "KINP11",
                "Even Permuta Kinea",
                LocalDate.FromDateTime(new DateTime(2017, 9, 14)),
                10.00M,
                Segmentos.BuscaSegmento("Lajes Comerciais"),
                "Intrag")
        },
        {
            "KISU11",
            new(
                "KISU11",
                "Kilima FoF Suno 30",
                LocalDate.FromDateTime(new DateTime(2020, 10, 8)),
                10.00M,
                Segmentos.BuscaSegmento("Lajes Comerciais"),
                "BRL Trust")
        },
        {
            "KIVO11",
            new(
                "KIVO11",
                "Kilima Volkano Recebíveis",
                LocalDate.FromDateTime(new DateTime(2022, 3, 14)),
                100.00M,
                Segmentos.BuscaSegmento("Lajes Comerciais"),
                "BRL Trust")
        },
        {
            "KNCA11",
            new(
                "KNCA11",
                "Kinea Crédito Agro Fiagro",
                LocalDate.FromDateTime(new DateTime(2022, 1, 18)),
                100.00M,
                Segmentos.BuscaSegmento("Lajes Comerciais"),
                "Intrag")
        },
        {
            "KNCR11",
            new(
                "KNCR11",
                "Kinea Rendimentos Imobiliários FII",
                LocalDate.FromDateTime(new DateTime(2012, 11, 2)),
                100.00M,
                Segmentos.BuscaSegmento("Lajes Comerciais"),
                "Intrag")
        },
        {
            "KNHY11",
            new(
                "KNHY11",
                "Kinea High Yield CRI",
                LocalDate.FromDateTime(new DateTime(2018, 8, 8)),
                100.00M,
                Segmentos.BuscaSegmento("Lajes Comerciais"),
                "Intrag")
        },
        {
            "KNIP11",
            new(
                "KNIP11",
                "Kinea Índices de Preços",
                LocalDate.FromDateTime(new DateTime(2016, 9, 26)),
                100.00M,
                Segmentos.BuscaSegmento("Lajes Comerciais"),
                "Intrag")
        },
        {
            "KNRE11",
            new(
                "KNRE11",
                "Kinea II Real Estate Equity",
                LocalDate.FromDateTime(new DateTime(2011, 10, 3)),
                10.00M,
                Segmentos.BuscaSegmento("Lajes Comerciais"),
                "Intrag")
        },
        {
            "KNRI11",
            new(
                "KNRI11",
                "Kinea Renda Imobiliária",
                LocalDate.FromDateTime(new DateTime(2010, 12, 1)),
                100.00M,
                Segmentos.BuscaSegmento("Lajes Comerciais"),
                "Intrag")
        },
        {
            "KNSC11",
            new(
                "KNSC11",
                "Kinea Securities",
                LocalDate.FromDateTime(new DateTime(2020, 10, 28)),
                100.00M,
                Segmentos.BuscaSegmento("Lajes Comerciais"),
                "Intrag")
        },
        {
            "LASC11",
            new(
                "LASC11",
                "Legatus Shoppings",
                LocalDate.FromDateTime(new DateTime(2019, 8, 31)),
                100.00M,
                Segmentos.BuscaSegmento("Lajes Comerciais"),
                "BTG Pactual")
        },
        {
            "LATR11B",
            new(
                "LATR11B",
                "Lateres",
                LocalDate.FromDateTime(new DateTime(2013, 4, 30)),
                100.00M,
                Segmentos.BuscaSegmento("Lajes Comerciais"),
                "Oliveira Trust")
        },
        {
            "LFTT11",
            new(
                "LFTT11",
                "Loft II",
                LocalDate.FromDateTime(new DateTime(2020, 7, 27)),
                100.00M,
                Segmentos.BuscaSegmento("Lajes Comerciais"),
                "Maf")
        },
        {
            "LGCP11",
            new(
                "LGCP11",
                "Log CP Inter",
                LocalDate.FromDateTime(new DateTime(2019, 12, 23)),
                100.00M,
                Segmentos.BuscaSegmento("Lajes Comerciais"),
                "Inter DTVM")
        },
        {
            "LKDV11",
            new("LKDV11", "Development V1", null, null, Segmentos.BuscaSegmento("Lajes Comerciais"), "BTG Pactual")
        },
        {
            "LLAO11",
            new("LLAO11", "BS2 Allinvestments", null, null, Segmentos.BuscaSegmento("Lajes Comerciais"), "Singulare")
        },
        {
            "LOFT11B",
            new(
                "LOFT11B",
                "Loft I (Cota Sênior)",
                LocalDate.FromDateTime(new DateTime(2019, 6, 13)),
                100.00M,
                Segmentos.BuscaSegmento("Lajes Comerciais"),
                "Maf")
        },
        {
            "LOFT13B",
            new(
                "LOFT13B",
                "Loft I (Cota Subordinada)",
                LocalDate.FromDateTime(new DateTime(2019, 6, 13)),
                100.00M,
                Segmentos.BuscaSegmento("Lajes Comerciais"),
                "Maf")
        },
        { "LRDI11", new("LRDI11", "Leblon Realty", null, null, Segmentos.BuscaSegmento("Lajes Comerciais"), "N/D") },
        {
            "LSAG11",
            new("LSAG11", "Leste Fiagro", null, null, Segmentos.BuscaSegmento("Lajes Comerciais"), "Banco Genial")
        },
        {
            "LSPA11",
            new(
                "LSPA11",
                "Leste Riva Equity Preferencial I",
                LocalDate.FromDateTime(new DateTime(2022, 5, 13)),
                100.00M,
                Segmentos.BuscaSegmento("Lajes Comerciais"),
                "Genial Investimentos")
        },
        {
            "LUGG11",
            new(
                "LUGG11",
                "Luggo",
                LocalDate.FromDateTime(new DateTime(2019, 12, 30)),
                100.00M,
                Segmentos.BuscaSegmento("Lajes Comerciais"),
                "Inter DTVM")
        },
        {
            "LVBI11",
            new(
                "LVBI11",
                "VBI Logístico",
                LocalDate.FromDateTime(new DateTime(2018, 11, 16)),
                100.00M,
                Segmentos.BuscaSegmento("Lajes Comerciais"),
                "BTG Pactual")
        },
        {
            "MADS11",
            new(
                "MADS11",
                "Mauá Capital Desenvolvimento I",
                null,
                null,
                Segmentos.BuscaSegmento("Logisticos"),
                "BTG Pactual")
        },
        {
            "MALL11",
            new(
                "MALL11",
                "Malls Brasil Plural",
                LocalDate.FromDateTime(new DateTime(2017, 12, 18)),
                100.00M,
                Segmentos.BuscaSegmento("Logisticos"),
                "Genial Investimentos")
        },
        {
            "MANA11",
            new(
                "MANA11",
                "Manatí Capital Hedge Fund",
                LocalDate.FromDateTime(new DateTime(2022, 8, 29)),
                0.00M,
                Segmentos.BuscaSegmento("Logisticos"),
                "Banco Daycoval")
        },
        {
            "MATV11",
            new(
                "MATV11",
                "More Gestão Ativa de Recebíveis",
                LocalDate.FromDateTime(new DateTime(2021, 6, 22)),
                100.00M,
                Segmentos.BuscaSegmento("Logisticos"),
                "BTG Pactual")
        },
        {
            "MAXR11",
            new(
                "MAXR11",
                "Max Retail",
                LocalDate.FromDateTime(new DateTime(2009, 10, 26)),
                52.63M,
                Segmentos.BuscaSegmento("Logisticos"),
                "BTG Pactual")
        },
        {
            "MBRF11",
            new(
                "MBRF11",
                "Mercantil do Brasil",
                LocalDate.FromDateTime(new DateTime(2011, 6, 22)),
                1_000.00M,
                Segmentos.BuscaSegmento("Logisticos"),
                "Rio Bravo")
        },
        {
            "MCCI11",
            new(
                "MCCI11",
                "Mauá Capital Recebíveis Imobiliários",
                LocalDate.FromDateTime(new DateTime(2019, 12, 10)),
                100.00M,
                Segmentos.BuscaSegmento("Logisticos"),
                "BTG Pactual")
        },
        {
            "MCHF11",
            new(
                "MCHF11",
                "Mauá Capital Hedge Fund",
                LocalDate.FromDateTime(new DateTime(2021, 7, 7)),
                10.00M,
                Segmentos.BuscaSegmento("Logisticos"),
                "BTG Pactual")
        },
        {
            "MCHY11",
            new(
                "MCHY11",
                "Mauá High Yield",
                LocalDate.FromDateTime(new DateTime(2021, 7, 28)),
                100.08M,
                Segmentos.BuscaSegmento("Logisticos"),
                "BTG Pactual")
        },
        {
            "MFAI11",
            new(
                "MFAI11",
                "Mérito Fundos e Ações Imobiliárias",
                LocalDate.FromDateTime(new DateTime(2020, 7, 6)),
                100.00M,
                Segmentos.BuscaSegmento("Logisticos"),
                "Mérito")
        },
        {
            "MFCR11",
            new(
                "MFCR11",
                "Merito Recebíveis Imobiliários",
                LocalDate.FromDateTime(new DateTime(2022, 8, 11)),
                100.00M,
                Segmentos.BuscaSegmento("Logisticos"),
                "Mérito")
        },
        {
            "MFII11",
            new(
                "MFII11",
                "Mérito Desenvolvimento Imobiliário I",
                LocalDate.FromDateTime(new DateTime(2013, 8, 1)),
                100.00M,
                Segmentos.BuscaSegmento("Logisticos"),
                "Mérito")
        },
        {
            "MGCR11",
            new(
                "MGCR11",
                "Mogno CRIs High Grade",
                LocalDate.FromDateTime(new DateTime(2020, 10, 6)),
                100.00M,
                Segmentos.BuscaSegmento("Logisticos"),
                "BTG Pactual")
        },
        {
            "MGFF11",
            new(
                "MGFF11",
                "Mogno Fundo de Fundos",
                LocalDate.FromDateTime(new DateTime(2018, 4, 3)),
                100.00M,
                Segmentos.BuscaSegmento("Logisticos"),
                "BTG Pactual")
        },
        {
            "MGHT11",
            new(
                "MGHT11",
                "Mogno Hoteis",
                LocalDate.FromDateTime(new DateTime(2020, 4, 16)),
                100.00M,
                Segmentos.BuscaSegmento("Logisticos"),
                "BTG Pactual")
        },
        {
            "MGIM11",
            new(
                "MGIM11",
                "Mogno Real Estate Impact Development",
                null,
                null,
                Segmentos.BuscaSegmento("Logisticos"),
                "BTG Pactual")
        },
        {
            "MGLG11",
            new(
                "MGLG11",
                "Mogno Suno Logística",
                LocalDate.FromDateTime(new DateTime(2021, 3, 26)),
                100.00M,
                Segmentos.BuscaSegmento("Logisticos"),
                "BRL Trust")
        },
        {
            "MGRI11",
            new(
                "MGRI11",
                "Mogno Properties",
                LocalDate.FromDateTime(new DateTime(2022, 3, 21)),
                100.00M,
                Segmentos.BuscaSegmento("Logisticos"),
                "Singulare")
        },
        {
            "MINT11",
            new("MINT11", "Mint Educacional", null, null, Segmentos.BuscaSegmento("Logisticos"), "Banco Genial")
        },
        {
            "MMVE11",
            new(
                "MMVE11",
                "Maresias",
                LocalDate.FromDateTime(new DateTime(2022, 6, 13)),
                100.00M,
                Segmentos.BuscaSegmento("Logisticos"),
                "Singulare")
        },
        {
            "MOFF11",
            new("MOFF11", "Multioffices 2", null, null, Segmentos.BuscaSegmento("Logisticos"), "Oliveira Trust")
        },
        {
            "MORC11",
            new(
                "MORC11",
                "More Recebíveis Imobiliários",
                LocalDate.FromDateTime(new DateTime(2021, 11, 24)),
                100.00M,
                Segmentos.BuscaSegmento("Logisticos"),
                "N/D")
        },
        {
            "MORE11",
            new(
                "MORE11",
                "More Real Estate FOF",
                LocalDate.FromDateTime(new DateTime(2020, 5, 4)),
                100.00M,
                Segmentos.BuscaSegmento("Logisticos"),
                "BTG Pactual")
        },
        {
            "MSHP11",
            new(
                "MSHP11",
                "Mais Shopping Largo 13",
                LocalDate.FromDateTime(new DateTime(2010, 11, 17)),
                1_000.00M,
                Segmentos.BuscaSegmento("Logisticos"),
                "Bem DTVM")
        },
        {
            "MTOF11",
            new("MTOF11", "Alianza Multioffices", null, null, Segmentos.BuscaSegmento("Logisticos"), "Oliveira Trust")
        },
        { "MTRS11", new("MTRS11", "Metropolis", null, null, Segmentos.BuscaSegmento("Logisticos"), "BTG Pactual") },
        { "MVFI11", new("MVFI11", "MV9 FII", null, null, Segmentos.BuscaSegmento("Logisticos"), "BTG Pactual") },
        {
            "MXRF11",
            new(
                "MXRF11",
                "Maxi Renda",
                LocalDate.FromDateTime(new DateTime(2011, 9, 20)),
                10.00M,
                Segmentos.BuscaSegmento("Logisticos"),
                "BTG Pactual")
        },
        {
            "NAVT11",
            new(
                "NAVT11",
                "Navi Imobiliário Total Return",
                LocalDate.FromDateTime(new DateTime(2021, 3, 25)),
                100.00M,
                Segmentos.BuscaSegmento("Logisticos"),
                "BTG Pactual")
        },
        {
            "NCHB11",
            new(
                "NCHB11",
                "NCH EQI High Yield Recebíveis Imobiliários",
                LocalDate.FromDateTime(new DateTime(2013, 10, 3)),
                1_000.00M,
                Segmentos.BuscaSegmento("Logisticos"),
                "BTG Pactual")
        },
        {
            "NCRA11",
            new(
                "NCRA11",
                "NCH EQI Recebíveis do Agronegócio Fiagro",
                null,
                null,
                Segmentos.BuscaSegmento("Logisticos"),
                "BTG Pactual")
        },
        {
            "NEWL11",
            new(
                "NEWL11",
                "Newport Logística",
                LocalDate.FromDateTime(new DateTime(2019, 12, 27)),
                100.00M,
                Segmentos.BuscaSegmento("Logisticos"),
                "Banco Genial")
        },
        {
            "NEWU11",
            new(
                "NEWU11",
                "Newport Renda Urbana",
                LocalDate.FromDateTime(new DateTime(2012, 4, 13)),
                100.00M,
                Segmentos.BuscaSegmento("Logisticos"),
                "Genial Investimentos")
        },
        {
            "NPAR11",
            new(
                "NPAR11",
                "Nestpar",
                LocalDate.FromDateTime(new DateTime(2016, 5, 23)),
                50.00M,
                Segmentos.BuscaSegmento("Logisticos"),
                "Planner")
        },
        {
            "NSLU11",
            new(
                "NSLU11",
                "Hospital Nossa Senhora de Lourdes",
                LocalDate.FromDateTime(new DateTime(2006, 10, 18)),
                100.00M,
                Segmentos.BuscaSegmento("Logisticos"),
                "BTG Pactual")
        },
        {
            "NVHO11",
            new(
                "NVHO11",
                "Novo Horizonte",
                LocalDate.FromDateTime(new DateTime(2014, 9, 25)),
                10.00M,
                Segmentos.BuscaSegmento("Logisticos"),
                "Genial Investimentos")
        },
        {
            "NVIF11B",
            new(
                "NVIF11B",
                "Nova I",
                LocalDate.FromDateTime(new DateTime(2015, 12, 15)),
                1_000_000.00M,
                Segmentos.BuscaSegmento("Logisticos"),
                "Maf")
        },
        {
            "OIAG11",
            new(
                "OIAG11",
                "Ourinvest Innovation Fiagro",
                LocalDate.FromDateTime(new DateTime(2022, 5, 24)),
                10.00M,
                Segmentos.BuscaSegmento("Logisticos"),
                "Singulare")
        },
        {
            "ONEF11",
            new(
                "ONEF11",
                "The One",
                LocalDate.FromDateTime(new DateTime(2012, 3, 1)),
                100.00M,
                Segmentos.BuscaSegmento("Logisticos"),
                "Rio Bravo")
        },
        {
            "ORPD11",
            new(
                "ORPD11",
                "Ouro Verde Desenvolvimento Imobiliário",
                LocalDate.FromDateTime(new DateTime(2017, 5, 17)),
                100.00M,
                Segmentos.BuscaSegmento("Logisticos"),
                "Planner")
        },
        {
            "OUFF11",
            new(
                "OUFF11",
                "Ourinvest Fundo de Fundos",
                LocalDate.FromDateTime(new DateTime(2019, 7, 15)),
                100.00M,
                Segmentos.BuscaSegmento("Logisticos"),
                "Banco Ourinvest S.A.")
        },
        {
            "OUJP11",
            new(
                "OUJP11",
                "Ourinvest JPP",
                LocalDate.FromDateTime(new DateTime(2017, 7, 6)),
                100.00M,
                Segmentos.BuscaSegmento("N/D"),
                "Finaxis Corretora")
        },
        {
            "OULG11",
            new(
                "OULG11",
                "Ourinvest Logística",
                LocalDate.FromDateTime(new DateTime(2018, 11, 13)),
                100.00M,
                Segmentos.BuscaSegmento("N/D"),
                "Banco Ourinvest S.A.")
        },
        {
            "OURE11",
            new(
                "OURE11",
                "Ourinvest Renda Estruturada",
                LocalDate.FromDateTime(new DateTime(2018, 5, 8)),
                100.00M,
                Segmentos.BuscaSegmento("N/D"),
                "Banco Ourinvest S.A.")
        },
        {
            "PABY11",
            new(
                "PABY11",
                "Panamby",
                LocalDate.FromDateTime(new DateTime(1995, 3, 1)),
                100.00M,
                Segmentos.BuscaSegmento("N/D"),
                "Brkb DTVM")
        },
        { "PATB11", new("PATB11", "Pateo Bandeirantes", null, null, Segmentos.BuscaSegmento("N/D"), "BTG Pactual") },
        {
            "PATC11",
            new(
                "PATC11",
                "Pátria Edifícios Corporativos",
                LocalDate.FromDateTime(new DateTime(2019, 4, 2)),
                100.00M,
                Segmentos.BuscaSegmento("N/D"),
                "Maf")
        },
        {
            "PATL11",
            new(
                "PATL11",
                "Pátria Logística",
                LocalDate.FromDateTime(new DateTime(2020, 8, 14)),
                100.00M,
                Segmentos.BuscaSegmento("N/D"),
                "Vórtx")
        },
        {
            "PBLV11",
            new(
                "PBLV11",
                "Prologis Brazil Logistics Venture",
                LocalDate.FromDateTime(new DateTime(2019, 4, 22)),
                1_000.00M,
                Segmentos.BuscaSegmento("N/D"),
                "BRL Trust")
        },
        { "PBYR11", new("PBYR11", "Panamby Renda Master", null, null, Segmentos.BuscaSegmento("N/D"), "BTG Pactual") },
        { "PCAS11", new("PCAS11", "Praia do Castelo", null, null, Segmentos.BuscaSegmento("N/D"), "Planner") },
        {
            "PEMA11",
            new(
                "PEMA11",
                "Performa Real Estate",
                LocalDate.FromDateTime(new DateTime(2021, 2, 8)),
                100.00M,
                Segmentos.BuscaSegmento("N/D"),
                "BRL Trust")
        },
        {
            "PLCA11",
            new("PLCA11", "Plural BRB Crédito Agro", null, null, Segmentos.BuscaSegmento("N/D"), "Banco Genial")
        },
        {
            "PLCR11",
            new(
                "PLCR11",
                "Plural Recebíveis Imobiliários",
                LocalDate.FromDateTime(new DateTime(2019, 11, 12)),
                100.00M,
                Segmentos.BuscaSegmento("N/D"),
                "Genial Investimentos")
        },
        {
            "PLOG11",
            new(
                "PLOG11",
                "Plural Logística",
                LocalDate.FromDateTime(new DateTime(2021, 3, 5)),
                100.00M,
                Segmentos.BuscaSegmento("N/D"),
                "Genial Investimentos")
        },
        {
            "PLRI11",
            new(
                "PLRI11",
                "Polo",
                LocalDate.FromDateTime(new DateTime(2011, 8, 1)),
                100.00M,
                Segmentos.BuscaSegmento("N/D"),
                "Oliveira Trust")
        },
        {
            "PNDL11",
            new(
                "PNDL11",
                "Panorama Desenvolvimento Logístico",
                LocalDate.FromDateTime(new DateTime(2020, 9, 30)),
                100_000.00M,
                Segmentos.BuscaSegmento("N/D"),
                "BRL Trust")
        },
        { "PNLN11", new("PNLN11", "Panorama Last Mile SBC", null, null, Segmentos.BuscaSegmento("N/D"), "BRL Trust") },
        {
            "PNPR11",
            new(
                "PNPR11",
                "Panorama Properties",
                LocalDate.FromDateTime(new DateTime(2022, 1, 24)),
                100.00M,
                Segmentos.BuscaSegmento("N/D"),
                "Singulare")
        },
        {
            "PORD11",
            new(
                "PORD11",
                "Polo Crédito Imobiliário",
                LocalDate.FromDateTime(new DateTime(2013, 1, 4)),
                100.00M,
                Segmentos.BuscaSegmento("N/D"),
                "Oliveira Trust")
        },
        {
            "PQAG11",
            new(
                "PQAG11",
                "Parque Anhanguera",
                LocalDate.FromDateTime(new DateTime(2020, 7, 30)),
                100.00M,
                Segmentos.BuscaSegmento("N/D"),
                "Hedge Investments")
        },
        {
            "PQDP11",
            new(
                "PQDP11",
                "Parque Dom Pedro Shopping Center",
                LocalDate.FromDateTime(new DateTime(2009, 12, 17)),
                1_000.00M,
                Segmentos.BuscaSegmento("N/D"),
                "BTG Pactual")
        },
        {
            "PRSN11B",
            new(
                "PRSN11B",
                "Personale I",
                LocalDate.FromDateTime(new DateTime(2011, 7, 26)),
                1.00M,
                Segmentos.BuscaSegmento("N/D"),
                "Oliveira Trust")
        },
        {
            "PRSV11",
            new(
                "PRSV11",
                "Presidente Vargas",
                LocalDate.FromDateTime(new DateTime(2010, 5, 3)),
                1_000.00M,
                Segmentos.BuscaSegmento("N/D"),
                "Hedge Investments")
        },
        {
            "PRTS11",
            new(
                "PRTS11",
                "Multi Properties",
                LocalDate.FromDateTime(new DateTime(2016, 12, 20)),
                1.00M,
                Segmentos.BuscaSegmento("N/D"),
                "Maf")
        },
        {
            "PURB11",
            new(
                "PURB11",
                "Plural Renda Urbana",
                LocalDate.FromDateTime(new DateTime(2021, 11, 26)),
                95.00M,
                Segmentos.BuscaSegmento("N/D"),
                "Banco Genial")
        },
        {
            "PVBI11",
            new(
                "PVBI11",
                "VBI Prime Properties",
                LocalDate.FromDateTime(new DateTime(2020, 7, 29)),
                100.00M,
                Segmentos.BuscaSegmento("N/D"),
                "BTG Pactual")
        },
        {
            "QAGR11",
            new(
                "QAGR11",
                "Quasar Agro",
                LocalDate.FromDateTime(new DateTime(2019, 11, 12)),
                100.00M,
                Segmentos.BuscaSegmento("N/D"),
                "BTG Pactual")
        },
        {
            "QAMI11",
            new(
                "QAMI11",
                "Quasar Crédito",
                LocalDate.FromDateTime(new DateTime(2021, 4, 9)),
                100.00M,
                Segmentos.BuscaSegmento("N/D"),
                "Genial Investimentos")
        },
        {
            "QIRI11",
            new(
                "QIRI11",
                "Quatá Imob Recebíveis Imobiliários",
                LocalDate.FromDateTime(new DateTime(2020, 7, 17)),
                100.00M,
                Segmentos.BuscaSegmento("N/D"),
                "BRL Trust")
        },
        {
            "RBAG11",
            new(
                "RBAG11",
                "RB Capital Agre",
                LocalDate.FromDateTime(new DateTime(2010, 6, 14)),
                100.00M,
                Segmentos.BuscaSegmento("N/D"),
                "Citibank DTVM")
        },
        {
            "RBBV11",
            new(
                "RBBV11",
                "JHSF Rio Bravo Fazenda Boa Vista",
                LocalDate.FromDateTime(new DateTime(2013, 8, 7)),
                100.00M,
                Segmentos.BuscaSegmento("N/D"),
                "Caixa Economica Federal")
        },
        {
            "RBCB11",
            new(
                "RBCB11",
                "Rio Bravo Crédito Imobiliário I",
                LocalDate.FromDateTime(new DateTime(2010, 9, 30)),
                1_000.00M,
                Segmentos.BuscaSegmento("N/D"),
                "Rio Bravo")
        },
        {
            "RBCO11",
            new(
                "RBCO11",
                "RB Capital Office Income",
                LocalDate.FromDateTime(new DateTime(2019, 10, 17)),
                100.00M,
                Segmentos.BuscaSegmento("N/D"),
                "BRL Trust")
        },
        {
            "RBDS11",
            new(
                "RBDS11",
                "RB Capital Desenvolvimento Residencial II",
                LocalDate.FromDateTime(new DateTime(2010, 8, 16)),
                1_000.00M,
                Segmentos.BuscaSegmento("N/D"),
                "Oliveira Trust")
        },
        {
            "RBED11",
            new(
                "RBED11",
                "Rio Bravo Renda Educacional",
                LocalDate.FromDateTime(new DateTime(2011, 9, 20)),
                100.00M,
                Segmentos.BuscaSegmento("N/D"),
                "Rio Bravo")
        },
        {
            "RBFF11",
            new(
                "RBFF11",
                "Rio Bravo Fundo de Fundos",
                LocalDate.FromDateTime(new DateTime(2013, 5, 31)),
                100.00M,
                Segmentos.BuscaSegmento("Outros"),
                "BRL Trust")
        },
        {
            "RBGS11",
            new(
                "RBGS11",
                "RB Capital General Shopping Sulacap",
                LocalDate.FromDateTime(new DateTime(2011, 9, 1)),
                100.00M,
                Segmentos.BuscaSegmento("Outros"),
                "Oliveira Trust")
        },
        {
            "RBHG11",
            new(
                "RBHG11",
                "Rio Bravo Crédito Imobiliário High Grade",
                LocalDate.FromDateTime(new DateTime(2019, 5, 6)),
                100.00M,
                Segmentos.BuscaSegmento("Outros"),
                "BRL Trust")
        },
        {
            "RBHY11",
            new(
                "RBHY11",
                "Rio Bravo Crédito Imobiliário High Yield",
                LocalDate.FromDateTime(new DateTime(2021, 2, 1)),
                100.00M,
                Segmentos.BuscaSegmento("Outros"),
                "BRL Trust")
        },
        {
            "RBIF11",
            new(
                "RBIF11",
                "Rio Bravo ESG FIC FI FI-Infra",
                null,
                null,
                Segmentos.BuscaSegmento("Outros"),
                "Banco Daycoval")
        },
        {
            "RBIR11",
            new(
                "RBIR11",
                "RB Capital Desenvolvimento Residencial IV",
                LocalDate.FromDateTime(new DateTime(2020, 3, 3)),
                100.00M,
                Segmentos.BuscaSegmento("Outros"),
                "Oliveira Trust")
        },
        {
            "RBLG11",
            new(
                "RBLG11",
                "RB Capital Logístico",
                LocalDate.FromDateTime(new DateTime(2021, 3, 26)),
                1_000.00M,
                Segmentos.BuscaSegmento("Recebíveis Imobiliários"),
                "BTG Pactual")
        },
        {
            "RBPD11",
            new(
                "RBPD11",
                "RB Capital Prime Realty II",
                LocalDate.FromDateTime(new DateTime(2011, 12, 6)),
                100.00M,
                Segmentos.BuscaSegmento("Recebíveis Imobiliários"),
                "Citibank DTVM")
        },
        {
            "RBPR11",
            new(
                "RBPR11",
                "RB Capital Prime Realty I",
                LocalDate.FromDateTime(new DateTime(2010, 12, 27)),
                100.00M,
                Segmentos.BuscaSegmento("Recebíveis Imobiliários"),
                "Citibank DTVM")
        },
        {
            "RBRD11",
            new(
                "RBRD11",
                "RB Capital Renda II",
                LocalDate.FromDateTime(new DateTime(2010, 11, 4)),
                100.00M,
                Segmentos.BuscaSegmento("Recebíveis Imobiliários"),
                "BV DTVM")
        },
        {
            "RBRF11",
            new(
                "RBRF11",
                "RBR Alpha Multiestratégia Real Estate",
                LocalDate.FromDateTime(new DateTime(2017, 9, 14)),
                100.00M,
                Segmentos.BuscaSegmento("Recebíveis Imobiliários"),
                "BTG Pactual")
        },
        {
            "RBRI11",
            new(
                "RBRI11",
                "RBR Desenvolvimento III",
                null,
                null,
                Segmentos.BuscaSegmento("Recebíveis Imobiliários"),
                "BTG Pactual")
        },
        {
            "RBRL11",
            new(
                "RBRL11",
                "RBR Log",
                LocalDate.FromDateTime(new DateTime(2020, 4, 20)),
                100.00M,
                Segmentos.BuscaSegmento("Recebíveis Imobiliários"),
                "BRL Trust")
        },
        {
            "RBRM11",
            new(
                "RBRM11",
                "RBR Desenvolvimento",
                LocalDate.FromDateTime(new DateTime(2019, 12, 16)),
                0.00M,
                Segmentos.BuscaSegmento("Recebíveis Imobiliários"),
                "BTG Pactual")
        },
        {
            "RBRP11",
            new(
                "RBRP11",
                "RBR Properties FII",
                LocalDate.FromDateTime(new DateTime(2019, 12, 28)),
                80.00M,
                Segmentos.BuscaSegmento("Recebíveis Imobiliários"),
                "BRL Trust")
        },
        {
            "RBRR11",
            new(
                "RBRR11",
                "RBR Rendimentos High Grade",
                LocalDate.FromDateTime(new DateTime(2018, 4, 27)),
                100.00M,
                Segmentos.BuscaSegmento("Recebíveis Imobiliários"),
                "BTG Pactual")
        },
        {
            "RBRS11",
            new(
                "RBRS11",
                "Rio Bravo Renda Residencial",
                LocalDate.FromDateTime(new DateTime(2020, 9, 22)),
                100.00M,
                Segmentos.BuscaSegmento("Recebíveis Imobiliários"),
                "Rio Bravo")
        },
        {
            "RBRU11",
            new(
                "RBRU11",
                "RB Capital Renda Urbana",
                null,
                null,
                Segmentos.BuscaSegmento("Recebíveis Imobiliários"),
                "BRL Trust")
        },
        {
            "RBRX11",
            new(
                "RBRX11",
                "RBR Plus Multiestratégia Real Estate",
                null,
                null,
                Segmentos.BuscaSegmento("Recebíveis Imobiliários"),
                "BTG Pactual")
        },
        {
            "RBRY11",
            new(
                "RBRY11",
                "RBR Crédito Imobiliário Estruturado",
                LocalDate.FromDateTime(new DateTime(2019, 5, 24)),
                100.00M,
                Segmentos.BuscaSegmento("Recebíveis Imobiliários"),
                "BTG Pactual")
        },
        {
            "RBTS11",
            new(
                "RBTS11",
                "RB Capital TFO Situs",
                LocalDate.FromDateTime(new DateTime(2018, 6, 14)),
                1_000.00M,
                Segmentos.BuscaSegmento("Recebíveis Imobiliários"),
                "Oliveira Trust")
        },
        {
            "RBVA11",
            new(
                "RBVA11",
                "Rio Bravo Renda Varejo",
                LocalDate.FromDateTime(new DateTime(2012, 11, 14)),
                100.00M,
                Segmentos.BuscaSegmento("Recebíveis Imobiliários"),
                "Rio Bravo")
        },
        {
            "RBVO11",
            new(
                "RBVO11",
                "Rio Bravo Crédito Imobiliário II",
                LocalDate.FromDateTime(new DateTime(2012, 12, 26)),
                100.00M,
                Segmentos.BuscaSegmento("Recebíveis Imobiliários"),
                "Rio Bravo")
        },
        {
            "RCCS11",
            new(
                "RCCS11",
                "REP 1 CCS",
                LocalDate.FromDateTime(new DateTime(2009, 11, 27)),
                1_000.00M,
                Segmentos.BuscaSegmento("Recebíveis Imobiliários"),
                "Credit Suisse")
        },
        {
            "RCFA11",
            new(
                "RCFA11",
                "Grupo RCFA",
                LocalDate.FromDateTime(new DateTime(2019, 5, 10)),
                20.00M,
                Segmentos.BuscaSegmento("Recebíveis Imobiliários"),
                "Terra")
        },
        {
            "RCFF11",
            new(
                "RCFF11",
                "RBR Desenvolvimento Comercial Feeder FOF",
                LocalDate.FromDateTime(new DateTime(2020, 6, 22)),
                100.00M,
                Segmentos.BuscaSegmento("Recebíveis Imobiliários"),
                "BRL Trust")
        },
        {
            "RCRB11",
            new(
                "RCRB11",
                "Rio Bravo Renda Corporativa",
                LocalDate.FromDateTime(new DateTime(2003, 11, 1)),
                100.00M,
                Segmentos.BuscaSegmento("Recebíveis Imobiliários"),
                "Rio Bravo")
        },
        {
            "RCRI11B",
            new(
                "RCRI11B",
                "RB Capital Rendimentos",
                LocalDate.FromDateTime(new DateTime(2018, 11, 16)),
                1_000.00M,
                Segmentos.BuscaSegmento("Recebíveis Imobiliários"),
                "Oliveira Trust")
        },
        {
            "RDPD11",
            new(
                "RDPD11",
                "Fundo BB Renda de Papéis II",
                LocalDate.FromDateTime(new DateTime(2018, 5, 3)),
                100.00M,
                Segmentos.BuscaSegmento("Recebíveis Imobiliários"),
                "BV DTVM")
        },
        {
            "RECR11",
            new(
                "RECR11",
                "REC Recebíveis Imobiliários",
                LocalDate.FromDateTime(new DateTime(2017, 10, 16)),
                100.00M,
                Segmentos.BuscaSegmento("Recebíveis Imobiliários"),
                "BRL Trust")
        },
        {
            "RECT11",
            new(
                "RECT11",
                "REC Renda Imobiliária",
                LocalDate.FromDateTime(new DateTime(2019, 4, 24)),
                100.00M,
                Segmentos.BuscaSegmento("Recebíveis Imobiliários"),
                "BRL Trust")
        },
        {
            "RECX11",
            new(
                "RECX11",
                "REC Fundo de Fundos",
                LocalDate.FromDateTime(new DateTime(2021, 2, 19)),
                100.00M,
                Segmentos.BuscaSegmento("Recebíveis Imobiliários"),
                "BTG Pactual")
        },
        {
            "REIT11",
            new(
                "REIT11",
                "Singulare FII",
                LocalDate.FromDateTime(new DateTime(2014, 5, 26)),
                1_000.00M,
                Segmentos.BuscaSegmento("Recebíveis Imobiliários"),
                "Singulare")
        },
        {
            "RELG11",
            new("RELG11", "REC Logística", null, null, Segmentos.BuscaSegmento("Recebíveis Imobiliários"), "BRL Trust")
        },
        {
            "RFOF11",
            new(
                "RFOF11",
                "RB Capital I Fundo de Fundos",
                LocalDate.FromDateTime(new DateTime(2020, 2, 28)),
                100.00M,
                Segmentos.BuscaSegmento("Recebíveis Imobiliários"),
                "BRL Trust")
        },
        {
            "RMAI11",
            new(
                "RMAI11",
                "REAG Multi Ativos Imobiliários",
                LocalDate.FromDateTime(new DateTime(2014, 1, 22)),
                100.00M,
                Segmentos.BuscaSegmento("Recebíveis Imobiliários"),
                "Reag")
        },
        {
            "RNDP11",
            new(
                "RNDP11",
                "Fundo BB Renda de Papéis",
                LocalDate.FromDateTime(new DateTime(2012, 4, 17)),
                1_000.00M,
                Segmentos.BuscaSegmento("Recebíveis Imobiliários"),
                "BV DTVM")
        },
        {
            "RNGO11",
            new(
                "RNGO11",
                "Rio Negro",
                LocalDate.FromDateTime(new DateTime(2012, 5, 9)),
                100.00M,
                Segmentos.BuscaSegmento("Recebíveis Imobiliários"),
                "Rio Bravo")
        },
        {
            "ROOF11",
            new("ROOF11", "Rooftop I", null, null, Segmentos.BuscaSegmento("Recebíveis Imobiliários"), "Vórtx")
        },
        {
            "RPRI11",
            new(
                "RPRI11",
                "RBR Premium Recebíveis Imobiliários",
                LocalDate.FromDateTime(new DateTime(2022, 7, 28)),
                101.30M,
                Segmentos.BuscaSegmento("Recebíveis Imobiliários"),
                "Intrag")
        },
        {
            "RRCI11",
            new(
                "RRCI11",
                "RB Capital Recebíveis Imobiliários",
                LocalDate.FromDateTime(new DateTime(2020, 11, 19)),
                100.00M,
                Segmentos.BuscaSegmento("Recebíveis Imobiliários"),
                "BRL Trust")
        },
        {
            "RSBU11B",
            new(
                "RSBU11B",
                "RSB 1",
                LocalDate.FromDateTime(new DateTime(2011, 10, 3)),
                1_000.00M,
                Segmentos.BuscaSegmento("Recebíveis Imobiliários"),
                "Nsg Capital DTVM")
        },
        {
            "RSPD11",
            new(
                "RSPD11",
                "RB Capital Desenvolvimento Residencial III",
                LocalDate.FromDateTime(new DateTime(2019, 10, 29)),
                1_000.00M,
                Segmentos.BuscaSegmento("Recebíveis Imobiliários"),
                "Oliveira Trust")
        },
        {
            "RURA11",
            new(
                "RURA11",
                "Itaú Asset Rural Fiagro",
                LocalDate.FromDateTime(new DateTime(2022, 3, 9)),
                10.00M,
                Segmentos.BuscaSegmento("Recebíveis Imobiliários"),
                "Intrag")
        },
        {
            "RVBI11",
            new(
                "RVBI11",
                "VBI Reits FOF",
                LocalDate.FromDateTime(new DateTime(2020, 2, 10)),
                100.00M,
                Segmentos.BuscaSegmento("Recebíveis Imobiliários"),
                "BRL Trust")
        },
        {
            "RZAG11",
            new(
                "RZAG11",
                "Riza Agro Fiagro",
                LocalDate.FromDateTime(new DateTime(2021, 10, 6)),
                10.00M,
                Segmentos.BuscaSegmento("Recebíveis Imobiliários"),
                "Banco Genial")
        },
        {
            "RZAK11",
            new(
                "RZAK11",
                "Riza Akin",
                LocalDate.FromDateTime(new DateTime(2021, 11, 18)),
                100.00M,
                Segmentos.BuscaSegmento("Recebíveis Imobiliários"),
                "BTG Pactual")
        },
        {
            "RZTR11",
            new(
                "RZTR11",
                "Riza Terrax",
                LocalDate.FromDateTime(new DateTime(2020, 10, 5)),
                100.00M,
                Segmentos.BuscaSegmento("Recebíveis Imobiliários"),
                "Banco Genial")
        },
        {
            "SAAG11",
            new(
                "SAAG11",
                "Santander Agências",
                LocalDate.FromDateTime(new DateTime(2013, 1, 9)),
                100.00M,
                Segmentos.BuscaSegmento("Recebíveis Imobiliários"),
                "Rio Bravo")
        },
        {
            "SADI11",
            new(
                "SADI11",
                "Santander Papéis Imobiliários CDI",
                LocalDate.FromDateTime(new DateTime(2019, 8, 8)),
                100.00M,
                Segmentos.BuscaSegmento("Recebíveis Imobiliários"),
                "Santander Caceis")
        },
        {
            "SAIC11B",
            new(
                "SAIC11B",
                "SIA Corporate",
                LocalDate.FromDateTime(new DateTime(2014, 2, 26)),
                100.00M,
                Segmentos.BuscaSegmento("Recebíveis Imobiliários"),
                "Brb DTVM")
        },
        { "SALI11", new("SALI11", "Vênus", null, null, Segmentos.BuscaSegmento("Recebíveis Imobiliários"), "Vórtx") },
        {
            "SARE11",
            new(
                "SARE11",
                "Santander Renda de Aluguéis",
                LocalDate.FromDateTime(new DateTime(2020, 1, 10)),
                100.00M,
                Segmentos.BuscaSegmento("Recebíveis Imobiliários"),
                "Santander Securities")
        },
        {
            "SBCL11",
            new(
                "SBCL11",
                "FRAM Capital SBCLog",
                null,
                null,
                Segmentos.BuscaSegmento("Recebíveis Imobiliários"),
                "Fram Capital")
        },
        {
            "SCPF11",
            new(
                "SCPF11",
                "SCP",
                LocalDate.FromDateTime(new DateTime(2006, 10, 25)),
                10.00M,
                Segmentos.BuscaSegmento("Recebíveis Imobiliários"),
                "Br-Capital")
        },
        {
            "SDIL11",
            new(
                "SDIL11",
                "SDI Rio Bravo Renda Logística",
                LocalDate.FromDateTime(new DateTime(2012, 11, 19)),
                100.00M,
                Segmentos.BuscaSegmento("Recebíveis Imobiliários"),
                "Rio Bravo")
        },
        {
            "SEED11",
            new(
                "SEED11",
                "Hedge Seed",
                null,
                null,
                Segmentos.BuscaSegmento("Recebíveis Imobiliários"),
                "Hedge Investments")
        },
        {
            "SEQR11",
            new(
                "SEQR11",
                "Sequóia III Renda Imobiliária",
                LocalDate.FromDateTime(new DateTime(2021, 2, 26)),
                100.00M,
                Segmentos.BuscaSegmento("Recebíveis Imobiliários"),
                "Vórtx")
        },
        {
            "SFND11",
            new(
                "SFND11",
                "São Fernando",
                LocalDate.FromDateTime(new DateTime(2008, 6, 19)),
                10.00M,
                Segmentos.BuscaSegmento("Recebíveis Imobiliários"),
                "Rio Bravo")
        },
        {
            "SFRO11",
            new(
                "SFRO11",
                "São Francisco 34",
                null,
                null,
                Segmentos.BuscaSegmento("Recebíveis Imobiliários"),
                "CM Capital Markets")
        },
        {
            "SHDP11B",
            new(
                "SHDP11B",
                "Shopping Parque Dom Pedro",
                LocalDate.FromDateTime(new DateTime(2013, 8, 1)),
                747.50M,
                Segmentos.BuscaSegmento("Recebíveis Imobiliários"),
                "BTG Pactual")
        },
        {
            "SHOP11",
            new(
                "SHOP11",
                "Multi Shoppings",
                LocalDate.FromDateTime(new DateTime(2016, 6, 8)),
                100.00M,
                Segmentos.BuscaSegmento("Recebíveis Imobiliários"),
                "BTG Pactual")
        },
        {
            "SHPH11",
            new(
                "SHPH11",
                "Shopping Pátio Higienópolis",
                LocalDate.FromDateTime(new DateTime(2003, 8, 1)),
                100.00M,
                Segmentos.BuscaSegmento("Recebíveis Imobiliários"),
                "Rio Bravo")
        },
        {
            "SHSO11",
            new(
                "SHSO11",
                "SH Special Opps",
                null,
                null,
                Segmentos.BuscaSegmento("Recebíveis Imobiliários"),
                "Hedge Investments")
        },
        {
            "SIGR11",
            new(
                "SIGR11",
                "SIG Capital Recebíveis Pulverizados",
                LocalDate.FromDateTime(new DateTime(2021, 7, 30)),
                0.00M,
                Segmentos.BuscaSegmento("Recebíveis Imobiliários"),
                "BTG Pactual")
        },
        {
            "SJAU11",
            new("SJAU11", "SJ AU Logística", null, null, Segmentos.BuscaSegmento("Recebíveis Imobiliários"), "Vórtx")
        },
        {
            "SNAG11",
            new(
                "SNAG11",
                "Suno Agro Fiagro",
                LocalDate.FromDateTime(new DateTime(2022, 8, 8)),
                100.00M,
                Segmentos.BuscaSegmento("Recebíveis Imobiliários"),
                "Singulare")
        },
        {
            "SNCI11",
            new(
                "SNCI11",
                "Suno Recebíveis",
                LocalDate.FromDateTime(new DateTime(2021, 10, 15)),
                100.00M,
                Segmentos.BuscaSegmento("Recebíveis Imobiliários"),
                "BTG Pactual")
        },
        {
            "SNFF11",
            new(
                "SNFF11",
                "Suno Fundo de Fundos",
                LocalDate.FromDateTime(new DateTime(2021, 5, 3)),
                100.00M,
                Segmentos.BuscaSegmento("Recebíveis Imobiliários"),
                "BTG Pactual")
        },
        {
            "SOLR11",
            new(
                "SOLR11",
                "Solarium",
                LocalDate.FromDateTime(new DateTime(2020, 5, 19)),
                1_000.00M,
                Segmentos.BuscaSegmento("Recebíveis Imobiliários"),
                "Genial Investimentos")
        },
        {
            "SPAF11",
            new(
                "SPAF11",
                "Spa",
                LocalDate.FromDateTime(new DateTime(2016, 12, 12)),
                1_000.00M,
                Segmentos.BuscaSegmento("Recebíveis Imobiliários"),
                "Plural")
        },
        {
            "SPTW11",
            new(
                "SPTW11",
                "SP Downtown",
                LocalDate.FromDateTime(new DateTime(2013, 3, 12)),
                100.00M,
                Segmentos.BuscaSegmento("Recebíveis Imobiliários"),
                "Genial Investimentos")
        },
        {
            "SPVJ11",
            new("SPVJ11", "Sucesspar Varejo", null, null, Segmentos.BuscaSegmento("Recebíveis Imobiliários"), "Vórtx")
        },
        {
            "SPXS11",
            new(
                "SPXS11",
                "SPX SYN Multiestratégia",
                LocalDate.FromDateTime(new DateTime(2022, 8, 9)),
                100.00M,
                Segmentos.BuscaSegmento("Recebíveis Imobiliários"),
                "BTG Pactual")
        },
        {
            "SRVD11",
            new(
                "SRVD11",
                "Serra Verde",
                LocalDate.FromDateTime(new DateTime(2022, 1, 5)),
                8.19M,
                Segmentos.BuscaSegmento("Recebíveis Imobiliários"),
                "Vórtx")
        },
        {
            "STFI11",
            new(
                "STFI11",
                "Santander Recebíveis Imobiliários",
                LocalDate.FromDateTime(new DateTime(2013, 3, 26)),
                10_000.00M,
                Segmentos.BuscaSegmento("Recebíveis Imobiliários"),
                "Santander Securities")
        },
        {
            "STRX11",
            new("STRX11", "StarX", null, null, Segmentos.BuscaSegmento("Recebíveis Imobiliários"), "Inter DTVM")
        },
        {
            "TBOF11",
            new(
                "TBOF11",
                "TB Office",
                LocalDate.FromDateTime(new DateTime(2013, 6, 17)),
                100.00M,
                Segmentos.BuscaSegmento("Recebíveis Imobiliários"),
                "BTG Pactual")
        },
        {
            "TCIN11",
            new("TCIN11", "G5 Cidade Nova", null, null, Segmentos.BuscaSegmento("Recebíveis Imobiliários"), "Singulare")
        },
        {
            "TCIN12",
            new(
                "TCIN12",
                "G5 Cidade Nova (Cota Ordinária)",
                null,
                null,
                Segmentos.BuscaSegmento("Recebíveis Imobiliários"),
                "Singulare")
        },
        {
            "TCPF11",
            new(
                "TCPF11",
                "Treecorp Real Estate I",
                LocalDate.FromDateTime(new DateTime(2019, 5, 29)),
                100.00M,
                Segmentos.BuscaSegmento("Recebíveis Imobiliários"),
                "Br-Capital")
        },
        {
            "TELD11",
            new(
                "TELD11",
                "Tellus Desenvolvimento Logístico",
                null,
                null,
                Segmentos.BuscaSegmento("Recebíveis Imobiliários"),
                "BRL Trust")
        },
        {
            "TEPP11",
            new(
                "TEPP11",
                "Tellus Properties",
                LocalDate.FromDateTime(new DateTime(2019, 9, 26)),
                100.00M,
                Segmentos.BuscaSegmento("Recebíveis Imobiliários"),
                "BRL Trust")
        },
        {
            "TFOF11",
            new(
                "TFOF11",
                "Hedge TOP FOFII",
                LocalDate.FromDateTime(new DateTime(2014, 8, 7)),
                100.00M,
                Segmentos.BuscaSegmento("Recebíveis Imobiliários"),
                "Hedge Investments")
        },
        {
            "TGAR11",
            new(
                "TGAR11",
                "TG Ativo Real",
                LocalDate.FromDateTime(new DateTime(2017, 7, 4)),
                100.00M,
                Segmentos.BuscaSegmento("Recebíveis Imobiliários"),
                "Vórtx")
        },
        {
            "THRA11",
            new(
                "THRA11",
                "Cyrela Thera Corporate",
                LocalDate.FromDateTime(new DateTime(2012, 1, 16)),
                100.00M,
                Segmentos.BuscaSegmento("Recebíveis Imobiliários"),
                "Hedge Investments")
        },
        {
            "TJKB11",
            new(
                "TJKB11",
                "Tjk Renda Imobiliária",
                null,
                null,
                Segmentos.BuscaSegmento("Recebíveis Imobiliários"),
                "Br-Capital")
        },
        {
            "TORD11",
            new(
                "TORD11",
                "Tordesilhas EI",
                LocalDate.FromDateTime(new DateTime(2020, 4, 3)),
                10.00M,
                Segmentos.BuscaSegmento("Recebíveis Imobiliários"),
                "Vórtx")
        },
        {
            "TORM11",
            new(
                "TORM11",
                "Tourmalet I",
                LocalDate.FromDateTime(new DateTime(2016, 12, 23)),
                100.00M,
                Segmentos.BuscaSegmento("Recebíveis Imobiliários"),
                "Vórtx")
        },
        {
            "TOUR11",
            new(
                "TOUR11",
                "Tourmalet II",
                LocalDate.FromDateTime(new DateTime(2019, 1, 30)),
                100.00M,
                Segmentos.BuscaSegmento("Recebíveis Imobiliários"),
                "Vórtx")
        },
        {
            "TRNT11",
            new(
                "TRNT11",
                "Torre Norte",
                LocalDate.FromDateTime(new DateTime(2004, 6, 1)),
                100.00M,
                Segmentos.BuscaSegmento("Recebíveis Imobiliários"),
                "BTG Pactual")
        },
        {
            "TRXB11",
            new(
                "TRXB11",
                "TRX Real Estate II",
                LocalDate.FromDateTime(new DateTime(2020, 8, 6)),
                100.00M,
                Segmentos.BuscaSegmento("Recebíveis Imobiliários"),
                "BRL Trust")
        },
        {
            "TRXF11",
            new(
                "TRXF11",
                "TRX Real Estate",
                LocalDate.FromDateTime(new DateTime(2019, 1, 23)),
                100.00M,
                Segmentos.BuscaSegmento("Recebíveis Imobiliários"),
                "BRL Trust")
        },
        {
            "TSER11",
            new(
                "TSER11",
                "Tishman Speyer Renda Corporativa",
                LocalDate.FromDateTime(new DateTime(2021, 3, 31)),
                100.00M,
                Segmentos.BuscaSegmento("Recebíveis Imobiliários"),
                "BRL Trust")
        },
        {
            "TSNC11",
            new(
                "TSNC11",
                "Transinc",
                LocalDate.FromDateTime(new DateTime(2014, 11, 21)),
                1_000.00M,
                Segmentos.BuscaSegmento("Recebíveis Imobiliários"),
                "BTG Pactual")
        },
        {
            "TSNM11",
            new(
                "TSNM11",
                "TS New Marginal",
                null,
                null,
                Segmentos.BuscaSegmento("Recebíveis Imobiliários"),
                "BTG Pactual")
        },
        {
            "URPR11",
            new(
                "URPR11",
                "Urca Prime Renda",
                LocalDate.FromDateTime(new DateTime(2020, 8, 27)),
                100.00M,
                Segmentos.BuscaSegmento("Recebíveis Imobiliários"),
                "Vórtx")
        },
        {
            "VCJR11",
            new(
                "VCJR11",
                "Vectis Juros Real",
                LocalDate.FromDateTime(new DateTime(2020, 1, 28)),
                100.00M,
                Segmentos.BuscaSegmento("Recebíveis Imobiliários"),
                "Intrag")
        },
        {
            "VCRA11",
            new(
                "VCRA11",
                "Vectis Datagro Crédito Agronegócio Fiagro",
                LocalDate.FromDateTime(new DateTime(2021, 12, 29)),
                100.00M,
                Segmentos.BuscaSegmento("Recebíveis Imobiliários"),
                "Intrag")
        },
        {
            "VCRI11",
            new(
                "VCRI11",
                "Vinci Credit Securities",
                LocalDate.FromDateTime(new DateTime(2022, 5, 16)),
                10.00M,
                Segmentos.BuscaSegmento("Recebíveis Imobiliários"),
                "BRL Trust")
        },
        {
            "VCRR11",
            new(
                "VCRR11",
                "Vectis Renda Residencial",
                LocalDate.FromDateTime(new DateTime(2021, 5, 31)),
                100.00M,
                Segmentos.BuscaSegmento("Recebíveis Imobiliários"),
                "BRL Trust")
        },
        {
            "VERE11",
            new(
                "VERE11",
                "Vereda",
                LocalDate.FromDateTime(new DateTime(2014, 1, 3)),
                100.00M,
                Segmentos.BuscaSegmento("Recebíveis Imobiliários"),
                "Vórtx")
        },
        {
            "VGHF11",
            new(
                "VGHF11",
                "Valora Hedge Fund",
                LocalDate.FromDateTime(new DateTime(2021, 3, 1)),
                10.00M,
                Segmentos.BuscaSegmento("Recebíveis Imobiliários"),
                "Banco Daycoval")
        },
        {
            "VGIA11",
            new(
                "VGIA11",
                "Valora CRA Fiagro",
                LocalDate.FromDateTime(new DateTime(2021, 11, 24)),
                10.00M,
                Segmentos.BuscaSegmento("Recebíveis Imobiliários"),
                "BTG Pactual")
        },
        {
            "VGIP11",
            new(
                "VGIP11",
                "Valora CRI Índice de Preço",
                LocalDate.FromDateTime(new DateTime(2020, 3, 20)),
                100.00M,
                Segmentos.BuscaSegmento("Residencial"),
                "BTG Pactual")
        },
        {
            "VGIR11",
            new(
                "VGIR11",
                "Valora CRI CDI",
                LocalDate.FromDateTime(new DateTime(2018, 7, 31)),
                100.00M,
                Segmentos.BuscaSegmento("Residencial"),
                "BTG Pactual")
        },
        {
            "VIDS11",
            new(
                "VIDS11",
                "Vic Desenvolvimento - Vintage 20/21",
                null,
                null,
                Segmentos.BuscaSegmento("Residencial"),
                "Banco Genial")
        },
        {
            "VIFI11",
            new(
                "VIFI11",
                "Vinci Instrumentos Financeiros",
                LocalDate.FromDateTime(new DateTime(2020, 2, 21)),
                10.00M,
                Segmentos.BuscaSegmento("Residencial"),
                "BRL Trust")
        },
        {
            "VILG11",
            new(
                "VILG11",
                "Vinci Logística",
                LocalDate.FromDateTime(new DateTime(2018, 12, 10)),
                100.00M,
                Segmentos.BuscaSegmento("Residencial"),
                "BRL Trust")
        },
        {
            "VINO11",
            new(
                "VINO11",
                "Vinci Offices",
                LocalDate.FromDateTime(new DateTime(2019, 11, 28)),
                63.50M,
                Segmentos.BuscaSegmento("Residencial"),
                "BRL Trust")
        },
        {
            "VISC11",
            new(
                "VISC11",
                "Vinci Shopping Centers",
                LocalDate.FromDateTime(new DateTime(2014, 3, 10)),
                100.00M,
                Segmentos.BuscaSegmento("Residencial"),
                "BRL Trust")
        },
        {
            "VIUR11",
            new(
                "VIUR11",
                "Vinci Imóveis Urbanos",
                LocalDate.FromDateTime(new DateTime(2021, 5, 31)),
                10.00M,
                Segmentos.BuscaSegmento("Residencial"),
                "BRL Trust")
        },
        {
            "VJFD11",
            new("VJFD11", "JFDCAM", null, null, Segmentos.BuscaSegmento("Shopping/Varejo"), "Votorantim Asset")
        },
        {
            "VLJS11",
            new(
                "VLJS11",
                "Vector Queluz Lajes Corporativas",
                LocalDate.FromDateTime(new DateTime(2013, 12, 2)),
                1_000.00M,
                Segmentos.BuscaSegmento("Shopping/Varejo"),
                "Planner")
        },
        {
            "VLOL11",
            new(
                "VLOL11",
                "Vila Olímpia Corporate",
                LocalDate.FromDateTime(new DateTime(2012, 8, 14)),
                100.00M,
                Segmentos.BuscaSegmento("Shopping/Varejo"),
                "Oliveira Trust")
        },
        {
            "VOTS11",
            new(
                "VOTS11",
                "Votorantim Securities Master",
                LocalDate.FromDateTime(new DateTime(2018, 7, 18)),
                100.00M,
                Segmentos.BuscaSegmento("Shopping/Varejo"),
                "Votorantim Asset")
        },
        {
            "VPSI11",
            new(
                "VPSI11",
                "Polo Shopping Indaiatuba",
                LocalDate.FromDateTime(new DateTime(2014, 5, 9)),
                10.00M,
                Segmentos.BuscaSegmento("Shopping/Varejo"),
                "BRL Trust")
        },
        {
            "VRTA11",
            new(
                "VRTA11",
                "Fator Verità",
                LocalDate.FromDateTime(new DateTime(2011, 1, 1)),
                100.00M,
                Segmentos.BuscaSegmento("Shopping/Varejo"),
                "Banco Fator")
        },
        {
            "VSEC11",
            new(
                "VSEC11",
                "Votorantim Securities",
                LocalDate.FromDateTime(new DateTime(2020, 7, 1)),
                100.00M,
                Segmentos.BuscaSegmento("Shopping/Varejo"),
                "Votorantim Asset")
        },
        {
            "VSHO11",
            new(
                "VSHO11",
                "Votorantim Shopping",
                LocalDate.FromDateTime(new DateTime(2018, 12, 3)),
                100.00M,
                Segmentos.BuscaSegmento("Shopping/Varejo"),
                "Votorantim Asset")
        },
        {
            "VSLH11",
            new(
                "VSLH11",
                "Versalhes Recebíveis Imobiliários",
                LocalDate.FromDateTime(new DateTime(2020, 12, 21)),
                10.00M,
                Segmentos.BuscaSegmento("Shopping/Varejo"),
                "Vórtx")
        },
        {
            "VTLT11",
            new(
                "VTLT11",
                "Votorantim Logística",
                LocalDate.FromDateTime(new DateTime(2018, 4, 23)),
                100.00M,
                Segmentos.BuscaSegmento("Shopping/Varejo"),
                "BV DTVM")
        },
        {
            "VTPA11",
            new("VTPA11", "Votorantim Patrimonial V", null, null, Segmentos.BuscaSegmento("Shopping/Varejo"), "BV DTVM")
        },
        { "VTPL11", new("VTPL11", "FII Plus", null, null, Segmentos.BuscaSegmento("Shopping/Varejo"), "BTG Pactual") },
        {
            "VTRT11",
            new(
                "VTRT11",
                "Votorantim Securities III",
                null,
                null,
                Segmentos.BuscaSegmento("Shopping/Varejo"),
                "Votorantim Asset")
        },
        {
            "VTVI11",
            new(
                "VTVI11",
                "Parking Partners",
                null,
                null,
                Segmentos.BuscaSegmento("Shopping/Varejo"),
                "Votorantim Asset")
        },
        {
            "VTXI11",
            new(
                "VTXI11",
                "Votorantim Patrimonial XII",
                null,
                null,
                Segmentos.BuscaSegmento("Shopping/Varejo"),
                "BV DTVM")
        },
        {
            "VVPR11",
            new(
                "VVPR11",
                "V2 Properties",
                LocalDate.FromDateTime(new DateTime(2019, 1, 3)),
                100.00M,
                Segmentos.BuscaSegmento("Shopping/Varejo"),
                "BTG Pactual")
        },
        {
            "VXXV11",
            new("VXXV11", "Genesis Multiestratégia", null, null, Segmentos.BuscaSegmento("Shopping/Varejo"), "Planner")
        },
        {
            "WHGR11",
            new("WHGR11", "WHG Real Estate", null, null, Segmentos.BuscaSegmento("Shopping/Varejo"), "Banco Genial")
        },
        {
            "WMRB11B",
            new(
                "WMRB11B",
                "WM RB Capital",
                LocalDate.FromDateTime(new DateTime(2011, 6, 28)),
                1_000.00M,
                Segmentos.BuscaSegmento("Shopping/Varejo"),
                "Citibank DTVM")
        },
        {
            "WPLZ11",
            new(
                "WPLZ11",
                "West Plaza",
                LocalDate.FromDateTime(new DateTime(2008, 8, 12)),
                100.00M,
                Segmentos.BuscaSegmento("Shopping/Varejo"),
                "Hedge Investments")
        },
        {
            "WTSP11B",
            new(
                "WTSP11B",
                "Ourinvest RE I",
                LocalDate.FromDateTime(new DateTime(2018, 6, 25)),
                75.00M,
                Segmentos.BuscaSegmento("Shopping/Varejo"),
                "Banco Ourinvest S.A.")
        },
        {
            "WVSC11",
            new("WVSC11", "Warren Vectis Securities", null, null, Segmentos.BuscaSegmento("Shopping/Varejo"), "Warren")
        },
        {
            "XBXO11",
            new(
                "XBXO11",
                "R Cap 1810 Fundo de Fundos",
                null,
                null,
                Segmentos.BuscaSegmento("Shopping/Varejo"),
                "Monetar")
        },
        {
            "XPCA11",
            new(
                "XPCA11",
                "XP Crédito Agrícola Fiagro",
                LocalDate.FromDateTime(new DateTime(2021, 11, 17)),
                10.00M,
                Segmentos.BuscaSegmento("Shopping/Varejo"),
                "Xp Investimentos")
        },
        {
            "XPCI11",
            new(
                "XPCI11",
                "XP Crédito",
                LocalDate.FromDateTime(new DateTime(2019, 12, 17)),
                100.00M,
                Segmentos.BuscaSegmento("Shopping/Varejo"),
                "Vórtx")
        },
        {
            "XPCM11",
            new(
                "XPCM11",
                "XP Corporate Macaé",
                LocalDate.FromDateTime(new DateTime(2013, 3, 8)),
                100.00M,
                Segmentos.BuscaSegmento("Shopping/Varejo"),
                "Rio Bravo")
        },
        {
            "XPGA11",
            new(
                "XPGA11",
                "XP Recebíveis",
                LocalDate.FromDateTime(new DateTime(2011, 12, 8)),
                100.00M,
                Segmentos.BuscaSegmento("Shopping/Varejo"),
                "Xp Investimentos")
        },
        {
            "XPHT11",
            new(
                "XPHT11",
                "XP Hotéis (Cota Sênior)",
                LocalDate.FromDateTime(new DateTime(2019, 4, 24)),
                100.00M,
                Segmentos.BuscaSegmento("Shopping/Varejo"),
                "Genial Investimentos")
        },
        {
            "XPHT12",
            new(
                "XPHT12",
                "XP Hotéis (Cota Ordinária)",
                LocalDate.FromDateTime(new DateTime(2019, 4, 24)),
                100.00M,
                Segmentos.BuscaSegmento("Shopping/Varejo"),
                "Genial Investimentos")
        },
        {
            "XPID11",
            new(
                "XPID11",
                "XP FIC FI-Infra",
                LocalDate.FromDateTime(new DateTime(2021, 4, 16)),
                100.00M,
                Segmentos.BuscaSegmento("Shopping/Varejo"),
                "Plural")
        },
        {
            "XPIN11",
            new(
                "XPIN11",
                "XP Industrial",
                LocalDate.FromDateTime(new DateTime(2018, 6, 21)),
                100.00M,
                Segmentos.BuscaSegmento("Shopping/Varejo"),
                "Vórtx")
        },
        {
            "XPLG11",
            new(
                "XPLG11",
                "XP Log",
                LocalDate.FromDateTime(new DateTime(2018, 6, 5)),
                100.00M,
                Segmentos.BuscaSegmento("Shopping/Varejo"),
                "Vórtx")
        },
        {
            "XPML11",
            new(
                "XPML11",
                "XP Malls",
                LocalDate.FromDateTime(new DateTime(2017, 12, 28)),
                100.00M,
                Segmentos.BuscaSegmento("Shopping/Varejo"),
                "Xp Investimentos")
        },
        {
            "XPPR11",
            new(
                "XPPR11",
                "XP Properties",
                LocalDate.FromDateTime(new DateTime(2019, 12, 9)),
                100.00M,
                Segmentos.BuscaSegmento("Shopping/Varejo"),
                "Vórtx")
        },
        {
            "XPSF11",
            new(
                "XPSF11",
                "XP Selection",
                LocalDate.FromDateTime(new DateTime(2019, 2, 17)),
                10.00M,
                Segmentos.BuscaSegmento("Shopping/Varejo"),
                "Xp Investimentos")
        },
        {
            "XTED11",
            new(
                "XTED11",
                "TRX Edifícios Corporativos",
                LocalDate.FromDateTime(new DateTime(2012, 11, 13)),
                100.00M,
                Segmentos.BuscaSegmento("Shopping/Varejo"),
                "BTG Pactual")
        },
        {
            "YUFI11",
            new(
                "YUFI11",
                "Yuca",
                LocalDate.FromDateTime(new DateTime(2020, 11, 9)),
                100.00M,
                Segmentos.BuscaSegmento("Shopping/Varejo"),
                "BRL Trust")
        },
        {
            "ZIFI11",
            new(
                "ZIFI11",
                "Zion Capital",
                LocalDate.FromDateTime(new DateTime(2021, 6, 30)),
                1_000.00M,
                Segmentos.BuscaSegmento("Shopping/Varejo"),
                "Planner")
        },
    };

    public static Ativo? BuscaAtivo(string codigo)
    {
        return DicionarioAtivos.TryGetValue(codigo, out var ativo)
            ? ativo
            : null;
    }
}