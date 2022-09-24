using FluentAssertions;
using ImobFeed.Leitores.Texto;
using NodaTime;

namespace ImobFeed.Core.Tests.Leitores;

public class LeitorRecomendacaoMiraeTests
{
    [Fact]
    public void LerDeveriaRetornarRecomendacao()
    {
        const string input =
            @"Carteira Recomendada
BCFF11 FII Bc Ffii 10 66,85
BRCO11 FII Bresco 10 99,99
BTLG11 FII Btlg 10 100,15
HGLG11 FII CSHG Log 10 168,64
FEXC11 FII Excellen 10 87,25
MGFF11 FII Mogno 10 60,00
RBRF11 FII Alpha Multiestrategia Real 10 68,86
TRXF11 FII Trx Real 10 103,20
VISC11 FII Vinci Sc 10 101,39
XPML11 FII Xp Malls 10 95,63";

        using var inputReader = new StringReader(input);
        var leitor = new LeitorRecomendacaoMirae();
        var recomendacao = leitor.Ler(ListaAtivosProvider.Carregar(), inputReader, inputReader.ReadLine(), new YearMonth(2022, 9));

        recomendacao.Corretora.Should().Be(leitor.NomeCorretora);
        recomendacao.NomeCarteira.Should().Be("Carteira Recomendada");
        recomendacao.Carteira.Should().HaveCount(10);
        recomendacao.Carteira[0].Codigo.Should().Be("BCFF11");
        recomendacao.Carteira[1].Codigo.Should().Be("BRCO11");
        recomendacao.Carteira[2].Codigo.Should().Be("BTLG11");
        recomendacao.Carteira[3].Codigo.Should().Be("HGLG11");
        recomendacao.Carteira[4].Codigo.Should().Be("FEXC11");
        recomendacao.Carteira[5].Codigo.Should().Be("MGFF11");
        recomendacao.Carteira[6].Codigo.Should().Be("RBRF11");
        recomendacao.Carteira[7].Codigo.Should().Be("TRXF11");
        recomendacao.Carteira[8].Codigo.Should().Be("VISC11");
        recomendacao.Carteira[9].Codigo.Should().Be("XPML11");
        recomendacao.Carteira[0].Peso.Valor.Should().Be(0.10m);
        recomendacao.Carteira[1].Peso.Valor.Should().Be(0.10m);
        recomendacao.Carteira[2].Peso.Valor.Should().Be(0.10m);
        recomendacao.Carteira[3].Peso.Valor.Should().Be(0.10m);
        recomendacao.Carteira[4].Peso.Valor.Should().Be(0.10m);
        recomendacao.Carteira[5].Peso.Valor.Should().Be(0.10m);
        recomendacao.Carteira[6].Peso.Valor.Should().Be(0.10m);
        recomendacao.Carteira[7].Peso.Valor.Should().Be(0.10m);
        recomendacao.Carteira[8].Peso.Valor.Should().Be(0.10m);
        recomendacao.Carteira[9].Peso.Valor.Should().Be(0.10m);
    }
}