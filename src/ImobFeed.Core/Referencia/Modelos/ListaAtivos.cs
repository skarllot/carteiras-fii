using System.Collections.Immutable;
using ImobFeed.Core.CarteiraMensal;

namespace ImobFeed.Core.Referencia.Modelos;

public sealed record ListaAtivos(DateTimeOffset UltimaAtualizacao, ImmutableArray<Ativo> Ativos)
{
    public IReadOnlyDictionary<string, Ativo> ToDictionary()
    {
        return Ativos.IsDefaultOrEmpty is false
            ? Ativos.ToDictionary(it => it.Codigo, StringComparer.OrdinalIgnoreCase)
            : new Dictionary<string, Ativo>();
    }
}