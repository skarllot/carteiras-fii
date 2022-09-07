namespace ImobFeed.Core.Leitores;

public static class ProvedorLeitorRecomendacao
{
    private static readonly Dictionary<string, ILeitorRecomendacao> Leitores =
        TodosLeitores().ToDictionary(it => it.NomeCorretora, StringComparer.OrdinalIgnoreCase);

    private static IEnumerable<ILeitorRecomendacao> TodosLeitores()
    {
        yield return new LeitorRecomendacaoBancoBrasil();
        yield return new LeitorRecomendacaoBtgPactual();
        yield return new LeitorRecomendacaoGenial();
        yield return new LeitorRecomendacaoGuide();
    }

    public static ILeitorRecomendacao? Buscar(string nome)
    {
        return Leitores.TryGetValue(nome, out var resultado) ? resultado : null;
    }
}