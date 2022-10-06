using System.Collections.Immutable;
using ImobFeed.Core.CarteiraMensal;
using ImobFeed.Core.Referencia;
using ImobFeed.Core.Referencia.Modelos;
using ImobFeed.Html.Leitores;

namespace ImobFeed.Html.Referencia;

public sealed class BuscadorFonteReferenciaAtivos : IFonteReferenciaAtivos
{
    public (ListaAtivos, ListaIndicadores) BuscarEAgregar()
    {
        var fundsExplorerAtivos =
            LeitorFundsExplorer.LerListaAtivos().ToDictionary(it => it.Codigo, StringComparer.Ordinal);
        var fundsExplorerIndicadores =
            LeitorFundsExplorer.LerRanking().ToDictionary(it => it.Codigo, StringComparer.Ordinal);
        var clubeFiiAtivos =
            LeitorClubeFii.LerListaAtivos().ToDictionary(it => it.Codigo, StringComparer.Ordinal);
        var clubeFiiIndicadores =
            LeitorClubeFii.LerRanking().ToDictionary(it => it.Codigo, StringComparer.Ordinal);

        var listaAtivosBuilder = ImmutableArray.CreateBuilder<Ativo>();
        var listaIndicadoresBuilder = ImmutableArray.CreateBuilder<IndicadorAtivo>();
        foreach (string codigo in clubeFiiAtivos.Keys
                     .Concat(fundsExplorerAtivos.Keys)
                     .Concat(fundsExplorerIndicadores.Keys)
                     .Distinct(StringComparer.Ordinal)
                     .OrderBy(it => it, StringComparer.Ordinal))
        {
            var fundsExplorerAtivo = fundsExplorerAtivos.GetValueOrDefault(codigo);
            var fundsExplorerIndicador = fundsExplorerIndicadores.GetValueOrDefault(codigo);
            var clubeFiiAtivo = clubeFiiAtivos.GetValueOrDefault(codigo);
            var clubeFiiIndicador = clubeFiiIndicadores.GetValueOrDefault(codigo);

            listaAtivosBuilder.Add(
                new Ativo(
                    codigo,
                    clubeFiiAtivo?.Nome ?? fundsExplorerAtivo?.Nome ?? "erro",
                    clubeFiiAtivo?.DataIpo,
                    clubeFiiAtivo?.ValorIpo,
                    fundsExplorerIndicador?.Setor ?? clubeFiiAtivo?.Segmento ?? "erro",
                    fundsExplorerAtivo?.Administrador ?? clubeFiiAtivo?.Administrador ?? "erro"));

            listaIndicadoresBuilder.Add(
                new IndicadorAtivo(
                    codigo,
                    fundsExplorerIndicador?.PatrimonioLiquido,
                    fundsExplorerIndicador?.TotalCotas,
                    fundsExplorerIndicador?.Vpa,
                    fundsExplorerIndicador?.PrecoAtual ?? clubeFiiAtivo?.ValorCota,
                    fundsExplorerIndicador?.PVpa ?? clubeFiiIndicador?.PVpa,
                    fundsExplorerIndicador?.DY1Mes ?? clubeFiiIndicador?.Yield1Mes,
                    fundsExplorerIndicador?.DY3Meses,
                    fundsExplorerIndicador?.DY6Meses,
                    fundsExplorerIndicador?.DY12Meses ?? clubeFiiIndicador?.Yield12Meses,
                    fundsExplorerIndicador?.LiquidezDiaAnterior,
                    fundsExplorerIndicador?.UltimoDividendo,
                    fundsExplorerIndicador?.VacanciaFisica,
                    fundsExplorerIndicador?.VacanciaFinanceira,
                    fundsExplorerIndicador?.QuantidadeAtivos));
        }

        return (new ListaAtivos(DateTimeOffset.UtcNow, listaAtivosBuilder.ToImmutable()),
            new ListaIndicadores(DateTimeOffset.UtcNow, listaIndicadoresBuilder.ToImmutable()));
    }
}