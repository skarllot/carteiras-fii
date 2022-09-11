using FluentAssertions;
using ImobFeed.Core.Leitores;
using NodaTime;

namespace ImobFeed.Core.Tests.Leitores;

public class LeitorRecomendacaoItauTests
{
    [Fact]
    public void LerDeveriaRetornarRecomendacao()
    {
        const string input =
            @"Carteira Recomendada
CSHG Renda Urbana HGRU11 Misto 10,00% 4,0 2,4 1,08 06/02/2020
HSI Malls HSML11 Shopping Center 5,00% 2,4 1,4 0,92 21/03/2022
Vinci Logística VILG11 Logístico 10,00% 2,1 1,6 0,95 10/08/2020
Bresco Logística BRCO11 Logístico 10,00% 2,6 1,6 0,92 15/08/2021
VBI Log LVBI11 Logístico 10,00% 2,1 1,3 0,98 07/06/2021
VBI Prime Properties PVBI11 Lajes corporativas 5,00% 3,2 1,0 1,00 21/03/2022
RBR Properties RBRP11 Misto 5,00% 1,4 0,7 0,75 18/11/2020
Kinea Índice de Preços KNIP11 Ativos Financeiros 11,25% 11,8 7,5 0,99 06/04/2020
CSHG Recebíveis Imobiliários HGCR11 Ativos Financeiros 11,25% 2,8 1,5 1,02 06/04/2020
Kinea High Yield KNHY11 Ativos Financeiros 11,25% 2,8 1,8 1,01 15/08/2021
Kinea Rendimentos Imobiliários KNCR11 Ativos Financeiros 11,25% 7,9 4,5 1,02 14/09/2021";

        using var inputReader = new StringReader(input);
        var leitor = new LeitorRecomendacaoItau();
        var recomendacao = leitor.Ler(inputReader, inputReader.ReadLine(), new YearMonth(2022, 9));

        recomendacao.Corretora.Should().Be(leitor.NomeCorretora);
        recomendacao.NomeCarteira.Should().Be("Carteira Recomendada");
        recomendacao.Carteira.Should().HaveCount(11);
        recomendacao.Carteira[0].Codigo.Should().Be("HGRU11");
        recomendacao.Carteira[1].Codigo.Should().Be("HSML11");
        recomendacao.Carteira[2].Codigo.Should().Be("VILG11");
        recomendacao.Carteira[3].Codigo.Should().Be("BRCO11");
        recomendacao.Carteira[4].Codigo.Should().Be("LVBI11");
        recomendacao.Carteira[5].Codigo.Should().Be("PVBI11");
        recomendacao.Carteira[6].Codigo.Should().Be("RBRP11");
        recomendacao.Carteira[7].Codigo.Should().Be("KNIP11");
        recomendacao.Carteira[8].Codigo.Should().Be("HGCR11");
        recomendacao.Carteira[9].Codigo.Should().Be("KNHY11");
        recomendacao.Carteira[10].Codigo.Should().Be("KNCR11");
        recomendacao.Carteira[0].Peso.Valor.Should().Be(0.10m);
        recomendacao.Carteira[1].Peso.Valor.Should().Be(0.05m);
        recomendacao.Carteira[2].Peso.Valor.Should().Be(0.10m);
        recomendacao.Carteira[3].Peso.Valor.Should().Be(0.10m);
        recomendacao.Carteira[4].Peso.Valor.Should().Be(0.10m);
        recomendacao.Carteira[5].Peso.Valor.Should().Be(0.05m);
        recomendacao.Carteira[6].Peso.Valor.Should().Be(0.05m);
        recomendacao.Carteira[7].Peso.Valor.Should().Be(0.1125m);
        recomendacao.Carteira[8].Peso.Valor.Should().Be(0.1125m);
        recomendacao.Carteira[9].Peso.Valor.Should().Be(0.1125m);
        recomendacao.Carteira[10].Peso.Valor.Should().Be(0.1125m);
    }
}