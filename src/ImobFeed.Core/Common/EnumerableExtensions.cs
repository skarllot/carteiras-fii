namespace ImobFeed.Core.Common;

public static class EnumerableExtensions
{
    public static IEnumerable<T> WhereNotNull<T>(this IEnumerable<T?> enumerable)
        where T : class => enumerable.Where(static it => it is not null)!;
}