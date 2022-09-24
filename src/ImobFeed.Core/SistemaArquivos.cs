using System.Diagnostics.CodeAnalysis;
using ImobFeed.Core.Common;

namespace ImobFeed.Core;

public static class SistemaArquivos
{
    [return: NotNullIfNotNull("value")]
    public static string? NormalizarNome(string? value)
    {
        return value
            ?.RemoveDiacritics()
            .ToLowerInvariant()
            .Replace(' ', '-');
    }
}