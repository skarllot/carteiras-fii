using System.Collections.Immutable;
using ImobFeed.Core.Analise.Modelos;
using ImobFeed.Core.CarteiraMensal;
using NodaTime;

namespace ImobFeed.Core.Analise;

public class CalculadoraIndicacoesFavoritas
{
    public ListaIndicacoesFavoritas Calcular(
        IReadOnlyDictionary<string, Ativo> dictAtivos,
        IReadOnlyDictionary<string, IndicadorAtivo> dictIndicadores,
        YearMonth data,
        IEnumerable<CarteiraCorretora> carteiras)
    {
        return Calcular(dictAtivos, dictIndicadores, data, carteiras.ToList());
    }

    private ListaIndicacoesFavoritas Calcular(
        IReadOnlyDictionary<string, Ativo> dictAtivos,
        IReadOnlyDictionary<string, IndicadorAtivo> dictIndicadores,
        YearMonth data,
        List<CarteiraCorretora> carteiras)
    {
        decimal pesoCorretora = 1m / carteiras
            .DistinctBy(it => it.Corretora, StringComparer.Ordinal)
            .Count();

        var indicacoes = carteiras
            .GroupBy(it => it.Corretora)
            .Select(it => (Corretora: it.Key, QtdCarteiras: it.Count(), Carteiras: it.Select(x => x.Carteira)))
            .SelectMany(it => it.Carteiras.Select(x => (it.Corretora, PesoCarteira: 1m / it.QtdCarteiras, Carteira: x)))
            .SelectMany(
                it => it.Carteira.Ativos.Select(
                    x => (it.Corretora,
                        x.Codigo,
                        Peso: x.Peso.Valor * it.PesoCarteira * pesoCorretora)))
            .GroupBy(it => it.Codigo, StringComparer.Ordinal)
            .Select(
                it =>
                {
                    var ativo = dictAtivos[it.Key];
                    var indicador = dictIndicadores.GetValueOrDefault(it.Key);

                    return new IndicacaoFavorita(
                        ativo.Codigo,
                        ativo.Nome,
                        ativo.Segmento,
                        ativo.Administrador,
                        indicador?.Vpa,
                        indicador?.PVpa,
                        indicador?.Yield1Mes,
                        indicador?.Yield12Meses,
                        Math.Round(it.Sum(x => x.Peso), 4),
                        it.Select(x => x.Corretora).Distinct().ToImmutableArray());
                })
            .OrderByDescending(it => it.Peso)
            .ToImmutableArray();

        return new ListaIndicacoesFavoritas(data.Year, data.Month, indicacoes);
    }
}