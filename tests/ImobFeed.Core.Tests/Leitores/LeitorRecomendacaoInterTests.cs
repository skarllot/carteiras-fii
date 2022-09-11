using FluentAssertions;
using ImobFeed.Core.Leitores;
using NodaTime;

namespace ImobFeed.Core.Tests.Leitores;

public class LeitorRecomendacaoInterTests
{
    [Fact]
    public void LerDeveriaRetornarRecomendacao()
    {
        const string input =
            @"Carteira
Fundos Imobiliários - Lajes Corporativas
HGRE11 CSHG REAL ESTATE FII 1.637 1.915 138,5 86% 12,5 8,2 17,0 6,8 Compra
Fundos Imobiliários - Shoppings
HGBS11 HEDGE BRASIL SHOPPING FII 2.000 2.163 200,1 92% 9,7 10,1 10,9 7,8 Compra
VISC11 VINCI SHOPPING CENTERS FII 1.554 2.030 108,9 95% 7,4 11,3 19,0 7,8 Compra
Fundos Imobiliários - Galpões
VILG11 VINCI LOGISTICA FII 1.577 1.700 105,3 93% 11,4 5,5 5,2 8,2 Compra
Fundos de Fundos
RBRF11 FII RBR ALPHA FUNDO DE FUNDO 1.009 1.130 73,9 89% 7,1 -0,5 9,5 9,8 Compra
Fundos de Títulos e Valores Mobiliários
KNIP11 KINEA INDICE DE PRECOS FII 7.546 7.610 93,6 99% -4,0 -0,5 3,4 13,3 Compra
RBRR11 FII RBR RENDIMENTO HIGH GRAD 1.010 1.287 97,5 102% -0,8 8,0 16,8 13,5 Compra";

        using var inputReader = new StringReader(input);
        var leitor = new LeitorRecomendacaoInter();
        var recomendacao = leitor.Ler(inputReader, inputReader.ReadLine(), new YearMonth(2022, 9));

        recomendacao.Corretora.Should().Be(leitor.NomeCorretora);
        recomendacao.NomeCarteira.Should().Be("Carteira");
        recomendacao.Carteira.Should().HaveCount(7);
        recomendacao.Carteira[0].Codigo.Should().Be("HGRE11");
        recomendacao.Carteira[1].Codigo.Should().Be("HGBS11");
        recomendacao.Carteira[2].Codigo.Should().Be("VISC11");
        recomendacao.Carteira[3].Codigo.Should().Be("VILG11");
        recomendacao.Carteira[4].Codigo.Should().Be("RBRF11");
        recomendacao.Carteira[5].Codigo.Should().Be("KNIP11");
        recomendacao.Carteira[6].Codigo.Should().Be("RBRR11");
        recomendacao.Carteira[0].Peso.Valor.Should().Be(0.1428571428571428571428571429m);
        recomendacao.Carteira[1].Peso.Valor.Should().Be(0.1428571428571428571428571429m);
        recomendacao.Carteira[2].Peso.Valor.Should().Be(0.1428571428571428571428571429m);
        recomendacao.Carteira[3].Peso.Valor.Should().Be(0.1428571428571428571428571429m);
        recomendacao.Carteira[4].Peso.Valor.Should().Be(0.1428571428571428571428571429m);
        recomendacao.Carteira[5].Peso.Valor.Should().Be(0.1428571428571428571428571429m);
        recomendacao.Carteira[6].Peso.Valor.Should().Be(0.1428571428571428571428571429m);
    }
}