﻿using System.Collections.Immutable;
using System.IO.Abstractions;
using System.Text.Json;
using ImobFeed.Core;
using ImobFeed.Core.CarteiraMensal;
using ImobFeed.Core.Referencia;
using ImobFeed.Html.Leitores;
using ImobFeed.Html.Referencia.Modelos;

namespace ImobFeed.Html.Referencia;

public sealed class ReferenciaAtivos : IReferenciaAtivos
{
    private readonly IFileSystem _fileSystem;
    private readonly IAppConfiguration _appConfig;

    public ReferenciaAtivos(IFileSystem fileSystem, IAppConfiguration appConfig)
    {
        _fileSystem = fileSystem;
        _appConfig = appConfig;
    }

    public void Atualizar(IProgress<string> progress)
    {
        var fundsExplorerAtivos =
            LeitorFundsExplorer.LerListaAtivos().ToDictionary(it => it.Codigo, StringComparer.Ordinal);
        var fundsExplorerIndicadores =
            LeitorFundsExplorer.LerRanking().ToDictionary(it => it.Codigo, StringComparer.Ordinal);
        var clubeFiiAtivos =
            LeitorClubeFii.LerListaAtivos().ToDictionary(it => it.Codigo, StringComparer.Ordinal);
        var clubeFiiIndicadores =
            LeitorClubeFii.LerRanking().ToDictionary(it => it.Codigo, StringComparer.Ordinal);

        var listaAtivosBuilder = ImmutableArray.CreateBuilder<Ativo>();
        var listaIndicadoresBuilder = ImmutableArray.CreateBuilder<IndicadorAtivo>();
        foreach (string codigo in clubeFiiAtivos.Keys
                     .Concat(fundsExplorerAtivos.Keys)
                     .Concat(fundsExplorerIndicadores.Keys)
                     .Distinct(StringComparer.Ordinal)
                     .OrderBy(it => it, StringComparer.Ordinal))
        {
            var fundsExplorerAtivo = fundsExplorerAtivos.GetValueOrDefault(codigo);
            var fundsExplorerIndicador = fundsExplorerIndicadores.GetValueOrDefault(codigo);
            var clubeFiiAtivo = clubeFiiAtivos.GetValueOrDefault(codigo);
            var clubeFiiIndicador = clubeFiiIndicadores.GetValueOrDefault(codigo);

            listaAtivosBuilder.Add(
                new Ativo(
                    codigo,
                    clubeFiiAtivo?.Nome ?? fundsExplorerAtivo?.Nome ?? "erro",
                    clubeFiiAtivo?.DataIpo,
                    clubeFiiAtivo?.ValorIpo,
                    fundsExplorerIndicador?.Setor ?? clubeFiiAtivo?.Segmento ?? "erro",
                    fundsExplorerAtivo?.Administrador ?? clubeFiiAtivo?.Administrador ?? "erro"));

            listaIndicadoresBuilder.Add(
                new IndicadorAtivo(
                    codigo,
                    fundsExplorerIndicador?.PatrimonioLiquido,
                    fundsExplorerIndicador?.TotalCotas,
                    fundsExplorerIndicador?.Vpa,
                    fundsExplorerIndicador?.PrecoAtual ?? clubeFiiAtivo?.ValorCota,
                    fundsExplorerIndicador?.PVpa ?? clubeFiiIndicador?.PVpa,
                    fundsExplorerIndicador?.DY1Mes ?? clubeFiiIndicador?.Yield1Mes,
                    fundsExplorerIndicador?.DY3Meses,
                    fundsExplorerIndicador?.DY6Meses,
                    fundsExplorerIndicador?.DY12Meses ?? clubeFiiIndicador?.Yield12Meses,
                    fundsExplorerIndicador?.LiquidezDiaAnterior,
                    fundsExplorerIndicador?.UltimoDividendo,
                    fundsExplorerIndicador?.VacanciaFisica,
                    fundsExplorerIndicador?.VacanciaFinanceira,
                    fundsExplorerIndicador?.QuantidadeAtivos));
        }

        var apiDirectory = _appConfig.GetApiDirectory();
        var listaAtivos = new ListaAtivos(DateTimeOffset.UtcNow, listaAtivosBuilder.ToImmutable());
        string path = _fileSystem.Path.Combine(apiDirectory.FullName, "lista-ativos.json");
        using (var stream = _fileSystem.File.Open(path, FileMode.Create, FileAccess.Write))
        {
            JsonSerializer.Serialize(stream, listaAtivos, SourceGenerationContext.Default.Options);
            stream.Flush();
            progress.Report(path);
        }

        var listaIndicadores = new ListaIndicadores(DateTimeOffset.UtcNow, listaIndicadoresBuilder.ToImmutable());
        path = _fileSystem.Path.Combine(apiDirectory.FullName, "lista-indicadores.json");
        using (var stream = _fileSystem.File.Open(path, FileMode.Create, FileAccess.Write))
        {
            JsonSerializer.Serialize(stream, listaIndicadores, SourceGenerationContext.Default.Options);
            stream.Flush();
            progress.Report(path);
        }
    }

    public IReadOnlyDictionary<string, Ativo> CarregarAtivos()
    {
        var apiDirectory = _appConfig.GetApiDirectory();
        string path = _fileSystem.Path.Combine(apiDirectory.FullName, "lista-ativos.json");
        using var stream = _fileSystem.File.OpenRead(path);
        var listaAtivos = JsonSerializer.Deserialize<ListaAtivos>(stream, SourceGenerationContext.Default.Options);

        return listaAtivos?.Ativos.ToDictionary(it => it.Codigo, StringComparer.OrdinalIgnoreCase)
               ?? new Dictionary<string, Ativo>();
    }

    public IReadOnlyDictionary<string, IndicadorAtivo> CarregarIndicadores()
    {
        var apiDirectory = _appConfig.GetApiDirectory();
        string path = _fileSystem.Path.Combine(apiDirectory.FullName, "lista-indicadores.json");
        using var stream = _fileSystem.File.OpenRead(path);
        var listaAtivos = JsonSerializer.Deserialize<ListaIndicadores>(stream, SourceGenerationContext.Default.Options);

        return listaAtivos?.Indicadores.ToDictionary(it => it.Codigo, StringComparer.OrdinalIgnoreCase)
               ?? new Dictionary<string, IndicadorAtivo>();
    }
}