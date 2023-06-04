using System.Reactive;
using System.Reactive.Disposables;
using System.Reactive.Linq;
using ImobFeed.Api;
using ImobFeed.Core.Common;
using ReactiveUI;

namespace ImobFeed.UI.Indices;

public class IndicesViewModel : RoutableViewModelBase
{
    private readonly Api.Indexacao.Indices _indices;
    private readonly ObservableProgress<ArquivoCriado> _output = new();

    public IndicesViewModel(IScreen hostScreen, Api.Indexacao.Indices indices)
        : base(hostScreen)
    {
        _indices = indices;

        Gerar = ReactiveCommand.CreateFromTask(
            () => Task.Run(ExecutarGeracao));
        Voltar = hostScreen.Router.NavigateBack;

        this.WhenActivated(disposables => { _output.DisposeWith(disposables); });
    }

    public IObservable<string> Output => _output.Scan(
        string.Empty,
        static (seed, item) => seed.Length > 0 ? seed + Environment.NewLine + item.FilePath : item.FilePath);

    public ReactiveCommand<Unit, Unit> Gerar { get; }
    public ReactiveCommand<Unit, Unit> Voltar { get; }

    private void ExecutarGeracao()
    {
        _indices.Criar(_output);
    }
}