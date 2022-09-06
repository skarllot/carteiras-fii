using Validation;

namespace ImobFeed.Core.Common;

public sealed class InlineProgress<T> : IProgress<T>
{
    private readonly Action<T> _handler;

    public InlineProgress(Action<T> handler)
    {
        Requires.NotNull(handler, nameof(handler));
        _handler = handler;
    }

    public void Report(T value) => _handler(value);
}