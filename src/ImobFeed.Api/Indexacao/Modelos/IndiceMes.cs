using System.Collections.Immutable;

namespace ImobFeed.Api.Indexacao.Modelos;

public sealed record IndiceMes(ImmutableArray<InfoCorretora> Corretoras);