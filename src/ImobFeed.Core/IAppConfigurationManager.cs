using System.IO.Abstractions;

namespace ImobFeed.Core;

public interface IAppConfigurationManager : IAppConfiguration
{
    void SetBaseDirectory(IDirectoryInfo value);
}