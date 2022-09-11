using ImobFeed.Core.CarteiraMensal;
using Validation;

namespace ImobFeed.Core;

public static class Validar
{
    public static void CodigoAtivo(string codigo)
    {
        Verify.Operation(AtivosClubeFii.ContemAtivo(codigo), "O ativo {0} não foi encontrado");
    }

    public static void PesosAtivos(IEnumerable<AtivoRecomendado> ativos)
    {
        Verify.Operation(Math.Abs(ativos.Sum(it => it.Peso.Valor) - 1f) < 0.001f, "Falha ao ler pesos dos ativos");
    }
}