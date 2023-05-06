using Avalonia.Markup.Xaml;
using Avalonia.ReactiveUI;
using ReactiveUI;

namespace ImobFeed.UI.Main;

public partial class MainWindow : ReactiveWindow<MainWindowViewModel>
{
    public MainWindow()
    {
        InitializeComponent();
        AvaloniaXamlLoader.Load(this);
        this.WhenActivated(_ => { });
    }
}