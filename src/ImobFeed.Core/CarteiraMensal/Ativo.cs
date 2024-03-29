﻿using System.Text.Json.Serialization;

namespace ImobFeed.Core.CarteiraMensal;

public sealed record Ativo(
    string Codigo,
    string Nome,
    [property: JsonConverter(typeof(DateOnlyConverter))]
    DateOnly? DataIpo,
    decimal? ValorIpo,
    string Segmento,
    string Administrador);