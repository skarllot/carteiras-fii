using System.Text.Json.Serialization;
using ImobFeed.Core.CarteiraMensal;

namespace ImobFeed.Html.Leitores.Modelos;

public sealed record ClubeFiiAtivo(
    string Codigo,
    string Nome,
    decimal? ValorCota,
    DateTimeOffset? DataCotacao,
    [property: JsonConverter(typeof(DateOnlyConverter))]
    DateOnly? DataIpo,
    decimal? ValorIpo,
    string Segmento,
    string Administrador);