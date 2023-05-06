using System.Reactive;
using System.Reactive.Disposables;
using System.Reactive.Linq;
using ImobFeed.Api;
using ImobFeed.Api.Referencia;
using ImobFeed.Core.Common;
using ReactiveUI;

namespace ImobFeed.UI.ListaAtivos;

public class AtualizarListaAtivosViewModel : RoutableViewModelBase
{
    private readonly ObservableProgress<ArquivoCriado> _output = new();

    public AtualizarListaAtivosViewModel(IScreen hostScreen, EscritorListaAtivosIndicadores escritor)
        : base(hostScreen)
    {
        Voltar = hostScreen.Router.NavigateBack;
        this.WhenActivated(
            disposables =>
            {
                Task.Run(() => escritor.Explorar(_output));
                _output.DisposeWith(disposables);
            });
    }

    public IObservable<string> Output => _output.Scan(
        string.Empty,
        static (seed, item) => seed.Length > 0 ? seed + Environment.NewLine + item.FilePath : item.FilePath);

    public ReactiveCommand<Unit, Unit> Voltar { get; }
}