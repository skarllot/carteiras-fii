using System.Reactive;
using System.Reactive.Disposables;
using ImobFeed.Core.Referencia;
using ImobFeed.Leitores.Texto;
using NodaTime;
using NodaTime.Extensions;
using PropertyChanged.SourceGenerator;
using ReactiveUI;

namespace ImobFeed.UI.RecomendacaoTexto;

public partial class RecomendacaoTextoViewModel : RoutableViewModelBase
{
    private readonly IReferenciaAtivos _referenciaAtivos;
    [Notify] private DateTimeOffset _data = DateTimeOffset.Now;

    public RecomendacaoTextoViewModel(IScreen hostScreen, IReferenciaAtivos referenciaAtivos)
        : base(hostScreen)
    {
        _referenciaAtivos = referenciaAtivos;
        Voltar = hostScreen.Router.NavigateBack;

        Importar = ReactiveCommand.Create(
            () =>
            {
            });

        this.WhenActivated((CompositeDisposable disposables) => { });
    }
    
    public ReactiveCommand<Unit, Unit> Voltar { get; }
    public ReactiveCommand<Unit, Unit> Importar { get; }

    public IEnumerable<ILeitorRecomendacao> NomeCorretoras => ProvedorLeitorRecomendacao.TodosLeitores();
}