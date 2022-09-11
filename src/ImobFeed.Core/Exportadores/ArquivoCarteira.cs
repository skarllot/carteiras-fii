using System.Collections.Immutable;
using ImobFeed.Core.CarteiraMensal;

namespace ImobFeed.Core.Exportadores;

public sealed record ArquivoCarteira(string? Nome, ImmutableArray<AtivoRecomendado> Ativos);