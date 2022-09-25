using ImobFeed.Core.CarteiraMensal;

namespace ImobFeed.Core.Referencia;

public interface IReferenciaAtivos
{
    IReadOnlyDictionary<string, Ativo> CarregarAtivos();
    IReadOnlyDictionary<string, IndicadorAtivo> CarregarIndicadores();
}