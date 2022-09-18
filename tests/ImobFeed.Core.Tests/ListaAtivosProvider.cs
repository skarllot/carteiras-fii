﻿using System.Text.Json;
using ImobFeed.Core.CarteiraMensal;
using ImobFeed.Core.Referencia;

namespace ImobFeed.Core.Tests;

public static class ListaAtivosProvider
{
    public static IReadOnlyDictionary<string, Ativo> Carregar()
    {
        string json = StringContent.ListaAtivosJson;
        var listaAtivos = JsonSerializer.Deserialize<ListaAtivos>(
            json,
            new JsonSerializerOptions { PropertyNamingPolicy = JsonNamingPolicy.CamelCase });

        return listaAtivos!.Ativos.ToDictionary(it => it.Codigo, StringComparer.OrdinalIgnoreCase);
    }
}