using System.Collections.Immutable;
using ImobFeed.Core.CarteiraMensal;

namespace ImobFeed.Html.Referencia.Modelos;

public sealed record ListaAtivos(DateTimeOffset UltimaAtualizacao, ImmutableArray<Ativo> Ativos);