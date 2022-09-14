using FluentAssertions;
using ImobFeed.Core.Leitores;
using NodaTime;

namespace ImobFeed.Core.Tests.Leitores;

public class LeitorRecomendacaoOramaTests
{
    [Fact]
    public void LerDeveriaRetornarRecomendacao()
    {
        const string input =
            @"Carteira Moderada
BRCR11 BC Fund Lajes Corporativas 5% 8,22% R$ 91,10 29,40% Compra
HGRE11 CSHG Real Estate Lajes Corporativas 5% 7,48% R$ 158,37 10,76% Compra
JSRE11 JS Real Estate Lajes Corporativas 5% 7,05% R$ 100,80 15,45% Compra
HGRU11 CSHG Renda Urbana Varejo/Educacional 10% 7,54% R$ 129,65 1,38% Compra
BTLG11 BTG Logístico Logístico 10% 8,43% R$ 119,74 15,19% Compra
TRXF11 TRX Real Estate Varejo/Logístico 10% 8,94% R$ 115,52 4,94% Compra
DEVA11 Devant Recebíveis Recebíveis 10% 16,72%
RBRY11 RBR Crédito Imob Recebíveis 10% 13,47%
VGIR11 Valora RE III Recebíveis 15% 12,15% R$ 110,05 9,72% Compra
RBHG11 Rio Bravo High Grade Recebíveis 10% 15,43% R$ 106,70 20,63% Compra
RZAK11 Riza Akin Recebíveis 10% 15,43% R$ 110,81 11,57% Compra";

        using var inputReader = new StringReader(input);
        var leitor = new LeitorRecomendacaoOrama();
        var recomendacao = leitor.Ler(ListaAtivosProvider.Carregar(), inputReader, inputReader.ReadLine(), new YearMonth(2022, 9));

        recomendacao.Corretora.Should().Be(leitor.NomeCorretora);
        recomendacao.NomeCarteira.Should().Be("Carteira Moderada");
        recomendacao.Carteira.Should().HaveCount(11);
        recomendacao.Carteira[0].Codigo.Should().Be("BRCR11");
        recomendacao.Carteira[1].Codigo.Should().Be("HGRE11");
        recomendacao.Carteira[2].Codigo.Should().Be("JSRE11");
        recomendacao.Carteira[3].Codigo.Should().Be("HGRU11");
        recomendacao.Carteira[4].Codigo.Should().Be("BTLG11");
        recomendacao.Carteira[5].Codigo.Should().Be("TRXF11");
        recomendacao.Carteira[6].Codigo.Should().Be("DEVA11");
        recomendacao.Carteira[7].Codigo.Should().Be("RBRY11");
        recomendacao.Carteira[8].Codigo.Should().Be("VGIR11");
        recomendacao.Carteira[9].Codigo.Should().Be("RBHG11");
        recomendacao.Carteira[10].Codigo.Should().Be("RZAK11");
        recomendacao.Carteira[0].Peso.Valor.Should().Be(0.05m);
        recomendacao.Carteira[1].Peso.Valor.Should().Be(0.05m);
        recomendacao.Carteira[2].Peso.Valor.Should().Be(0.05m);
        recomendacao.Carteira[3].Peso.Valor.Should().Be(0.10m);
        recomendacao.Carteira[4].Peso.Valor.Should().Be(0.10m);
        recomendacao.Carteira[5].Peso.Valor.Should().Be(0.10m);
        recomendacao.Carteira[6].Peso.Valor.Should().Be(0.10m);
        recomendacao.Carteira[7].Peso.Valor.Should().Be(0.10m);
        recomendacao.Carteira[8].Peso.Valor.Should().Be(0.15m);
        recomendacao.Carteira[9].Peso.Valor.Should().Be(0.10m);
        recomendacao.Carteira[10].Peso.Valor.Should().Be(0.10m);
    }
}