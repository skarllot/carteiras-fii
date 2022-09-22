using System.Collections.Immutable;

namespace ImobFeed.Api.Indexacao.Modelos;

public sealed record IndiceAno(ImmutableArray<string> Meses);