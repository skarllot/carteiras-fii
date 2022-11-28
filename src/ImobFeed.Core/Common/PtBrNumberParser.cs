using System.Globalization;

namespace ImobFeed.Core.Common;

public static class PtBrNumberParser
{
    public static decimal Decimal(ReadOnlySpan<char> s)
    {
        return decimal.Parse(s, provider: CultureCache.PortuguesBrasil);
    }

    public static int Int32(ReadOnlySpan<char> s)
    {
        return int.Parse(s, provider: CultureCache.PortuguesBrasil);
    }

    public static decimal? TryDecimal(ReadOnlySpan<char> s)
    {
        return decimal.TryParse(s, NumberStyles.Number, CultureCache.PortuguesBrasil, out decimal result)
            ? result
            : null;
    }
}