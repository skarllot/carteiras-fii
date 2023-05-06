using System.IO.Abstractions;
using PropertyChanged.SourceGenerator;
using ReactiveUI;

namespace ImobFeed.UI.Dashboard;

public partial class DashboardViewModel : RoutableViewModelBase
{
    private readonly IFileSystem _fileSystem;
    [Notify] private string? _pastaRaiz;

    public DashboardViewModel(IScreen screen, IFileSystem fileSystem)
        : base(screen)
    {
        _fileSystem = fileSystem;
        _pastaRaiz = fileSystem.Directory.GetCurrentDirectory();
    }
}