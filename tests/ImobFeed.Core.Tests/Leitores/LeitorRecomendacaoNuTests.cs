using FluentAssertions;
using ImobFeed.Core.Leitores;
using NodaTime;

namespace ImobFeed.Core.Tests.Leitores;

public class LeitorRecomendacaoNuTests
{
    [Fact]
    public void LerDeveriaRetornarRecomendacao()
    {
        const string input =
            @"Carteira Top FII
RBR Rendimento High Grade	RBRR11	12%	Recebíveis	R$96,23	R$99,50	13.21%
Capitânia Securities II	CPTS11	12%	Recebíveis	R$91,45	R$98,00	14.36%
Kinea Securities	KNSC11	12%	Recebíveis	R$85,67	R$92,00	16.37%
Devant Recebíveis Imob. FII	DEVA11	12%	Recebíveis	R$96,61	R$104,00	16.72%
Bresco Logística FII	BRCO11	12%	Logístico	R$109,4	R$113,00	7.03%
BTG Pactual Logística FII	BTLG11	12%	Logístico	R$104,97	R$115,00	8.43%
BTG Pactual Agro Logística	BTAL11	12%	Agronegócio	R$100	R$111,00	9.8%
Vinci Shopping Centers FII	VISC11	12%	Shopping	R$110,85	R$115,00	7.28%
BTG Pactual Corp. Office	BRCR11	4%	Escritório	R$69,45	R$80,00	8.22%";

        using var inputReader = new StringReader(input);
        var leitor = new LeitorRecomendacaoNu();
        var recomendacao = leitor.Ler(ListaAtivosProvider.Carregar(), inputReader, inputReader.ReadLine(), new YearMonth(2022, 9));

        recomendacao.Corretora.Should().Be(leitor.NomeCorretora);
        recomendacao.NomeCarteira.Should().Be("Carteira Top FII");
        recomendacao.Carteira.Should().HaveCount(9);
        recomendacao.Carteira[0].Codigo.Should().Be("RBRR11");
        recomendacao.Carteira[1].Codigo.Should().Be("CPTS11");
        recomendacao.Carteira[2].Codigo.Should().Be("KNSC11");
        recomendacao.Carteira[3].Codigo.Should().Be("DEVA11");
        recomendacao.Carteira[4].Codigo.Should().Be("BRCO11");
        recomendacao.Carteira[5].Codigo.Should().Be("BTLG11");
        recomendacao.Carteira[6].Codigo.Should().Be("BTAL11");
        recomendacao.Carteira[7].Codigo.Should().Be("VISC11");
        recomendacao.Carteira[8].Codigo.Should().Be("BRCR11");
        recomendacao.Carteira[0].Peso.Valor.Should().Be(0.12m);
        recomendacao.Carteira[1].Peso.Valor.Should().Be(0.12m);
        recomendacao.Carteira[2].Peso.Valor.Should().Be(0.12m);
        recomendacao.Carteira[3].Peso.Valor.Should().Be(0.12m);
        recomendacao.Carteira[4].Peso.Valor.Should().Be(0.12m);
        recomendacao.Carteira[5].Peso.Valor.Should().Be(0.12m);
        recomendacao.Carteira[6].Peso.Valor.Should().Be(0.12m);
        recomendacao.Carteira[7].Peso.Valor.Should().Be(0.12m);
        recomendacao.Carteira[8].Peso.Valor.Should().Be(0.04m);
    }
}