using Avalonia.Markup.Xaml;
using Avalonia.ReactiveUI;
using ReactiveUI;

namespace ImobFeed.UI.Recomendacao;

public partial class RecomendacaoView : ReactiveUserControl<RecomendacaoViewModel>
{
    public RecomendacaoView()
    {
        InitializeComponent();
        this.WhenActivated(_ => { });
    }

    private void InitializeComponent()
    {
        AvaloniaXamlLoader.Load(this);
    }
}