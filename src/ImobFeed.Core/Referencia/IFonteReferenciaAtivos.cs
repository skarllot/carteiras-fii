using ImobFeed.Core.Referencia.Modelos;

namespace ImobFeed.Core.Referencia;

public interface IFonteReferenciaAtivos
{
    (ListaAtivos, ListaIndicadores) BuscarEAgregar();
}