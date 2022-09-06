using System.Collections.Immutable;
using NodaTime;

namespace ImobFeed.Core.CarteiraMensal;

public record Recomendacao(
    string Corretora,
    YearMonth Data,
    string? NomeCarteira,
    ImmutableArray<AtivoRecomendado> Carteira);