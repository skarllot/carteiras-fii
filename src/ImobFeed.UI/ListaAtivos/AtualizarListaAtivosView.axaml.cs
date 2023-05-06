using Avalonia.Markup.Xaml;
using Avalonia.ReactiveUI;

namespace ImobFeed.UI.ListaAtivos;

public partial class AtualizarListaAtivosView : ReactiveUserControl<AtualizarListaAtivosViewModel>
{
    public AtualizarListaAtivosView()
    {
        InitializeComponent();
    }

    private void InitializeComponent()
    {
        AvaloniaXamlLoader.Load(this);
    }
}