using System.IO.Abstractions;
using ImobFeed.Core.Leitores;

namespace ImobFeed.Api.Indexacao;

public static class FiltrosIndexacao
{
    public static readonly string ArquivosJson = "*.json";
    public static readonly string ArquivosAtivosTop = "??????-top.json";

    public static Func<IDirectoryInfo, bool> DiretoriosAno { get; } =
        it => int.TryParse(it.Name, out int r) && r > 2000;

    public static Func<IDirectoryInfo, bool> DiretoriosMes { get; } =
        it => it.Name.Length == 2 && int.TryParse(it.Name, out int r) && r is >= 1 and <= 12;

    public static Func<IDirectoryInfo, bool> DiretoriosCorretora { get; } =
        it => ProvedorLeitorRecomendacao.NomeNormalizadoExiste(it.Name);

    public static Func<IFileInfo, bool> ArquivosCarteira { get; } =
        it => it.Name != "index.json";
}