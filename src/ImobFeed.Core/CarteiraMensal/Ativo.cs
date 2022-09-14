﻿using System.Text.Json.Serialization;

namespace ImobFeed.Core.CarteiraMensal;

public sealed record Ativo(
    string Codigo,
    string Nome,
    decimal? ValorCota,
    DateTimeOffset? DataCotacao,
    [property: JsonConverter(typeof(DateOnlyConverter))]
    DateOnly? DataIpo,
    decimal? ValorIpo,
    string Segmento,
    string Administrador,
    decimal? PVpa = null,
    decimal? Yield1Mes = null,
    decimal? Yield12Meses = null);