using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using Avalonia.ReactiveUI;

namespace ImobFeed.UI.Dashboard;

public partial class DashboardView : ReactiveUserControl<DashboardViewModel>
{
    public DashboardView()
    {
        InitializeComponent();
    }

    private void InitializeComponent()
    {
        AvaloniaXamlLoader.Load(this);
    }

    private async void Procurar_OnClick(object? sender, RoutedEventArgs e)
    {
        if (Application.Current?.ApplicationLifetime is not IClassicDesktopStyleApplicationLifetime desktop ||
            ViewModel is null)
            return;

        var folderDialog = new OpenFolderDialog();
        folderDialog.Directory = Directory.GetCurrentDirectory();
        string? result = await folderDialog.ShowAsync(desktop.MainWindow);
        if (result is null)
            return;

        ViewModel.DefinirPastaRaiz(result);
    }
}