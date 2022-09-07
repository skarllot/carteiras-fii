using System.Globalization;
using ImobFeed.Core.Common;

namespace ImobFeed.Core.Leitores;

public static class LeitorCampo
{
    public static string? LerCodigo(string line)
    {
        int index11 = line.IndexOf("11", StringComparison.Ordinal);
        int indexStart = index11 - 4;
        if (indexStart < 0)
            return null;

        return line.Substring(indexStart, 6);
    }

    public static string? LerCodigoComEspacos(string line)
    {
        Span<char> codigoBuffer = stackalloc char[] { '\0', '\0', '\0', '\0', '1', '1' };
        int index11 = line.IndexOf("11", StringComparison.Ordinal);
        var codigoLookup = line.AsSpan(0, index11);
        int position = 3;
        for (int i = codigoLookup.Length - 1; i >= 0; i--)
        {
            char l = codigoLookup[i];
            if (!char.IsLetter(l))
                continue;

            codigoBuffer[position] = l;
            position--;
            if (position < 0)
                break;
        }

        if (position >= 0)
            return null;

        return codigoBuffer.ToString();
    }

    public static float? LerPeso(string line)
    {
        int indexPct = line.IndexOf("%", StringComparison.Ordinal);

        int indexSpc = -2;
        for (int i = indexPct - 1; i >= 0; i--)
        {
            if (char.IsWhiteSpace(line, i))
            {
                indexSpc = i;
                break;
            }

            if (i == 0 && char.IsNumber(line, i))
                indexSpc = -1;
        }

        if (indexSpc == -2)
            return null;

        var pesoBuffer = line.AsSpan(indexSpc + 1, indexPct - indexSpc - 1);
        if (!float.TryParse(pesoBuffer, NumberStyles.Float, CultureCache.PortuguesBrasil, out float peso))
            return null;

        return peso;
    }
}