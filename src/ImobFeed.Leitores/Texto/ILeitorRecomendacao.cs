using ImobFeed.Core.CarteiraMensal;
using NodaTime;

namespace ImobFeed.Leitores.Texto;

public interface ILeitorRecomendacao
{
    string NomeCorretora { get; }

    string? LerNomeCarteira(TextReader reader) => reader.ReadLine();

    Recomendacao Ler(IReadOnlyDictionary<string, Ativo> dictAtivos, TextReader reader, string? nomeCarteira, YearMonth data);
}