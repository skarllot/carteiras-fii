using System.Collections.Immutable;
using ImobFeed.Core.CarteiraMensal;
using NodaTime;

namespace ImobFeed.Core.Leitores;

public sealed class LeitorRecomendacaoInter : ILeitorRecomendacao
{
    public string NomeCorretora => "Inter Invest";

    public Recomendacao Ler(TextReader reader, string? nomeCarteira, YearMonth data)
    {
        var carteiraBuilder = ImmutableArray.CreateBuilder<AtivoRecomendado>();

        while (reader.ReadLine() is { } line)
        {
            if (string.IsNullOrWhiteSpace(line))
                break;

            if (!line.Contains("Compra", StringComparison.Ordinal))
                continue;

            string? codigo = LeitorCampo.LerCodigo(line);
            if (codigo is null)
                continue;

            Validar.CodigoAtivo(codigo);
            carteiraBuilder.Add(new AtivoRecomendado(codigo, default));
        }

        decimal peso = 1m / carteiraBuilder.Count;
        for (int i = 0; i < carteiraBuilder.Count; i++)
        {
            carteiraBuilder[i] = carteiraBuilder[i] with { Peso = new Percentual(peso) };
        }

        Validar.PesosAtivos(carteiraBuilder);
        return new Recomendacao(NomeCorretora, data, nomeCarteira, carteiraBuilder.ToImmutable());
    }
}