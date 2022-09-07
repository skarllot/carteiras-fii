using System.IO.Abstractions;
using System.Text;
using ImobFeed.Core.CarteiraMensal;
using NodaTime;
using Validation;

namespace ImobFeed.Core.Leitores;

public class LeitorListaRecomendacao
{
    private readonly YearMonth _data;

    public LeitorListaRecomendacao(YearMonth data)
    {
        _data = data;
    }

    public IEnumerable<Recomendacao> LerTudo(IFileInfo fileInfo)
    {
        Assumes.True(fileInfo.Exists);

        using var fileStream = fileInfo.Open(FileMode.Open, FileAccess.Read);
        using var fileReader = new StreamReader(fileStream, Encoding.UTF8, true);

        while (fileReader.ReadLine() is { } line)
        {
            var leitor = ProvedorLeitorRecomendacao.Buscar(line.Trim());
            if (leitor is null)
                throw Verify.FailOperation("A corretora não foi encontrada: {0}", line);

            string? nomeCarteira = leitor.LerNomeCarteira(fileReader);
            yield return leitor.Ler(fileReader, nomeCarteira, _data);
        }
    }
}