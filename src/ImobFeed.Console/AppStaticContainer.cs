using System.IO.Abstractions;
using ImobFeed.Api;
using ImobFeed.Console.Commands;
using ImobFeed.Core;
using ImobFeed.Html;
using ImobFeed.Leitores;
using Jab;
using NodaTime;

namespace ImobFeed.Console;

[ServiceProvider]

// Modules
[Import(typeof(ICoreContainerModule))]
[Import(typeof(ILeitoresContainerModule))]
[Import(typeof(IApiContainerModule))]
[Import(typeof(IHtmlContainerModule))]

// Services
[Singleton(typeof(IFileSystem), typeof(FileSystem))]
[Singleton(typeof(IClock), Factory = nameof(CreateClock))]

// Commands
[Singleton(typeof(AtualizarListaAtivosCommand))]
[Singleton(typeof(FavoritosCommand))]
[Singleton(typeof(ImageFileCommand))]
[Singleton(typeof(IndexCommand))]
[Singleton(typeof(TextFileCommand))]
internal sealed partial class AppStaticContainer
{
    public IClock CreateClock() => SystemClock.Instance;
}