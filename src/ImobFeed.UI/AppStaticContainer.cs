﻿using System.IO.Abstractions;
using ImobFeed.Api;
using ImobFeed.Core;
using ImobFeed.Html;
using ImobFeed.Leitores;
using ImobFeed.UI.Dashboard;
using ImobFeed.UI.Favoritos;
using ImobFeed.UI.Indices;
using ImobFeed.UI.ListaAtivos;
using ImobFeed.UI.Main;
using ImobFeed.UI.Recomendacao;
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
[Transient(typeof(IScreen), Factory = nameof(GetScreen))]
[Transient(typeof(DashboardViewModel))]
[Transient(typeof(AtualizarListaAtivosViewModel))]
[Transient(typeof(RecomendacaoViewModel))]
[Transient(typeof(FavoritosViewModel))]
[Transient(typeof(IndicesViewModel))]
[Singleton(typeof(IFactory<DashboardViewModel>), typeof(ContainerFactory<DashboardViewModel>))]
[Singleton(typeof(IFactory<AtualizarListaAtivosViewModel>), typeof(ContainerFactory<AtualizarListaAtivosViewModel>))]
[Singleton(typeof(IFactory<RecomendacaoViewModel>), typeof(ContainerFactory<RecomendacaoViewModel>))]
[Singleton(typeof(IFactory<FavoritosViewModel>), typeof(ContainerFactory<FavoritosViewModel>))]
[Singleton(typeof(IFactory<IndicesViewModel>), typeof(ContainerFactory<IndicesViewModel>))]
internal sealed partial class AppStaticContainer
{
    private IClock CreateClock() => SystemClock.Instance;
    private IScreen GetScreen(MainWindowViewModel vm) => vm;
}