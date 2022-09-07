using System.Collections.Immutable;
using ImobFeed.Core.CarteiraMensal;
using NodaTime;
using Validation;

namespace ImobFeed.Core.Leitores;

public sealed class LeitorRecomendacaoGuide : ILeitorRecomendacao
{
    public string NomeCorretora => "Guide Investimentos";

    public Recomendacao Ler(TextReader reader, string? nomeCarteira, YearMonth data)
    {
        var carteiraBuilder = ImmutableArray.CreateBuilder<AtivoRecomendado>();

        bool needCalc = false;
        while (reader.ReadLine() is { } line)
        {
            if (string.IsNullOrWhiteSpace(line))
                continue;

            int index11 = line.IndexOf("11", StringComparison.Ordinal);
            int indexPct = line.IndexOf('%');
            if (index11 >= 0)
            {
                string? codigo = LeitorCampo.LerCodigo(line);
                if (codigo is null)
                    continue;

                Verify.Operation(AtivosClubeFii.BuscaAtivo(codigo) is not null, "O ativo {0} não foi encontrado");

                float? peso = null;
                if (indexPct < index11)
                    peso = LeitorCampo.LerPeso(line);
                else
                    needCalc = true;

                carteiraBuilder.Add(
                    new AtivoRecomendado(codigo.ToUpperInvariant(), new Percentual(peso.GetValueOrDefault(0) / 100)));
            }
        }

        if (needCalc)
        {
            float soma = carteiraBuilder.Sum(it => it.Peso.Valor);
            Assumes.True(soma < 1f);
            int qtd = carteiraBuilder.Count(it => it.Peso.Valor == 0f);
            Assumes.True(qtd == 1);

            int index = -1;
            for (int i = 0; i < carteiraBuilder.Count; i++)
            {
                if (carteiraBuilder[i].Peso.Valor == 0f)
                    index = i;
            }

            float peso = MathF.Round(1f - soma, 2);
            carteiraBuilder[index] = carteiraBuilder[index] with { Peso = new Percentual(peso) };
        }

        Verify.Operation(Math.Abs(carteiraBuilder.Sum(it => it.Peso.Valor) - 1f) < 0.001f, "Falha ao ler pesos dos ativos");

        return new Recomendacao(NomeCorretora, data, nomeCarteira, carteiraBuilder.ToImmutable());
    }
}