using System.Collections.Immutable;

namespace ImobFeed.Api.Indexacao.Modelos;

public sealed record IndiceCorretora(ImmutableArray<InfoCarteira> Carteiras);