namespace ImobFeed.Core.Common;

public static class EnumerableExtensions
{
    public static IEnumerable<T> WhereNotNull<T>(this IEnumerable<T?> enumerable)
        where T : class => enumerable.Where(static it => it is not null)!;

    public static TValue? TryGetValue<TKey, TValue>(this IReadOnlyDictionary<TKey, TValue> dictionary, TKey key)
        where TValue : class
    {
        return dictionary.TryGetValue(key, out var value)
            ? value
            : null;
    }
}