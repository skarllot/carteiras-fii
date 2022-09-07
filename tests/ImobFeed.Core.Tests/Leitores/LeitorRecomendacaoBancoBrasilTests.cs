using FluentAssertions;
using ImobFeed.Core.Leitores;
using NodaTime;

namespace ImobFeed.Core.Tests.Leitores;

public class LeitorRecomendacaoBancoBrasilTests
{
    [Fact]
    public void LerDeveriaRetornarRecomendacao()
    {
        const string input =
            @"Carteira FII Renda
Riza Terrax Agronegócios R Z T R 11 12,5% 1,25% 1,29% 1,8 104,39 83,29 104,39 1,06 3.027 3,8% 10,7% 23,2% 1,2% 7,2% 13,5%
RBR Alpha FOF R BR F11 12,5% 1,00% 0,95% 4,9 77,49 62,14 77,49 0,94 2.301 13,5% 14,4% 7,1% 0,8% 4,8% 9,4%
XP Selection FOF XPSF11 12,5% 1,00% 0,30% 2,5 7,91 6,36 7,91 0,93 643 10,3% 15,9% 4,1% 0,9% 5,2% 10,4%
BTG Log Logística BT LG11 12,5% 0,90% 1,56% 12,0 103,95 89,58 103,95 1,06 3.920 4,6% 5,7% 6,7% 0,7% 4,3% 8,4%
Banestes Rec Recebíveis BCR I 11 12,5% 1,20% 0,58% 7,2 104,98 91,90 107,64 0,99 984 -1,5% 2,1% 10,6% 1,3% 7,7% 14,5%
CSHG Receb Recebíveis HGCR 11 12,5% 1,00% 1,32% 12,1 104,05 90,75 104,10 1,02 2.982 1,8% 6,1% 13,1% 1,2% 6,5% 12,0%
Kinea Rendim Recebíveis KNCR 11 12,5% 1,20% 3,56% 9,8 103,00 85,09 103,00 1,02 8.271 1,7% 9,4% 19,8% 1,1% 5,9% 9,7%
REC Recebív Recebíveis R ECR 11 12,5% 0,50% 2,24% 4,7 93,28 85,75 98,86 0,98 5.538 -2,7% 1,7% 3,6% 1,1% 8,5% 16,0%";

        using var inputReader = new StringReader(input);
        var leitor = new LeitorRecomendacaoBancoBrasil();
        var recomendacao = leitor.Ler(inputReader, inputReader.ReadLine(), new YearMonth(2022, 9));

        recomendacao.Corretora.Should().Be(leitor.NomeCorretora);
        recomendacao.NomeCarteira.Should().Be("Carteira FII Renda");
        recomendacao.Carteira.Should().HaveCount(8);
        recomendacao.Carteira[0].Codigo.Should().Be("RZTR11");
        recomendacao.Carteira[1].Codigo.Should().Be("RBRF11");
        recomendacao.Carteira[2].Codigo.Should().Be("XPSF11");
        recomendacao.Carteira[3].Codigo.Should().Be("BTLG11");
        recomendacao.Carteira[4].Codigo.Should().Be("BCRI11");
        recomendacao.Carteira[5].Codigo.Should().Be("HGCR11");
        recomendacao.Carteira[6].Codigo.Should().Be("KNCR11");
        recomendacao.Carteira[7].Codigo.Should().Be("RECR11");
        recomendacao.Carteira[0].Peso.Valor.Should().Be(0.125f);
        recomendacao.Carteira[1].Peso.Valor.Should().Be(0.125f);
        recomendacao.Carteira[2].Peso.Valor.Should().Be(0.125f);
        recomendacao.Carteira[3].Peso.Valor.Should().Be(0.125f);
        recomendacao.Carteira[4].Peso.Valor.Should().Be(0.125f);
        recomendacao.Carteira[5].Peso.Valor.Should().Be(0.125f);
        recomendacao.Carteira[6].Peso.Valor.Should().Be(0.125f);
        recomendacao.Carteira[7].Peso.Valor.Should().Be(0.125f);
    }
}