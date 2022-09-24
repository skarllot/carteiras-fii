using System.Globalization;
using NodaTime;

namespace ImobFeed.Console;

public static class YearMonthProvider
{
    public static YearMonth ThisMonth()
    {
        var now = DateTime.UtcNow;
        return new YearMonth(now.Year, now.Month);
    }

    public static YearMonth? TryParse(string input)
    {
        return DateTimeOffset.TryParseExact(input, "yyyy-MM", null, DateTimeStyles.AssumeUniversal, out var result)
            ? new YearMonth(result.Year, result.Month)
            : null;
    }
}