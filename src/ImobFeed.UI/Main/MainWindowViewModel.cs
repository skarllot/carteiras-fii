using System.IO.Abstractions;
using System.Reactive;
using System.Reactive.Disposables;
using System.Reactive.Linq;
using ImobFeed.Core;
using ImobFeed.UI.ListaAtivos;
using ReactiveUI;

namespace ImobFeed.UI.Main;

public class MainWindowViewModel : ViewModelBase, IScreen
{
    private readonly IFactory<AtualizarListaAtivosViewModel> _atualizerAtivos;
    private readonly IFileSystem _fileSystem;
    private readonly IAppConfigurationManager _appConfig;

    public MainWindowViewModel(
        IFileSystem fileSystem,
        IAppConfigurationManager appConfig,
        IFactory<AtualizarListaAtivosViewModel> atualizerAtivos)
    {
        _fileSystem = fileSystem;
        _appConfig = appConfig;
        _atualizerAtivos = atualizerAtivos;

        AtualizarAtivos = ReactiveCommand.CreateFromObservable(
            () => Router.Navigate.Execute(_atualizerAtivos.Create()),
            appConfig.WhenBaseDirectoryChanged.Select(d => d.Exists));

        this.WhenActivated((CompositeDisposable _) => { });
    }

    public ReactiveCommand<Unit, IRoutableViewModel> AtualizarAtivos { get; }

    public IObservable<string> QuandoPastaRaizAltera => _appConfig.WhenBaseDirectoryChanged.Select(d => d.FullName);

    public RoutingState Router { get; } = new();

    public void DefinirPastaRaiz(string valor) => _appConfig.SetBaseDirectory(_fileSystem.DirectoryInfo.New(valor));
}