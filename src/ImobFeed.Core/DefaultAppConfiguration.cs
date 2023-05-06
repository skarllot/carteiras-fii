using System.IO.Abstractions;
using System.Reactive.Linq;
using System.Reactive.Subjects;

namespace ImobFeed.Core;

public sealed class DefaultAppConfiguration : IAppConfigurationManager
{
    private readonly BehaviorSubject<IDirectoryInfo> _baseDirectoryChanged;

    public DefaultAppConfiguration(IFileSystem fileSystem)
    {
        _baseDirectoryChanged = new BehaviorSubject<IDirectoryInfo>(fileSystem.DirectoryInfo.New("."));
    }

    public IObservable<IDirectoryInfo> WhenBaseDirectoryChanged => _baseDirectoryChanged.AsObservable();
    public IDirectoryInfo BaseDirectory => _baseDirectoryChanged.Value;

    public void SetBaseDirectory(IDirectoryInfo value) => _baseDirectoryChanged.OnNext(value);
}