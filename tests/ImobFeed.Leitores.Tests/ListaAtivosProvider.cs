using System.Text.Json;
using ImobFeed.Core.CarteiraMensal;

namespace ImobFeed.Core.Tests;

public static class ListaAtivosProvider
{
    public static IReadOnlyDictionary<string, Ativo> Carregar()
    {
        string json = StringContent.ListaAtivosJson;
        var listaAtivos = JsonSerializer.Deserialize<List<Ativo>>(
            json,
            new JsonSerializerOptions { PropertyNamingPolicy = JsonNamingPolicy.CamelCase });

        return listaAtivos!.ToDictionary(it => it.Codigo, StringComparer.OrdinalIgnoreCase);
    }
}