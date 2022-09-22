using System.Collections.Immutable;

namespace ImobFeed.Api.Indexacao.Modelos;

public sealed record IndiceRaiz(ImmutableArray<string> Anos, ImmutableArray<InfoTop> Tops);