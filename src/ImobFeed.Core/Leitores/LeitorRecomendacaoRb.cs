using System.Collections.Immutable;
using ImobFeed.Core.CarteiraMensal;
using NodaTime;

namespace ImobFeed.Core.Leitores;

public sealed class LeitorRecomendacaoRb : ILeitorRecomendacao
{
    public string NomeCorretora => "RB Investimentos";

    public Recomendacao Ler(TextReader reader, string? nomeCarteira, YearMonth data)
    {
        var carteiraBuilder = ImmutableArray.CreateBuilder<AtivoRecomendado>();

        while (reader.ReadLine() is { } line)
        {
            if (string.IsNullOrWhiteSpace(line))
                break;

            string? codigo = LeitorCampo.LerCodigo(line);
            if (codigo is null)
                continue;

            bool hasTwo = line.LastIndexOf(codigo, StringComparison.Ordinal) !=
                          line.IndexOf(codigo, StringComparison.Ordinal);
            if (!hasTwo)
                continue;

            float? peso = LeitorCampo.LerPeso(line, true);
            if (peso is null)
                continue;

            Validar.CodigoAtivo(codigo);
            carteiraBuilder.Add(new AtivoRecomendado(codigo, new Percentual(peso.Value / 100)));
        }

        Validar.PesosAtivos(carteiraBuilder);
        return new Recomendacao(NomeCorretora, data, nomeCarteira, carteiraBuilder.ToImmutable());
    }
}