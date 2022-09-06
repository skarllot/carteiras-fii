using System.Globalization;
using System.Text;

namespace ImobFeed.Core.Common;

public static class StringExtensions
{
    public static string RemoveDiacritics(this string text)
    {
        string normalizedString = text.Normalize(NormalizationForm.FormD);
        var stringBuilder = new StringBuilder(normalizedString.Length);

        foreach (var c in normalizedString.EnumerateRunes())
        {
            var unicodeCategory = Rune.GetUnicodeCategory(c);
            if (unicodeCategory != UnicodeCategory.NonSpacingMark)
            {
                stringBuilder.Append((char) c.Value);
            }
        }

        return stringBuilder.ToString().Normalize(NormalizationForm.FormC);
    }
}