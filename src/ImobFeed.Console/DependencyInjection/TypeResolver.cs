using Spectre.Console.Cli;

namespace ImobFeed.Console.DependencyInjection;

public sealed class TypeResolver : ITypeResolver, IDisposable
{
    private readonly IServiceProvider _provider;
    private readonly IServiceProvider _staticContainer;

    public TypeResolver(IServiceProvider provider)
    {
        _provider = provider;
        _staticContainer = new AppStaticContainer();
    }

    public object? Resolve(Type? type)
    {
        if (type == null)
        {
            return null;
        }

        return _staticContainer.GetService(type) ?? _provider.GetService(type);
    }

    public void Dispose()
    {
        (_staticContainer as IDisposable)?.Dispose();
        (_provider as IDisposable)?.Dispose();
    }
}