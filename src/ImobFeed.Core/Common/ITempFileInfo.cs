using System.IO.Abstractions;

namespace ImobFeed.Core.Common;

public interface ITempFileInfo : IFileInfo, IDisposable
{
}