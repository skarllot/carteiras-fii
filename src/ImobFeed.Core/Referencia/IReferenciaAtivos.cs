using ImobFeed.Core.CarteiraMensal;
using NodaTime;

namespace ImobFeed.Core.Referencia;

public interface IReferenciaAtivos
{
    IReadOnlyDictionary<string, Ativo> CarregarAtivos();
    IReadOnlyDictionary<string, IndicadorAtivo> CarregarIndicadores(YearMonth data);
}