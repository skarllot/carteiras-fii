using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using Avalonia.ReactiveUI;
using ReactiveUI;

namespace ImobFeed.UI.Dashboard;

public partial class DashboardView : ReactiveUserControl<DashboardViewModel>
{
    public DashboardView()
    {
        InitializeComponent();
        this.WhenActivated(_ => { });
    }

    private void InitializeComponent()
    {
        AvaloniaXamlLoader.Load(this);
    }

    private async void Procurar_OnClick(object? sender, RoutedEventArgs e)
    {
        var mainWindow = App.CurrentMainWindow;
        if (mainWindow is null || ViewModel is null)
            return;

        var folderDialog = new OpenFolderDialog { Directory = ViewModel.PastaRaiz };
        string? result = await folderDialog.ShowAsync(mainWindow);
        if (result is null)
            return;

        ViewModel.DefinirPastaRaiz(result);
    }
}