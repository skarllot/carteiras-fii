using System.IO.Abstractions;

namespace ImobFeed.Core;

public interface IAppConfiguration
{
    IDirectoryInfo BaseDirectory { get; }

    IDirectoryInfo GetApiDirectory() => BaseDirectory.IrParaApi();
}