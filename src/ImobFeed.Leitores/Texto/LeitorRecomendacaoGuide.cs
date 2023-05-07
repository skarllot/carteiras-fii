using System.Collections.Immutable;
using ImobFeed.Core;
using ImobFeed.Core.CarteiraMensal;
using NodaTime;
using Validation;

namespace ImobFeed.Leitores.Texto;

public sealed class LeitorRecomendacaoGuide : ILeitorRecomendacao
{
    public string NomeCorretora => "Guide Investimentos";
    public string Url => "https://www.oguiafinanceiro.com.br/temas_app/recomendacoes-de-investimentos/";

    public Recomendacao Ler(
        IReadOnlyDictionary<string, Ativo> dictAtivos,
        TextReader reader,
        string? nomeCarteira,
        YearMonth data)
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

                Validar.CodigoAtivo(dictAtivos, codigo);

                decimal? peso = null;
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
            decimal soma = carteiraBuilder.Sum(it => it.Peso.Valor);
            Assumes.True(soma < 1m);
            int qtd = carteiraBuilder.Count(it => it.Peso.Valor == 0m);
            Assumes.True(qtd == 1);

            int index = -1;
            for (int i = 0; i < carteiraBuilder.Count; i++)
            {
                if (carteiraBuilder[i].Peso.Valor == 0m)
                    index = i;
            }

            decimal peso = 1m - soma;
            carteiraBuilder[index] = carteiraBuilder[index] with { Peso = new Percentual(peso) };
        }

        Validar.PesosAtivos(carteiraBuilder);
        return new Recomendacao(NomeCorretora, data, nomeCarteira, carteiraBuilder.ToImmutable());
    }
}