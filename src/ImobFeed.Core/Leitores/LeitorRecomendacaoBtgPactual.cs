using System.Collections.Immutable;
using System.Globalization;
using ImobFeed.Core.CarteiraMensal;
using ImobFeed.Core.Common;
using NodaTime;

namespace ImobFeed.Core.Leitores;

public sealed class LeitorRecomendacaoBtgPactual : ILeitorRecomendacao
{
    public string NomeCorretora => "BTG Pactual";

    public Recomendacao Ler(TextReader reader, YearMonth data)
    {
        var carteiraBuilder = ImmutableArray.CreateBuilder<AtivoRecomendado>();

        string? nomeCarteira = reader.ReadLine();

        while (reader.ReadLine() is { } line)
        {
            if (string.IsNullOrWhiteSpace(line))
                break;

            int indexSpc = line.IndexOf(' ');
            int indexPct = line.IndexOf('%');

            string codigo = line.Substring(0, indexSpc);
            var pesoBuffer = line.AsSpan(indexSpc + 1, indexPct - indexSpc - 1);
            if (!float.TryParse(pesoBuffer, NumberStyles.Float, CultureCache.PortuguesBrasil, out float peso))
                continue;

            carteiraBuilder.Add(new AtivoRecomendado(codigo, new Percentual(peso / 100)));
        }

        return new Recomendacao(NomeCorretora, data, nomeCarteira, carteiraBuilder.ToImmutable());
    }
}