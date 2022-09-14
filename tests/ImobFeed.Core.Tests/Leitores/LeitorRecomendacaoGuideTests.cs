using FluentAssertions;
using ImobFeed.Core.Leitores;
using NodaTime;

namespace ImobFeed.Core.Tests.Leitores;

public class LeitorRecomendacaoGuideTests
{
    [Fact]
    public void LerDeveriaRetornarRecomendacao()
    {
        const string input =
            @"   

 

ae toe are | Dividend Yield | Performance |

   

Logistico ae BRCO11 Bresco Logistica 109,0 108,4 1,01x 6.9% 7,2! 97° 11,2%
10% Logistico Renda BTLG11 BTGPactualLogistica 1040 100,7 1,03x 8,4% 85% 46% 3.2%
10% — Recebiveis Renda CPTS11_—Capitania Securities | 89,2 951 0,94x 144% = 14.8% 2.7% 2.4%
10% ‘Shoppings ene XPML11. XP Malls 105,1 101,2 1,04x 7.3% 8,0% 10,6% 11,9%
10% —— Recebiveis ea RBRF11 RBR Alpha FoF 775 82,6 0,94x 94% 93% 135%  — 4,5%
Fundo de dito Li
10% Fundos, Renda. RBRR11._-RBRCrédito High Grade 96,4 100,6 0,96x 13,2% 13,7% 0.8% 7.2%
5% Recebiveis Renda RBRY11 «PBR cae Imani 103,7 104,3 0,99x 13,5% — 15,6% = -1,7% 95%
Ganho de
10% Renda Urbana Sanh BRCR11 _BTG Corp. Offices 704 101,0 0,70x 8,2% 80% 248% 2.8%
nee Ganho de ; ; 3 .
10% — Shoppings “2ity)”  VISC11_ Vinci Shopping Centers 112,5 119.5 0,94x 71% 7.6% = 147% == 14,9%

10% Recebiveis Renda HGCR11 — CSHG Rec. Imob. 104,1 102,9 1,01x 12,0% 13,8% 18% 7.3%
";

        using var inputReader = new StringReader(input);
        var leitor = new LeitorRecomendacaoGuide();
        var recomendacao = leitor.Ler(ListaAtivosProvider.Carregar(), inputReader, null, new YearMonth(2022, 9));

        recomendacao.Corretora.Should().Be(leitor.NomeCorretora);
        recomendacao.NomeCarteira.Should().BeNull();
        recomendacao.Carteira.Should().HaveCount(10);
        recomendacao.Carteira[0].Codigo.Should().Be("BRCO11");
        recomendacao.Carteira[1].Codigo.Should().Be("BTLG11");
        recomendacao.Carteira[2].Codigo.Should().Be("CPTS11");
        recomendacao.Carteira[3].Codigo.Should().Be("XPML11");
        recomendacao.Carteira[4].Codigo.Should().Be("RBRF11");
        recomendacao.Carteira[5].Codigo.Should().Be("RBRR11");
        recomendacao.Carteira[6].Codigo.Should().Be("RBRY11");
        recomendacao.Carteira[7].Codigo.Should().Be("BRCR11");
        recomendacao.Carteira[8].Codigo.Should().Be("VISC11");
        recomendacao.Carteira[9].Codigo.Should().Be("HGCR11");
        recomendacao.Carteira[0].Peso.Valor.Should().Be(0.15m);
        recomendacao.Carteira[1].Peso.Valor.Should().Be(0.10m);
        recomendacao.Carteira[2].Peso.Valor.Should().Be(0.10m);
        recomendacao.Carteira[3].Peso.Valor.Should().Be(0.10m);
        recomendacao.Carteira[4].Peso.Valor.Should().Be(0.10m);
        recomendacao.Carteira[5].Peso.Valor.Should().Be(0.10m);
        recomendacao.Carteira[6].Peso.Valor.Should().Be(0.05m);
        recomendacao.Carteira[7].Peso.Valor.Should().Be(0.10m);
        recomendacao.Carteira[8].Peso.Valor.Should().Be(0.10m);
        recomendacao.Carteira[9].Peso.Valor.Should().Be(0.10m);
    }
}