using System.Reactive.Subjects;

namespace ImobFeed.Core.Common;

public sealed class ObservableProgress<T> : IObservable<T>, IProgress<T>, IDisposable
{
    private readonly Subject<T> _subject;

    public ObservableProgress() => _subject = new Subject<T>();

    public IDisposable Subscribe(IObserver<T> observer) => _subject.Subscribe(observer);

    public void Report(T value) => _subject.OnNext(value);

    public void Dispose() => _subject.Dispose();
}