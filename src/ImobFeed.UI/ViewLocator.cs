using ImobFeed.UI.Dashboard;
using ImobFeed.UI.ListaAtivos;
using ImobFeed.UI.Main;
using ImobFeed.UI.Recomendacao;
using Jab;
using ReactiveUI;

namespace ImobFeed.UI;

[ServiceProvider]
[Transient(typeof(IViewFor<MainWindowViewModel>), typeof(MainWindow))]
[Transient(typeof(IViewFor<DashboardViewModel>), typeof(DashboardView))]
[Transient(typeof(IViewFor<AtualizarListaAtivosViewModel>), typeof(AtualizarListaAtivosView))]
[Transient(typeof(IViewFor<RecomendacaoViewModel>), typeof(RecomendacaoView))]
public sealed partial class ViewLocator : IViewLocator
{
    public IViewFor? ResolveView<T>(T viewModel, string? contract = null)
    {
        if (viewModel is null)
            return null;

        var serviceType = typeof(IViewFor<>).MakeGenericType(viewModel.GetType());
        return (IViewFor?)((IServiceProvider)this).GetService(serviceType);
    }
}