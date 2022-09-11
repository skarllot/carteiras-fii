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
        decimal sum = ativos.Sum(it => it.Peso.Valor);
        if (sum - 1m >= 0.0001m)
            Verify.FailOperation("Falha ao ler pesos dos ativos: Total {0}%", sum * 100m);
    }
}