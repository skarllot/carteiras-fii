using System.Collections.Immutable;
using ImobFeed.Core;
using ImobFeed.Core.CarteiraMensal;
using NodaTime;

namespace ImobFeed.Leitores.Texto;

public sealed class LeitorRecomendacaoWarren : ILeitorRecomendacao
{
    public string NomeCorretora => "Warren";
    public string Url => "https://lp.warren.com.br/hubfs/An%C3%A1lise/Carteiras%20recomendadas%20-%20Maio%20-%202022/Warren%20FIIs%20-%20Maio%202022.pdf";

    public Recomendacao Ler(
        IReadOnlyDictionary<string, Ativo> dictAtivos,
        TextReader reader,
        string? nomeCarteira,
        YearMonth data)
    {
        var carteiraBuilder = ImmutableArray.CreateBuilder<AtivoRecomendado>();

        decimal? peso = null;
        while (reader.ReadLine() is { } line)
        {
            if (string.IsNullOrWhiteSpace(line))
                break;

            if (peso is null)
            {
                peso = LeitorCampo.LerPeso(line);
                continue;
            }

            string? codigo = LeitorCampo.LerCodigo(line);
            if (codigo is null)
            {
                peso = null;
                continue;
            }

            Validar.CodigoAtivo(dictAtivos, codigo);
            carteiraBuilder.Add(new AtivoRecomendado(codigo, new Percentual(peso.Value / 100)));
            peso = null;
        }

        Validar.PesosAtivos(carteiraBuilder);
        return new Recomendacao(NomeCorretora, data, nomeCarteira, carteiraBuilder.ToImmutable());
    }
}