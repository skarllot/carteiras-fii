using System.IO.Abstractions;

namespace ImobFeed.Core;

public interface IAppConfiguration
{
    IDirectoryInfo BaseDirectory { get; }
    IObservable<IDirectoryInfo> WhenBaseDirectoryChanged { get; }

    IDirectoryInfo GetApiDirectory() => BaseDirectory.IrParaApi();
}