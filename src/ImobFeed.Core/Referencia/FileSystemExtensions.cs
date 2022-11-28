using System.IO.Abstractions;
using ImobFeed.Core.Common;
using NodaTime;

namespace ImobFeed.Core.Referencia;

public static class FileSystemExtensions
{
    private static readonly string[] _referencia = { "referencia" };

    public static IDirectoryInfo IrParaApiReferencia(this IDirectoryInfo baseDirectory)
    {
        return baseDirectory.EstaEm(_referencia) is false
            ? baseDirectory
                .IrParaApi()
                .IrPara(_referencia)
            : baseDirectory;
    }

    public static IDirectoryInfo IrParaApiReferencia(this IDirectoryInfo baseDirectory, int ano)
    {
        string[] path = { ano.ToString() };
        return baseDirectory.EstaEm(path) is false
            ? baseDirectory
                .IrParaApiReferencia()
                .IrPara(path)
            : baseDirectory;
    }

    public static IFileInfo IrParaArquivoReferenciaAtivos(this IDirectoryInfo baseDirectory)
    {
        return baseDirectory.IrParaApiReferencia()
            .CreateFileInfo("lista-ativos.json");
    }

    public static IFileInfo IrParaArquivoDiffReferenciaAtivos(this IDirectoryInfo baseDirectory, DateTimeOffset date)
    {
        return baseDirectory.IrParaApiReferencia()
            .CreateFileInfo($"{date:yyyyMMdd'-'HHmmss}-lista-ativos-diff.json");
    }

    public static IFileInfo IrParaArquivoReferenciaIndicadores(this IDirectoryInfo baseDirectory, YearMonth date)
    {
        return baseDirectory.IrParaApiReferencia(date.Year)
            .CreateFileInfo($"{date.Month:00}-lista-indicadores.json");
    }
}