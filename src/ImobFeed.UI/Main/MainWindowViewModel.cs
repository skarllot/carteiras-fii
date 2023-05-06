using System.Reactive.Disposables;
using ImobFeed.UI.Dashboard;
using ReactiveUI;

namespace ImobFeed.UI.Main;

public class MainWindowViewModel : ViewModelBase, IScreen
{
    public MainWindowViewModel(IFactory<DashboardViewModel> dashboard)
    {
        this.WhenActivated(
            disposables =>
            {
                Router.Navigate
                    .Execute(dashboard.Create())
                    .Subscribe()
                    .DisposeWith(disposables);
            });
    }

    public RoutingState Router { get; } = new();
}