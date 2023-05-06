namespace ImobFeed.UI;

public interface IFactory<out T>
{
    T Create();
}

internal class ContainerFactory<T> : IFactory<T>
{
    private readonly IServiceProvider _serviceProvider;

    public ContainerFactory(IServiceProvider serviceProvider) => _serviceProvider = serviceProvider;

    public T Create() =>
        (T?)_serviceProvider.GetService(typeof(T)) ??
        throw new InvalidOperationException($"A instance of type '{typeof(T)}' could not be created");
}