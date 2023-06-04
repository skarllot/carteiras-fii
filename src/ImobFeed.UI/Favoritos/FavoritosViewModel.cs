using System.Reactive;
using System.Reactive.Disposables;
using System.Reactive.Linq;
using ImobFeed.Api;
using ImobFeed.Api.Analise;
using ImobFeed.Core.Common;
using ImobFeed.Html.Analise;
using NodaTime;
using PropertyChanged.SourceGenerator;
using ReactiveUI;

namespace ImobFeed.UI.Favoritos;

public partial class FavoritosViewModel : RoutableViewModelBase
{
    private readonly EscritorIndicacoesFavoritas _escritorJson;
    private readonly IndicacoesFavoritasHtml _escritorHtml;
    private readonly ObservableProgress<ArquivoCriado> _output = new();
    [Notify] private DateTimeOffset _data = DateTimeOffset.Now;

    public FavoritosViewModel(
        IScreen hostScreen,
        EscritorIndicacoesFavoritas escritorJson,
        IndicacoesFavoritasHtml escritorHtml)
        : base(hostScreen)
    {
        _escritorJson = escritorJson;
        _escritorHtml = escritorHtml;

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
        _escritorJson.Calcular(new YearMonth(_data.Year, _data.Month), _output);
        _escritorHtml.Criar(_output);
    }
}