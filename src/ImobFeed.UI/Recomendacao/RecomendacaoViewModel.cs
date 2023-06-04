using System.IO.Abstractions;
using System.Reactive;
using System.Reactive.Disposables;
using System.Reactive.Linq;
using System.Reactive.Subjects;
using DynamicData.Binding;
using ImobFeed.Api;
using ImobFeed.Api.Recomendacoes;
using ImobFeed.Core;
using ImobFeed.Core.Common;
using ImobFeed.Core.Referencia;
using ImobFeed.Leitores.Imagem;
using ImobFeed.Leitores.Texto;
using ImobFeed.UI.Common;
using NodaTime;
using PropertyChanged.SourceGenerator;
using ReactiveUI;
using Notification = Avalonia.Controls.Notifications.Notification;

namespace ImobFeed.UI.Recomendacao;

public partial class RecomendacaoViewModel : RoutableViewModelBase
{
    private readonly IFileSystem _fileSystem;
    private readonly IAppConfiguration _appConfig;
    private readonly IReferenciaAtivos _referenciaAtivos;
    private readonly ObservableProgress<ArquivoCriado> _output = new();
    private readonly Subject<Notification> _notificacoes = new();
    [Notify] private DateTimeOffset _data = DateTimeOffset.Now;
    [Notify] private ILeitorRecomendacao? _leitorRecomendacaoSelecionado;
    [Notify] private string? _nomeCarteira;
    [Notify] private string _conteudo = string.Empty;

    public RecomendacaoViewModel(
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

        var quandoSelecaoCorretoraMuda = this
            .WhenValueChanged<RecomendacaoViewModel, ILeitorRecomendacao>(vm => vm.LeitorRecomendacaoSelecionado)
            .Select(l => l is not null);
        var quandoPreenchimentoConteudoMuda = this
            .WhenValueChanged<RecomendacaoViewModel, string>(vm => vm.Conteudo)
            .Select(s => !string.IsNullOrWhiteSpace(s));
        var quandoUrlConteudoMuda = this
            .WhenValueChanged<RecomendacaoViewModel, string>(vm => vm.Conteudo)
            .Select(c => Uri.TryCreate(c, UriKind.Absolute, out _));
        var quandoProntidaoImportacaoTextoMuda = quandoSelecaoCorretoraMuda
            .CombineLatest(quandoPreenchimentoConteudoMuda, (v1, v2) => v1 && v2);
        var quandoProntidaoImportacaoImagemMuda = quandoSelecaoCorretoraMuda
            .CombineLatest(quandoUrlConteudoMuda, (v1, v2) => v1 && v2);

        AbrirLink = ReactiveCommand.Create(
            () => { new Uri(_leitorRecomendacaoSelecionado!.Url, UriKind.Absolute).OpenInBrowser(); },
            quandoSelecaoCorretoraMuda);

        ImportarTexto = ReactiveCommand.CreateFromTask(
            () => Task.Run(ExecutarImportacaoTexto),
            quandoProntidaoImportacaoTextoMuda);
        ImportarImagem = ReactiveCommand.CreateFromTask(
            () => Task.Run(ExecutarImportacaoImagem),
            quandoProntidaoImportacaoImagemMuda);

        this.WhenActivated(
            disposables =>
            {
                ImportarTexto
                    .Select(_ => new Notification("Importação", "A importação foi concluída com sucesso"))
                    .Subscribe(_notificacoes)
                    .DisposeWith(disposables);

                ImportarTexto
                    .Subscribe(
                        _ =>
                        {
                            NomeCarteira = null;
                            Conteudo = string.Empty;
                        })
                    .DisposeWith(disposables);

                _output.DisposeWith(disposables);
                _notificacoes.DisposeWith(disposables);
            });
    }

    public ReactiveCommand<Unit, Unit> Voltar { get; }
    public ReactiveCommand<Unit, Unit> AbrirLink { get; }
    public ReactiveCommand<Unit, Unit> ImportarTexto { get; }
    public ReactiveCommand<Unit, Unit> ImportarImagem { get; }
    public IObservable<Notification> Notificacoes => _notificacoes.AsObservable();

    public IEnumerable<ILeitorRecomendacao> NomeCorretoras => ProvedorLeitorRecomendacao.TodosLeitores();

    private void ExecutarImportacaoTexto()
    {
        if (_leitorRecomendacaoSelecionado is null)
            return;

        var dictAtivos = _referenciaAtivos.CarregarAtivos().Ativos.ToDictionary(x => x.Codigo);

        using var reader = new StringReader(_conteudo);
        var recomendacao = _leitorRecomendacaoSelecionado.Ler(
            dictAtivos,
            reader,
            string.IsNullOrWhiteSpace(_nomeCarteira) ? null : _nomeCarteira,
            new YearMonth(_data.Year, _data.Month));

        new ExportadorRecomendacao(_fileSystem, _appConfig)
            .Salvar(recomendacao, _output);
    }

    private async Task ExecutarImportacaoImagem()
    {
        if (_leitorRecomendacaoSelecionado is null)
            return;

        using var imagemFileInfo = _fileSystem.FileInfo.NewTemp();

        await using (var stream = imagemFileInfo.Open(FileMode.Create))
        using (var httpClient = new HttpClient())
        {
            var message = await httpClient.GetAsync((string?)Conteudo);
            await message.Content.CopyToAsync(stream);
        }

        var leitorImagem = new LeitorImagem();
        string textoImagem = leitorImagem.LerTextoImagem(imagemFileInfo);

        var dictAtivos = _referenciaAtivos.CarregarAtivos().Ativos.ToDictionary(x => x.Codigo);

        using var reader = new StringReader(textoImagem);
        var recomendacao = _leitorRecomendacaoSelecionado.Ler(
            dictAtivos,
            reader,
            string.IsNullOrWhiteSpace(_nomeCarteira) ? null : _nomeCarteira,
            new YearMonth(_data.Year, _data.Month));

        new ExportadorRecomendacao(_fileSystem, _appConfig)
            .Salvar(recomendacao, _output);
    }
}