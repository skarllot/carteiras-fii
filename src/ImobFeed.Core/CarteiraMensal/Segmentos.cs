using System.ComponentModel;
using System.Reflection;

namespace ImobFeed.Core.CarteiraMensal;

public static class Segmentos
{
    private static readonly Dictionary<string, Segmento> _segmentos = Criar();

    public static Segmento BuscaSegmento(string valor)
    {
        if (_segmentos.TryGetValue(valor, out Segmento encontrado))
            return encontrado;

        return Segmento.Desconhecido;
    }

    private static Dictionary<string, Segmento> Criar()
    {
        var result = new Dictionary<string, Segmento>(StringComparer.OrdinalIgnoreCase);
        var enumValues = Enum.GetValues<Segmento>();
        foreach (var segmento in enumValues)
        {
            result.TryAdd(segmento.ToString(), segmento);

            string? description = typeof(Segmento)
                .GetMember(segmento.ToString())
                .First(it => it.DeclaringType == typeof(Segmento))
                .GetCustomAttribute<DescriptionAttribute>()
                ?.Description;
            if (description is null)
                continue;

            result.TryAdd(description, segmento);
        }

        return result;
    }
}