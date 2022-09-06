using FluentAssertions;
using ImobFeed.Core.Leitores;
using NodaTime;

namespace ImobFeed.Core.Tests.Leitores;

public class LeitorRecomendacaoBtgPactualTests
{
    [Fact]
    public void LerDeveriaRetornarRecomendacao()
    {
        const string input =
            @"Carteira Recomendada
BTCR11 12,5% BTG Pactual Recebíveis 92,4 95,0 0,97x -2,6% 13,3% 14,3% 14,3%
RBRR11 5,0% RBR Asset Recebíveis 96,4 95,7 1,01x -0,8% 12,5% 13,7% 13,2%
KNCR11 17,5% Kinea Recebíveis 103,0 101,4 1,02x 1,7% 19,8% 15,1% 13,9%
FEXC11 2,5% BTG Pactual Recebíveis 85,6 92,0 0,93x -0,7% 11,1% 14,7% 15,4%
CPTS11 12,5% Capitânia Recebíveis 89,2 89,9 0,99x 2,7% 4,2% 14,8% 14,1%
HGCR11 5,0% CSHG Recebíveis 104,1 101,7 1,02x 1,8% 13,1% 13,8% 13,3%
VILG11 7,5% Vinci Galpões Logísticos 107,8 113,4 0,95x 15,0% 9,9% 8,0% 7,4%
HSLG11 7,5% HSI Galpões Logísticos 96,1 105,4 0,91x 14,0% 10,8% 8,6% 8,7%
BRCO11 2,5% Bresco Galpões Logísticos 109,0 119,0 0,92x 9,7% 15,4% 7,7% 6,9%
RBRP11 4,0% RBR Asset Híbrido 61,5 82,2 0,75x 21,6% -16,4% 8,8% 6,5%
BRCR11 8,0% BTG Pactual Lajes Corporativas 70,4 101,0 0,70x 24,9% -1,4% 8,0% 7,8%
RCRB11 5,0% Rio Bravo Lajes Corporativas 139,0 194,8 0,71x 11,9% 4,5% 6,2% 5,9%
HGRE11 8,0% CSHG Lajes Corporativas 143,0 162,0 0,88x 16,9% 16,7% 6,5% 6,5%
BTRA11 2,5% BTG Pactual Agronegócio 90,7 103,8 0,87x 17,1% - 9,3% 9,3%";

        using var inputReader = new StringReader(input);
        var leitor = new LeitorRecomendacaoBtgPactual();
        var recomendacao = leitor.Ler(inputReader, new YearMonth(2022, 9));

        recomendacao.Corretora.Should().Be(leitor.NomeCorretora);
        recomendacao.NomeCarteira.Should().Be("Carteira Recomendada");
        recomendacao.Carteira.Should().HaveCount(14);
        recomendacao.Carteira[0].Codigo.Should().Be("BTCR11");
        recomendacao.Carteira[1].Codigo.Should().Be("RBRR11");
        recomendacao.Carteira[2].Codigo.Should().Be("KNCR11");
        recomendacao.Carteira[3].Codigo.Should().Be("FEXC11");
        recomendacao.Carteira[4].Codigo.Should().Be("CPTS11");
        recomendacao.Carteira[5].Codigo.Should().Be("HGCR11");
        recomendacao.Carteira[6].Codigo.Should().Be("VILG11");
        recomendacao.Carteira[7].Codigo.Should().Be("HSLG11");
        recomendacao.Carteira[8].Codigo.Should().Be("BRCO11");
        recomendacao.Carteira[9].Codigo.Should().Be("RBRP11");
        recomendacao.Carteira[10].Codigo.Should().Be("BRCR11");
        recomendacao.Carteira[11].Codigo.Should().Be("RCRB11");
        recomendacao.Carteira[12].Codigo.Should().Be("HGRE11");
        recomendacao.Carteira[13].Codigo.Should().Be("BTRA11");
        recomendacao.Carteira[0].Peso.Valor.Should().Be(0.125f);
        recomendacao.Carteira[1].Peso.Valor.Should().Be(0.050f);
        recomendacao.Carteira[2].Peso.Valor.Should().Be(0.175f);
        recomendacao.Carteira[3].Peso.Valor.Should().Be(0.025f);
        recomendacao.Carteira[4].Peso.Valor.Should().Be(0.125f);
        recomendacao.Carteira[5].Peso.Valor.Should().Be(0.050f);
        recomendacao.Carteira[6].Peso.Valor.Should().Be(0.075f);
        recomendacao.Carteira[7].Peso.Valor.Should().Be(0.075f);
        recomendacao.Carteira[8].Peso.Valor.Should().Be(0.025f);
        recomendacao.Carteira[9].Peso.Valor.Should().Be(0.040f);
        recomendacao.Carteira[10].Peso.Valor.Should().Be(0.080f);
        recomendacao.Carteira[11].Peso.Valor.Should().Be(0.050f);
        recomendacao.Carteira[12].Peso.Valor.Should().Be(0.080f);
        recomendacao.Carteira[13].Peso.Valor.Should().Be(0.025f);
    }
}