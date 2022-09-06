using System.ComponentModel;

namespace ImobFeed.Core.CarteiraMensal;

public enum Segmento
{
    [Description("Desconhecido")] Desconhecido = 0,
    [Description("Agências Bancárias")] AgenciasBancarias,
    [Description("Agronegócio")] Agronegocio,
    [Description("Educacional")] Educacional,
    [Description("Fundo de Fundos")] FundoDeFundos,
    [Description("Híbrido")] Hibrido,
    [Description("Hospital")] Hospital,
    [Description("Hotéis")] Hoteis,
    [Description("Incorporação")] Incorporacao,
    [Description("Incorporação Residencial")] IncorporacaoResidencial,
    [Description("Lajes Comerciais")] LajesComerciais,
    [Description("Logísticos")] Logisticos,
    [Description("Recebíveis Imobiliários")] RecebiveisImobiliarios,
    [Description("Residencial")] Residencial,
    [Description("Shopping/Varejo")] ShoppingVarejo,
    [Description("Outros")] Outros
}