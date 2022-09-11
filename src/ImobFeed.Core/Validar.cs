using ImobFeed.Core.CarteiraMensal;
using Validation;

namespace ImobFeed.Core;

public static class Validar
{
    public static void CodigoAtivo(string codigo)
    {
        Verify.Operation(AtivosClubeFii.ContemAtivo(codigo), "O ativo {0} não foi encontrado", codigo);
    }

    public static void PesosAtivos(IEnumerable<AtivoRecomendado> ativos)
    {
        float sum = ativos.Sum(it => it.Peso.Valor);
        if (Math.Abs(sum - 1f) >= 0.001f)
            Verify.FailOperation("Falha ao ler pesos dos ativos: Total {0}%", sum * 100f);
    }
}