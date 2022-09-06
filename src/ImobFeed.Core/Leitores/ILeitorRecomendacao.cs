using ImobFeed.Core.CarteiraMensal;
using NodaTime;

namespace ImobFeed.Core.Leitores;

public interface ILeitorRecomendacao
{
    string NomeCorretora { get; }

    Recomendacao Ler(TextReader reader, YearMonth data);
}