using FluentAssertions;
using ImobFeed.Leitores.Texto;
using NodaTime;

namespace ImobFeed.Core.Tests.Leitores;

public class LeitorRecomendacaoGenialTests
{
    [Fact]
    public void LerDeveriaRetornarRecomendacao()
    {
        const string input =
            @"Carteira Renda
HGRE11	CSHG Real Estate	Lajes Comerciais	15%	R$ 142,20	0,88	0,55%	7,59%
BRCO11	Bresco Logística	Logisticos	15%	R$ 109,00	0,92	0,64%	6,84%
HGCR11	CSHG Recebíveis Imobiliários	Recebíveis Imobiliários	20%	R$ 102,85	1,01	1,17%	12,57%
MCCI11	Mauá Capital Recebíveis Imobiliários	Recebíveis Imobiliários	20%	R$ 97,30	1,03	1,13%	12,64%
GALG11	Guardian Logística	Logística	15%	R$ 9,80	0,97	0,84%	10,14%
VISC11	Vinci Shopping Centers	Shopping	15%	R$ 112,35	0,98	0,64%	7,28%";

        using var inputReader = new StringReader(input);
        var leitor = new LeitorRecomendacaoGenial();
        var recomendacao = leitor.Ler(ListaAtivosProvider.Carregar(), inputReader, inputReader.ReadLine(), new YearMonth(2022, 9));

        recomendacao.Corretora.Should().Be(leitor.NomeCorretora);
        recomendacao.NomeCarteira.Should().Be("Carteira Renda");
        recomendacao.Carteira.Should().HaveCount(6);
        recomendacao.Carteira[0].Codigo.Should().Be("HGRE11");
        recomendacao.Carteira[1].Codigo.Should().Be("BRCO11");
        recomendacao.Carteira[2].Codigo.Should().Be("HGCR11");
        recomendacao.Carteira[3].Codigo.Should().Be("MCCI11");
        recomendacao.Carteira[4].Codigo.Should().Be("GALG11");
        recomendacao.Carteira[5].Codigo.Should().Be("VISC11");
        recomendacao.Carteira[0].Peso.Valor.Should().Be(0.15m);
        recomendacao.Carteira[1].Peso.Valor.Should().Be(0.15m);
        recomendacao.Carteira[2].Peso.Valor.Should().Be(0.20m);
        recomendacao.Carteira[3].Peso.Valor.Should().Be(0.20m);
        recomendacao.Carteira[4].Peso.Valor.Should().Be(0.15m);
        recomendacao.Carteira[5].Peso.Valor.Should().Be(0.15m);
    }
}