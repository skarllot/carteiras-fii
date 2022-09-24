using FluentAssertions;
using ImobFeed.Leitores.Texto;
using NodaTime;

namespace ImobFeed.Core.Tests.Leitores;

public class LeitorRecomendacaoSantanderTests
{
    [Fact]
    public void LerDeveriaRetornarRecomendacao()
    {
        const string input =
            @"Carteira Recomendada
Vinci Logística VILG11 Logístico/Industrial 7,0% 7,0% Renda
Brasil Plural Absoluto F. de Fundos BPFF11 Fundos de Fundos 9,7% 8,1% Renda/Ganho de Capital
RBR Alpha Multiestratégia Real Estate RBRF11 Fundos de Fundos 8,5% 7,9% Renda/Ganho de Capital
VBI CRI CVBI11 Recebíveis Imobiliários 10,0% 9,3% Renda
CSHG Recebíveis Imobiliários HGCR11 Recebíveis Imobiliários 8,7% 8,6% Renda
Mauá Capital Recebíveis Imobiliários MCCI11 Recebíveis Imobiliários 8,0% 8,7% Renda
Maxi Renda MXRF11 Recebíveis Imobiliários 4,0% 7,8% Renda
Santander Renda de Aluguéis SARE11 Híbrido 10,0% 7,5% Renda
TG Ativo Real TGAR11 Híbrido 10,0% 10,0% Renda
TRX Real Estate TRXF11 Híbrido 8,0% 7,9% Renda
CSHG Renda Urbana HGRU11 Híbrido 6,6% 7,0% Renda
JS Real Estate Multigestão JSRE11 Escritórios 1,5% 7,0% Ganho de Capital/Renda
Vinci Offices VINO11 Escritórios 8,0% 8,8% Renda";

        using var inputReader = new StringReader(input);
        var leitor = new LeitorRecomendacaoSantander();
        var recomendacao = leitor.Ler(ListaAtivosProvider.Carregar(), inputReader, inputReader.ReadLine(), new YearMonth(2022, 9));

        recomendacao.Corretora.Should().Be(leitor.NomeCorretora);
        recomendacao.NomeCarteira.Should().Be("Carteira Recomendada");
        recomendacao.Carteira.Should().HaveCount(13);
        recomendacao.Carteira[0].Codigo.Should().Be("VILG11");
        recomendacao.Carteira[1].Codigo.Should().Be("BPFF11");
        recomendacao.Carteira[2].Codigo.Should().Be("RBRF11");
        recomendacao.Carteira[3].Codigo.Should().Be("CVBI11");
        recomendacao.Carteira[4].Codigo.Should().Be("HGCR11");
        recomendacao.Carteira[5].Codigo.Should().Be("MCCI11");
        recomendacao.Carteira[6].Codigo.Should().Be("MXRF11");
        recomendacao.Carteira[7].Codigo.Should().Be("SARE11");
        recomendacao.Carteira[8].Codigo.Should().Be("TGAR11");
        recomendacao.Carteira[9].Codigo.Should().Be("TRXF11");
        recomendacao.Carteira[10].Codigo.Should().Be("HGRU11");
        recomendacao.Carteira[11].Codigo.Should().Be("JSRE11");
        recomendacao.Carteira[12].Codigo.Should().Be("VINO11");
        recomendacao.Carteira[0].Peso.Valor.Should().Be(0.07m);
        recomendacao.Carteira[1].Peso.Valor.Should().Be(0.097m);
        recomendacao.Carteira[2].Peso.Valor.Should().Be(0.085m);
        recomendacao.Carteira[3].Peso.Valor.Should().Be(0.10m);
        recomendacao.Carteira[4].Peso.Valor.Should().Be(0.087m);
        recomendacao.Carteira[5].Peso.Valor.Should().Be(0.08m);
        recomendacao.Carteira[6].Peso.Valor.Should().Be(0.04m);
        recomendacao.Carteira[7].Peso.Valor.Should().Be(0.10m);
        recomendacao.Carteira[8].Peso.Valor.Should().Be(0.10m);
        recomendacao.Carteira[9].Peso.Valor.Should().Be(0.08m);
        recomendacao.Carteira[10].Peso.Valor.Should().Be(0.066m);
        recomendacao.Carteira[11].Peso.Valor.Should().Be(0.015m);
        recomendacao.Carteira[12].Peso.Valor.Should().Be(0.08m);
    }
}