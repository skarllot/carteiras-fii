using System.Collections.Immutable;
using System.Globalization;
using System.IO.Abstractions;
using System.Text.Json;
using HtmlAgilityPack;
using ImobFeed.Core.CarteiraMensal;
using ImobFeed.Core.Common;

namespace ImobFeed.Core.Analise;

public sealed class AtivosClubeFii
{
    private const string ClubeFiiListaUrl = "https://clubefii.com.br/fundo_imobiliario_lista#";
    private const string ClubeFiiRankingUrl = "https://clubefii.com.br/fundos_imobiliarios_ranking";

    private readonly IFileSystem _fileSystem;

    public AtivosClubeFii(IFileSystem fileSystem)
    {
        _fileSystem = fileSystem;
    }

    public void Atualizar(IDirectoryInfo baseDirectory, IProgress<string> progress)
    {
        var dictAtivos = BaixarListaAtivos().ToDictionary(it => it.Codigo, StringComparer.Ordinal);
        BaixarRankingAtivos(dictAtivos);

        var listaAtivos = new ListaAtivos(
            DateTimeOffset.UtcNow,
            dictAtivos.Values.ToImmutableArray(),
            ClubeFiiListaUrl);

        string path = ResolveCaminhoArquivo(baseDirectory);
        using var stream = _fileSystem.File.Open(path, FileMode.Create, FileAccess.Write);
        JsonSerializer.Serialize(stream, listaAtivos, SourceGenerationContext.Default.Options);
        stream.Flush();

        progress.Report(path);
    }

    public IReadOnlyDictionary<string, Ativo> CarregarAtivos(IDirectoryInfo baseDirectory)
    {
        string path = ResolveCaminhoArquivo(baseDirectory);
        using var stream = _fileSystem.File.OpenRead(path);
        var listaAtivos = JsonSerializer.Deserialize<ListaAtivos>(stream, SourceGenerationContext.Default.Options);

        return listaAtivos?.Ativos.ToDictionary(it => it.Codigo, StringComparer.OrdinalIgnoreCase)
               ?? new Dictionary<string, Ativo>();
    }

    private string ResolveCaminhoArquivo(IDirectoryInfo baseDirectory)
    {
        return _fileSystem.Path.Combine(baseDirectory.FullName, "lista-ativos.json");
    }

    private IEnumerable<Ativo> BaixarListaAtivos()
    {
        var web = new HtmlWeb();
        var doc = web.Load(ClubeFiiListaUrl);

        var tableRows = doc.DocumentNode
            .SelectNodes("//div[@id=\"fundos_listados\"]//table//tr[@class=\"tabela_principal\"]");

        foreach (var row in tableRows.Skip(1))
        {
            var cells = row.Descendants("td").ToList();
            string codigo = cells[0].ChildNodes["a"].InnerText.Trim();
            string nome = cells[1].ChildNodes["a"].InnerText.Trim();

            var valorCotaNode = cells[2].Descendants("span").FirstOrDefault(it => it.Id == "valor_atual_cota");
            decimal? valorCota = valorCotaNode is not null
                ? decimal.Parse(valorCotaNode.InnerText, CultureCache.PortuguesBrasil)
                : null;

            DateTimeOffset? dataCotacao = valorCota.HasValue
                ? DateTimeOffset.ParseExact(
                    cells[2].Descendants("span").First(it => it.Id == "data_cotacao").InnerText.AsSpan().Trim(),
                    "dd/MM/yyyy HH:mm:ss",
                    CultureCache.PortuguesBrasil)
                : null;

            bool temDataIpo = DateOnly.TryParseExact(
                cells[3].ChildNodes["a"].InnerText.AsSpan().Trim(),
                "dd/MM/yyyy",
                out var dataIpo);

            decimal? valorIpo = temDataIpo
                ? decimal.Parse(
                    cells[4].ChildNodes["a"].InnerText.AsSpan().Trim().Slice(2),
                    provider: CultureCache.PortuguesBrasil)
                : null;

            string segmento = cells[5].ChildNodes["a"].InnerText.Trim();
            string administrador = cells[6].ChildNodes["a"].InnerText.Trim();

            yield return new Ativo(
                codigo,
                nome,
                valorCota,
                dataCotacao,
                temDataIpo ? dataIpo : null,
                valorIpo,
                segmento,
                administrador);
        }
    }

    private void BaixarRankingAtivos(Dictionary<string, Ativo> dictAtivos)
    {
        var web = new HtmlWeb();
        var doc = web.Load(ClubeFiiRankingUrl);

        var tableRows = doc.DocumentNode
            .SelectNodes("//div[@id=\"fundos_listados\"]//table//tr[@class=\"tabela_principal\"]");

        foreach (var row in tableRows.Skip(1))
        {
            var cells = row.Descendants("td").ToList();
            string codigo = cells[0].ChildNodes["a"].InnerText.Trim();

            decimal pVpa = decimal.Parse(
                cells[4].ChildNodes["a"].InnerText.AsSpan().Trim(),
                provider: CultureCache.PortuguesBrasil);

            decimal yield1Mes = decimal.Parse(
                cells[5].ChildNodes["a"].InnerText.AsSpan().Trim()[..^1],
                provider: CultureCache.PortuguesBrasil);

            bool temYield12Mes = decimal.TryParse(
                cells[6].ChildNodes["a"].InnerText.AsSpan().Trim()[..^1],
                NumberStyles.Float,
                CultureCache.PortuguesBrasil,
                out decimal yield12Mes);

            dictAtivos[codigo] = dictAtivos[codigo] with
            {
                PVpa = pVpa,
                Yield1Mes = yield1Mes / 100m,
                Yield12Meses = temYield12Mes ? yield12Mes / 100m : null
            };
        }
    }
}

public sealed record ListaAtivos(DateTimeOffset UltimaAtualizacao, ImmutableArray<Ativo> Ativos, string Origem);