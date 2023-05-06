using System.IO.Abstractions;
using System.Reactive;
using System.Reactive.Disposables;
using System.Reactive.Linq;
using ImobFeed.Core;
using ImobFeed.UI.ListaAtivos;
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
        IFactory<AtualizarListaAtivosViewModel> atualizerAtivos)
        : base(screen)
    {
        _fileSystem = fileSystem;
        _appConfig = appConfig;

        AtualizarAtivos = ReactiveCommand.CreateFromObservable(
            () => screen.Router.Navigate.Execute(atualizerAtivos.Create()),
            appConfig.WhenBaseDirectoryChanged.Select(d => d.NavegarParaApi().Exists));

        this.WhenActivated((CompositeDisposable _) => { });
    }

    public ReactiveCommand<Unit, IRoutableViewModel> AtualizarAtivos { get; }

    public string PastaRaiz => _appConfig.BaseDirectory.FullName;

    public IObservable<string> QuandoPastaRaizAltera => _appConfig.WhenBaseDirectoryChanged.Select(d => d.FullName);

    public void DefinirPastaRaiz(string valor) => _appConfig.SetBaseDirectory(_fileSystem.DirectoryInfo.New(valor));
}