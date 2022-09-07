using System.Collections.Immutable;
using ImobFeed.Core.CarteiraMensal;
using NodaTime;

namespace ImobFeed.Core.Leitores;

public class LeitorRecomendacaoBancoBrasil : ILeitorRecomendacao
{
    public string NomeCorretora => "BB Investimentos";

    public Recomendacao Ler(TextReader reader, string? nomeCarteira, YearMonth data)
    {
        var carteiraBuilder = ImmutableArray.CreateBuilder<AtivoRecomendado>();

        while (reader.ReadLine() is { } line)
        {
            if (string.IsNullOrWhiteSpace(line))
                break;

            string? codigo = LeitorCampo.LerCodigoComEspacos(line);
            if (codigo is null)
                continue;

            float? peso = LeitorCampo.LerPeso(line);
            if (peso is null)
                continue;

            carteiraBuilder.Add(new AtivoRecomendado(codigo, new Percentual(peso.Value / 100)));
        }

        return new Recomendacao(NomeCorretora, data, nomeCarteira, carteiraBuilder.ToImmutable());
    }
}