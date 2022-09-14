using FluentAssertions;
using ImobFeed.Core.Leitores;
using NodaTime;

namespace ImobFeed.Core.Tests.Leitores;

public class LeitorRecomendacaoRbTests
{
    [Fact]
    public void LerDeveriaRetornarRecomendacao()
    {
        const string input =
            @"Carteira Recomendada
5% BRCO11 BRCO11 5%
5% BRCR11 Retirada 5%
5% RFOF11 Aumento 5% RFOF11 10%
10% BTLG11 BTLG11 10%
10% HGCR11 HGCR11 10%
10% JSRE11 JSRE11 10%
15% KNCR11 KNCR11 15%
10% HGBS11 HGBS11 10%
15% HGRU11 HGRU11 15%
15% XPML11 XPML11 15%";

        using var inputReader = new StringReader(input);
        var leitor = new LeitorRecomendacaoRb();
        var recomendacao = leitor.Ler(ListaAtivosProvider.Carregar(), inputReader, inputReader.ReadLine(), new YearMonth(2022, 9));

        recomendacao.Corretora.Should().Be(leitor.NomeCorretora);
        recomendacao.NomeCarteira.Should().Be("Carteira Recomendada");
        recomendacao.Carteira.Should().HaveCount(9);
        recomendacao.Carteira[0].Codigo.Should().Be("BRCO11");
        recomendacao.Carteira[1].Codigo.Should().Be("RFOF11");
        recomendacao.Carteira[2].Codigo.Should().Be("BTLG11");
        recomendacao.Carteira[3].Codigo.Should().Be("HGCR11");
        recomendacao.Carteira[4].Codigo.Should().Be("JSRE11");
        recomendacao.Carteira[5].Codigo.Should().Be("KNCR11");
        recomendacao.Carteira[6].Codigo.Should().Be("HGBS11");
        recomendacao.Carteira[7].Codigo.Should().Be("HGRU11");
        recomendacao.Carteira[8].Codigo.Should().Be("XPML11");
        recomendacao.Carteira[0].Peso.Valor.Should().Be(0.05m);
        recomendacao.Carteira[1].Peso.Valor.Should().Be(0.10m);
        recomendacao.Carteira[2].Peso.Valor.Should().Be(0.10m);
        recomendacao.Carteira[3].Peso.Valor.Should().Be(0.10m);
        recomendacao.Carteira[4].Peso.Valor.Should().Be(0.10m);
        recomendacao.Carteira[5].Peso.Valor.Should().Be(0.15m);
        recomendacao.Carteira[6].Peso.Valor.Should().Be(0.10m);
        recomendacao.Carteira[7].Peso.Valor.Should().Be(0.15m);
        recomendacao.Carteira[8].Peso.Valor.Should().Be(0.15m);
    }
}