﻿using System.Globalization;
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

    public static decimal? LerPeso(string line, bool isLast = false)
    {
        int indexPct = isLast
            ? line.LastIndexOf("%", StringComparison.Ordinal)
            : line.IndexOf("%", StringComparison.Ordinal);

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
        if (!decimal.TryParse(pesoBuffer, NumberStyles.Float, CultureCache.PortuguesBrasil, out decimal peso))
            return null;

        return peso;
    }

    public static decimal? LerPesoNumero(string line, int skip)
    {
        int iniIndex = -1;
        int finIndex = -1;
        int i = 0;
        while (skip >= 0)
        {
            bool waitSpace = false;
            for (; i < line.Length; i++)
            {
                char c = line[i];
                if (char.IsWhiteSpace(c))
                {
                    if (iniIndex != -1)
                        break;

                    waitSpace = false;
                    continue;
                }

                if (!char.IsNumber(c) && c != ',')
                {
                    iniIndex = -1;
                    finIndex = -1;
                    waitSpace = true;
                    continue;
                }

                if (waitSpace)
                    continue;

                if (iniIndex == -1)
                    iniIndex = i;
                else
                    finIndex = i;
            }

            if (iniIndex < 0 || finIndex <= iniIndex)
                return null;

            skip--;
            i = finIndex + 1;
        }

        var pesoBuffer = line.AsSpan(iniIndex, finIndex - iniIndex + 1);
        if (!decimal.TryParse(pesoBuffer, NumberStyles.Float, CultureCache.PortuguesBrasil, out decimal peso))
            return null;

        return peso;
    }
}