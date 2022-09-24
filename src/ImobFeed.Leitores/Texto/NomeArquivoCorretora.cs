using ImobFeed.Core.Recomendacoes;

namespace ImobFeed.Leitores.Texto;

public sealed class NomeArquivoCorretora : INomeArquivoCorretora
{
    public string BuscaReversaNomeArquivo(string nomeArquivo)
    {
        return ProvedorLeitorRecomendacao.BuscaReversaNomeArquivo(nomeArquivo);
    }

    public bool NomeNormalizadoExiste(string nomeArquivo)
    {
        return ProvedorLeitorRecomendacao.NomeNormalizadoExiste(nomeArquivo);
    }
}