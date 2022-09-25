namespace ImobFeed.Html.Leitores.Modelos;

public sealed record ClubeFiiIndicadorAtivo(
    string Codigo,
    decimal PVpa,
    decimal Yield1Mes,
    decimal? Yield12Meses = null);