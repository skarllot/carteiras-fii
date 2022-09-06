using NodaTime;

namespace ImobFeed.Core.CarteiraMensal;

public sealed record Ativo(
    string Codigo,
    string Nome,
    LocalDate? DataIpo,
    decimal? ValorIpo,
    Segmento Segmento,
    string Administrador);