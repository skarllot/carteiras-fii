﻿using System.Collections.Immutable;
using ImobFeed.Core;
using ImobFeed.Core.CarteiraMensal;
using NodaTime;

namespace ImobFeed.Leitores.Texto;

public sealed class LeitorRecomendacaoItau : ILeitorRecomendacao
{
    public string NomeCorretora => "Itaú Corretora";
    public string Url => "https://www.itaucorretora.com.br/assessoria/carteira-recomendada-de-fundos-imobiliarios.aspx?ma";

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

            decimal? peso = LeitorCampo.LerPeso(line);
            if (peso is null)
                continue;

            Validar.CodigoAtivo(dictAtivos, codigo);
            carteiraBuilder.Add(new AtivoRecomendado(codigo, new Percentual(peso.Value / 100)));
        }

        Validar.PesosAtivos(carteiraBuilder);
        return new Recomendacao(NomeCorretora, data, nomeCarteira, carteiraBuilder.ToImmutable());
    }
}