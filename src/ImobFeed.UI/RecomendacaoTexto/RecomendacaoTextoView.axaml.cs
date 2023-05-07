using Avalonia.Markup.Xaml;
using Avalonia.ReactiveUI;
using ReactiveUI;

namespace ImobFeed.UI.RecomendacaoTexto;

public partial class RecomendacaoTextoView : ReactiveUserControl<RecomendacaoTextoViewModel>
{
    public RecomendacaoTextoView()
    {
        InitializeComponent();
        this.WhenActivated(_ => { });
    }

    private void InitializeComponent()
    {
        AvaloniaXamlLoader.Load(this);
    }
}