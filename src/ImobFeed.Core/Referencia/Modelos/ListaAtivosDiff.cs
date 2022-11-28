using System.Collections.Immutable;
using System.ComponentModel;
using ImobFeed.Core.Common;

namespace ImobFeed.Core.Referencia.Modelos;

public sealed record ListaAtivosDiff(
    DateTimeOffset UltimaAtualizacao,
    DateTimeOffset AtualizacaoAnterior,
    ImmutableArray<AlteracaoAtivo> Alteracoes)
{
    public static ListaAtivosDiff Criar(ListaAtivos anterior, ListaAtivos atual)
    {
        var todosCodigos = anterior.Ativos.Select(it => it.Codigo)
            .Concat(atual.Ativos.Select(it => it.Codigo))
            .Distinct(StringComparer.OrdinalIgnoreCase)
            .OrderBy(it => it, StringComparer.OrdinalIgnoreCase)
            .ToList();

        var builder = ImmutableArray.CreateBuilder<AlteracaoAtivo>(todosCodigos.Count);
        var dictAnterior = anterior.ToDictionary();
        var dictAtual = atual.ToDictionary();

        foreach (string codigo in todosCodigos)
        {
            var ativoAnterior = dictAnterior.TryGetValue(codigo);
            var ativoAtual = dictAtual.TryGetValue(codigo);

            if (ativoAnterior is null)
            {
                builder.Add(new AlteracaoAtivo(CollectionChangeAction.Add, null, ativoAtual));
                continue;
            }

            if (ativoAtual is null)
            {
                builder.Add(new AlteracaoAtivo(CollectionChangeAction.Remove, ativoAnterior, null));
                continue;
            }

            if (ativoAnterior != ativoAtual)
            {
                builder.Add(new AlteracaoAtivo(CollectionChangeAction.Refresh, ativoAnterior, ativoAtual));
            }
        }

        return new ListaAtivosDiff(atual.UltimaAtualizacao, anterior.UltimaAtualizacao, builder.ToImmutable());
    }
}