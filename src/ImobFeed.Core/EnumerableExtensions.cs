namespace ImobFeed.Core;

public static class EnumerableExtensions
{
    public static void Pipe<T>(
        this IEnumerable<T> enumerable,
        Action<IEnumerable<T>> firstAction,
        Action<IEnumerable<T>> secondAction)
    {
        var list = new List<T>(enumerable);
        firstAction(list);
        secondAction(list);
    }
}