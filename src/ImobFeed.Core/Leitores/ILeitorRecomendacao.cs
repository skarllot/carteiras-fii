﻿using ImobFeed.Core.CarteiraMensal;
using NodaTime;

namespace ImobFeed.Core.Leitores;

public interface ILeitorRecomendacao
{
    string NomeCorretora { get; }

    string? LerNomeCarteira(TextReader reader) => reader.ReadLine();

    Recomendacao Ler(IReadOnlyDictionary<string, Ativo> dictAtivos, TextReader reader, string? nomeCarteira, YearMonth data);
}