using System.IO.Abstractions;
using NodaTime;

namespace ImobFeed.Core;

public static class DirectoryNavigation
{
    public static IDirectoryInfo IrPara(this IDirectoryInfo baseDirectory, YearMonth data)
    {
        return baseDirectory
            .CreateSubdirectory(data.Year.ToString())
            .CreateSubdirectory(data.Month.ToString("00"));
    }

    public static IDirectoryInfo IrParaApi(this IDirectoryInfo baseDirectory)
    {
        return baseDirectory
            .CreateSubdirectory("api")
            .CreateSubdirectory("v1");
    }
}