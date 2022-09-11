using FluentAssertions;
using ImobFeed.Core.Leitores;
using NodaTime;

namespace ImobFeed.Core.Tests.Leitores;

public class LeitorRecomendacaoRicoTests
{
    [Fact]
    public void LerDeveriaRetornarRecomendacao()
    {
        const string input =
            @"Carteira Recomendada
45,0% 10,0% Recebíveis CPTS11 Capitânia Securities 2.854 90 90 100% 3,4% 4,8% 15,2%
10,0% Recebíveis RBRR11 RBR High Grade 1.289 96 96 100% -1,3% 11,7% 13,6%
25,0% Recebíveis KNCR11 Kinea Rendimentos 4.498 103 101 101% 1,2% 20,8% 13,8%
20,0% 20,0% Ativos Logísticos BRCO11 Bresco Logística 1.569 106 119 89% 6,9% 11,6% 7,0%
20,0% 20,0% Lajes Corporativas PVBI11 VBI Prime Offices 974 97 99 98% 6,3% 11,3% 7,2%
15,0% 15,0% Híbrido HGRU11 CSHG Renda Urbana 2.302 125 118 106% 5,3% 16,6% 8,8%";

        using var inputReader = new StringReader(input);
        var leitor = new LeitorRecomendacaoRico();
        var recomendacao = leitor.Ler(inputReader, inputReader.ReadLine(), new YearMonth(2022, 9));

        recomendacao.Corretora.Should().Be(leitor.NomeCorretora);
        recomendacao.NomeCarteira.Should().Be("Carteira Recomendada");
        recomendacao.Carteira.Should().HaveCount(6);
        recomendacao.Carteira[0].Codigo.Should().Be("CPTS11");
        recomendacao.Carteira[1].Codigo.Should().Be("RBRR11");
        recomendacao.Carteira[2].Codigo.Should().Be("KNCR11");
        recomendacao.Carteira[3].Codigo.Should().Be("BRCO11");
        recomendacao.Carteira[4].Codigo.Should().Be("PVBI11");
        recomendacao.Carteira[5].Codigo.Should().Be("HGRU11");
        recomendacao.Carteira[0].Peso.Valor.Should().Be(0.10m);
        recomendacao.Carteira[1].Peso.Valor.Should().Be(0.10m);
        recomendacao.Carteira[2].Peso.Valor.Should().Be(0.25m);
        recomendacao.Carteira[3].Peso.Valor.Should().Be(0.20m);
        recomendacao.Carteira[4].Peso.Valor.Should().Be(0.20m);
        recomendacao.Carteira[5].Peso.Valor.Should().Be(0.15m);
    }
}