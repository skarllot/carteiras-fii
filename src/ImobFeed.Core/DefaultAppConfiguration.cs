using System.IO.Abstractions;

namespace ImobFeed.Core;

public sealed class DefaultAppConfiguration : IAppConfiguration
{
    public DefaultAppConfiguration(IFileSystem fileSystem)
    {
        BaseDirectory = fileSystem.DirectoryInfo.New(".");
    }

    public IDirectoryInfo BaseDirectory { get; set; }
}