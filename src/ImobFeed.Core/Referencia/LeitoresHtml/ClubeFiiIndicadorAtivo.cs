namespace ImobFeed.Core.Referencia.LeitoresHtml;

public sealed record ClubeFiiIndicadorAtivo(
    string Codigo,
    decimal PVpa,
    decimal Yield1Mes,
    decimal? Yield12Meses = null);