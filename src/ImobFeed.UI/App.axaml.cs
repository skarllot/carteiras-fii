using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;
using ImobFeed.UI.Main;

namespace ImobFeed.UI;

public partial class App : Application
{
    private static AppStaticContainer Container { get; } = new();

    public static Window? CurrentMainWindow { get; private set; }

    public override void Initialize()
    {
        AvaloniaXamlLoader.Load(this);
    }

    public override void OnFrameworkInitializationCompleted()
    {
        if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
        {
            desktop.MainWindow = CurrentMainWindow =
                new MainWindow { ViewModel = Container.GetService<MainWindowViewModel>() };
        }

        base.OnFrameworkInitializationCompleted();
    }
}