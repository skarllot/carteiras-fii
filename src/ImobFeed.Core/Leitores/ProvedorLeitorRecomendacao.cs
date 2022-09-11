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
        yield return new LeitorRecomendacaoInter();
        yield return new LeitorRecomendacaoItau();
        yield return new LeitorRecomendacaoMirae();
        yield return new LeitorRecomendacaoNu();
        yield return new LeitorRecomendacaoRb();
        yield return new LeitorRecomendacaoOrama();
        yield return new LeitorRecomendacaoSantander();
        yield return new LeitorRecomendacaoRico();
    }

    public static ILeitorRecomendacao? Buscar(string nome)
    {
        return Leitores.TryGetValue(nome, out var resultado) ? resultado : null;
    }
}