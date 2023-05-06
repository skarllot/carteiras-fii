using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;
using ImobFeed.UI.Main;

namespace ImobFeed.UI;

public partial class App : Application
{
    internal static AppStaticContainer Container { get; } = new();

    public override void Initialize()
    {
        AvaloniaXamlLoader.Load(this);
    }

    public override void OnFrameworkInitializationCompleted()
    {
        if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
        {
            desktop.MainWindow = new MainWindow { ViewModel = Container.GetService<MainWindowViewModel>() };
        }

        base.OnFrameworkInitializationCompleted();
    }
}