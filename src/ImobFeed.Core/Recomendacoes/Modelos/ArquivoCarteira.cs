using System.Collections.Immutable;
using ImobFeed.Core.CarteiraMensal;

namespace ImobFeed.Core.Recomendacoes.Modelos;

public sealed record ArquivoCarteira(string? Nome, ImmutableArray<AtivoRecomendado> Ativos);