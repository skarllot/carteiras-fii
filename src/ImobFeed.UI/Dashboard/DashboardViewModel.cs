using System.IO.Abstractions;
using System.Reactive;
using System.Reactive.Disposables;
using System.Reactive.Linq;
using ImobFeed.Core;
using ImobFeed.UI.Favoritos;
using ImobFeed.UI.ListaAtivos;
using ImobFeed.UI.Recomendacao;
using ReactiveUI;

namespace ImobFeed.UI.Dashboard;

public class DashboardViewModel : RoutableViewModelBase
{
    private readonly IFileSystem _fileSystem;
    private readonly IAppConfigurationManager _appConfig;

    public DashboardViewModel(
        IScreen screen,
        IFileSystem fileSystem,
        IAppConfigurationManager appConfig,
        IFactory<AtualizarListaAtivosViewModel> atualizarAtivos,
        IFactory<RecomendacaoViewModel> recomendacao,
        IFactory<FavoritosViewModel> favoritos)
        : base(screen)
    {
        _fileSystem = fileSystem;
        _appConfig = appConfig;

        var whenValidBaseDirectory = appConfig.WhenBaseDirectoryChanged.Select(d => d.NavegarParaApi().Exists);

        AtualizarAtivos = ReactiveCommand.CreateFromObservable(
            () => screen.Router.Navigate.Execute(atualizarAtivos.Create()),
            whenValidBaseDirectory);
        ImportarRecomendacao = ReactiveCommand.CreateFromObservable(
            () => screen.Router.Navigate.Execute(recomendacao.Create()),
            whenValidBaseDirectory);
        GerarFavoritos = ReactiveCommand.CreateFromObservable(
            () => screen.Router.Navigate.Execute(favoritos.Create()),
            whenValidBaseDirectory);

        this.WhenActivated((CompositeDisposable _) => { });
    }

    public ReactiveCommand<Unit, IRoutableViewModel> AtualizarAtivos { get; }
    public ReactiveCommand<Unit, IRoutableViewModel> ImportarRecomendacao { get; }
    public ReactiveCommand<Unit, IRoutableViewModel> GerarFavoritos { get; }

    public string PastaRaiz => _appConfig.BaseDirectory.FullName;

    public IObservable<string> QuandoPastaRaizAltera => _appConfig.WhenBaseDirectoryChanged.Select(d => d.FullName);

    public void DefinirPastaRaiz(string valor) => _appConfig.SetBaseDirectory(_fileSystem.DirectoryInfo.New(valor));
}