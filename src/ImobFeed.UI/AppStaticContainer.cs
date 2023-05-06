﻿using System.IO.Abstractions;
using ImobFeed.Api;
using ImobFeed.Core;
using ImobFeed.Html;
using ImobFeed.Leitores;
using ImobFeed.UI.Dashboard;
using ImobFeed.UI.ListaAtivos;
using ImobFeed.UI.Main;
using Jab;
using NodaTime;
using ReactiveUI;

namespace ImobFeed.UI;

[ServiceProvider]

// Modules
[Import(typeof(ICoreContainerModule))]
[Import(typeof(ILeitoresContainerModule))]
[Import(typeof(IApiContainerModule))]
[Import(typeof(IHtmlContainerModule))]

// Services
[Singleton(typeof(IFileSystem), typeof(FileSystem))]
[Singleton(typeof(IClock), Factory = nameof(CreateClock))]

// View models
[Singleton(typeof(MainWindowViewModel))]
[Singleton(typeof(IScreen), Factory = nameof(GetScreen))]
[Transient(typeof(AtualizarListaAtivosViewModel))]
[Singleton(typeof(IFactory<AtualizarListaAtivosViewModel>), typeof(ContainerFactory<AtualizarListaAtivosViewModel>))]
internal sealed partial class AppStaticContainer
{
    public IClock CreateClock() => SystemClock.Instance;
    public IScreen GetScreen() => GetService<MainWindowViewModel>();
}