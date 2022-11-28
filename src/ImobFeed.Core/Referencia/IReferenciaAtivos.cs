using ImobFeed.Core.Referencia.Modelos;
using NodaTime;

namespace ImobFeed.Core.Referencia;

public interface IReferenciaAtivos
{
    ListaAtivos CarregarAtivos();
    ListaIndicadores CarregarIndicadores(YearMonth data);
}