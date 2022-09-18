using System.Collections.Immutable;
using ImobFeed.Core.CarteiraMensal;

namespace ImobFeed.Core.Referencia;

public sealed record ListaAtivos(DateTimeOffset UltimaAtualizacao, ImmutableArray<Ativo> Ativos);