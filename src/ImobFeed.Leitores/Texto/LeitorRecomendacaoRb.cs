﻿using System.Collections.Immutable;
using ImobFeed.Core;
using ImobFeed.Core.CarteiraMensal;
using NodaTime;

namespace ImobFeed.Leitores.Texto;

public sealed class LeitorRecomendacaoRb : ILeitorRecomendacao
{
    public string NomeCorretora => "RB Investimentos";
    public string Url => "https://www.rbinvestimentos.com/rb-trends/carteira-de-fundos-imobiliarios-setembro-2022";

    public Recomendacao Ler(
        IReadOnlyDictionary<string, Ativo> dictAtivos,
        TextReader reader,
        string? nomeCarteira,
        YearMonth data)
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
            if (!hasTwo && !line.Contains("entrada", StringComparison.OrdinalIgnoreCase))
                continue;

            decimal? peso = LeitorCampo.LerPeso(line, true);
            if (peso is null)
                continue;

            Validar.CodigoAtivo(dictAtivos, codigo);
            carteiraBuilder.Add(new AtivoRecomendado(codigo, new Percentual(peso.Value / 100)));
        }

        Validar.PesosAtivos(carteiraBuilder);
        return new Recomendacao(NomeCorretora, data, nomeCarteira, carteiraBuilder.ToImmutable());
    }
}