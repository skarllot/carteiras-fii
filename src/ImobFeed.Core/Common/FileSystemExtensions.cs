using System.IO.Abstractions;

namespace ImobFeed.Core.Common;

public static class FileSystemExtensions
{
    public static IFileInfo CreateFileInfo(this IDirectoryInfo directory, string fileName)
    {
        var fileSystem = directory.FileSystem;
        return fileSystem.FileInfo.New(
            fileSystem.Path.Combine(directory.FullName, fileName));
    }
}