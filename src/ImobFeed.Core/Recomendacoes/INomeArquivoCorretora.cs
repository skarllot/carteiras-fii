namespace ImobFeed.Core.Recomendacoes;

public interface INomeArquivoCorretora
{
    string BuscaReversaNomeArquivo(string nomeArquivo);
    bool NomeNormalizadoExiste(string nomeArquivo);
}