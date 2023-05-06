using System.IO.Abstractions;
using NodaTime;

namespace ImobFeed.Core;

public static class DirectoryNavigation
{
    private static readonly string[] _api = { "api", "v1" };

    public static IDirectoryInfo IrPara(this IDirectoryInfo baseDirectory, YearMonth data)
    {
        string[] path = { data.Year.ToString(), data.Month.ToString("00") };
        return baseDirectory.EstaEm(path) is false
            ? baseDirectory.IrPara(path)
            : baseDirectory;
    }

    public static IDirectoryInfo IrPara(this IDirectoryInfo baseDirectory, IEnumerable<string> path)
    {
        return path.Aggregate(
            baseDirectory,
            static (current, name) => current.CreateSubdirectory(name));
    }

    public static IDirectoryInfo IrParaApi(this IDirectoryInfo baseDirectory)
    {
        return baseDirectory.EstaEm(_api) is false
            ? baseDirectory.IrPara(_api)
            : baseDirectory;
    }

    public static IDirectoryInfo NavegarPara(this IDirectoryInfo baseDirectory, IEnumerable<string> path)
    {
        return baseDirectory.FileSystem.DirectoryInfo.New(
            baseDirectory.FileSystem.Path.Combine(path.Prepend(baseDirectory.FullName).ToArray()));
    }

    public static IDirectoryInfo NavegarParaApi(this IDirectoryInfo baseDirectory)
    {
        return baseDirectory.EstaEm(_api) is false
            ? baseDirectory.NavegarPara(_api)
            : baseDirectory;
    }

    public static bool EstaEm(this IDirectoryInfo? directory, IEnumerable<string> path)
    {
        foreach (string name in path.Reverse())
        {
            if (directory?.Name != name)
                return false;

            directory = directory.Parent;
        }

        return true;
    }
}