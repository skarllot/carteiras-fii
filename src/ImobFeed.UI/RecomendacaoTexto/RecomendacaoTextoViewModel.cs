using System.IO.Abstractions;
using System.Reactive;
using System.Reactive.Disposables;
using System.Reactive.Linq;
using DynamicData.Binding;
using ImobFeed.Api;
using ImobFeed.Api.Recomendacoes;
using ImobFeed.Core;
using ImobFeed.Core.Common;
using ImobFeed.Core.Referencia;
using ImobFeed.Leitores.Texto;
using ImobFeed.UI.Common;
using NodaTime;
using PropertyChanged.SourceGenerator;
using ReactiveUI;

namespace ImobFeed.UI.RecomendacaoTexto;

public partial class RecomendacaoTextoViewModel : RoutableViewModelBase
{
    private readonly IFileSystem _fileSystem;
    private readonly IAppConfiguration _appConfig;
    private readonly IReferenciaAtivos _referenciaAtivos;
    [Notify] private DateTimeOffset _data = DateTimeOffset.Now;
    [Notify] private ILeitorRecomendacao? _leitorRecomendacaoSelecionado;
    [Notify] private string? _nomeCarteira;
    [Notify] private string _conteudo = string.Empty;
    private readonly ObservableProgress<ArquivoCriado> _output = new();

    public RecomendacaoTextoViewModel(
        IScreen hostScreen,
        IFileSystem fileSystem,
        IAppConfiguration appConfig,
        IReferenciaAtivos referenciaAtivos)
        : base(hostScreen)
    {
        _fileSystem = fileSystem;
        _appConfig = appConfig;
        _referenciaAtivos = referenciaAtivos;
        Voltar = hostScreen.Router.NavigateBack;

        AbrirLink = ReactiveCommand.Create(
            () => { new Uri(_leitorRecomendacaoSelecionado!.Url, UriKind.Absolute).OpenInBrowser(); },
            this.WhenValueChanged(vm => vm.LeitorRecomendacaoSelecionado).Select(l => l is not null));

        Importar = ReactiveCommand.CreateFromTask(
            () => Task.Run(ExecutarImportacao),
            this.WhenValueChanged(vm => vm.Conteudo).Select(s => !string.IsNullOrWhiteSpace(s)));

        this.WhenActivated(disposables => { _output.DisposeWith(disposables); });
    }

    public ReactiveCommand<Unit, Unit> Voltar { get; }
    public ReactiveCommand<Unit, Unit> AbrirLink { get; }
    public ReactiveCommand<Unit, Unit> Importar { get; }

    public IEnumerable<ILeitorRecomendacao> NomeCorretoras => ProvedorLeitorRecomendacao.TodosLeitores();

    private void ExecutarImportacao()
    {
        if (_leitorRecomendacaoSelecionado is null)
            return;

        var dictAtivos = _referenciaAtivos.CarregarAtivos().Ativos.ToDictionary(x => x.Codigo);
        var recomendacao = _leitorRecomendacaoSelecionado.Ler(
            dictAtivos,
            new StringReader(_conteudo),
            string.IsNullOrWhiteSpace(_nomeCarteira) ? null : _nomeCarteira,
            new YearMonth(_data.Year, _data.Month));

        new ExportadorRecomendacao(_fileSystem, _appConfig)
            .Salvar(recomendacao, _output);
    }
}