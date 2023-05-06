using System.Reactive.Disposables;
using ReactiveUI;

namespace ImobFeed.UI.ListaAtivos;

public class AtualizarListaAtivosViewModel : RoutableViewModelBase
{
    public AtualizarListaAtivosViewModel(IScreen hostScreen)
        : base(hostScreen)
    {
        this.WhenActivated((CompositeDisposable _) => { });
    }
}