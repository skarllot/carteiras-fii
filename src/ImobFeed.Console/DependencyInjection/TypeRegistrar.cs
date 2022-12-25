using Microsoft.Extensions.DependencyInjection;
using Spectre.Console.Cli;

namespace ImobFeed.Console.DependencyInjection;

public sealed class TypeRegistrar : ITypeRegistrar
{
    private readonly IServiceCollection _builder;

    public TypeRegistrar() => _builder = new ServiceCollection();

    public ITypeResolver Build()
    {
        return new TypeResolver(
            _builder.BuildServiceProvider(
                new ServiceProviderOptions { ValidateScopes = true, ValidateOnBuild = true }));
    }

    public void Register(Type service, Type implementation)
    {
        if (IsSpectreConsoleType(service) is false) return;

        _builder.AddSingleton(service, implementation);
    }

    public void RegisterInstance(Type service, object implementation)
    {
        if (IsSpectreConsoleType(service) is false) return;

        _builder.AddSingleton(service, implementation);
    }

    public void RegisterLazy(Type service, Func<object> factory)
    {
        if (IsSpectreConsoleType(service) is false) return;

        if (factory is null)
        {
            throw new ArgumentNullException(nameof(factory));
        }

        _builder.AddSingleton(service, _ => factory());
    }

    private static bool IsSpectreConsoleType(Type service)
    {
        return service.Assembly == typeof(ICommandApp).Assembly;
    }
}