using System.Collections.Immutable;
using System.Globalization;
using ImobFeed.Core.CarteiraMensal;
using NodaTime;

namespace ImobFeed.Core.Leitores;

public class LeitorRecomendacaoBancoBrasil : ILeitorRecomendacao
{
    public string NomeCorretora => "BB Investimentos";

    public Recomendacao Ler(TextReader reader, YearMonth data)
    {
        var carteiraBuilder = ImmutableArray.CreateBuilder<AtivoRecomendado>();

        string? nomeCarteira = reader.ReadLine();

        Span<char> codigoBuffer = stackalloc char[] { '\0', '\0', '\0', '\0', '1', '1' };
        while (reader.ReadLine() is { } line)
        {
            if (string.IsNullOrWhiteSpace(line))
                continue;

            int index11 = line.IndexOf("11", StringComparison.Ordinal);
            int indexPct = line.IndexOf("%", StringComparison.Ordinal);
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
                continue;

            var pesoBuffer = line.AsSpan(index11 + 2, indexPct - index11 - 2);
            if (!float.TryParse(pesoBuffer, NumberStyles.Float, CultureCache.PortuguesBrasil, out float peso))
                continue;

            carteiraBuilder.Add(new AtivoRecomendado(codigoBuffer.ToString(), new Percentual(peso / 100)));
        }

        return new Recomendacao(NomeCorretora, data, nomeCarteira, carteiraBuilder.ToImmutable());
    }
}